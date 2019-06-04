using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit {
  public class UnitTest {
    public UnitTest(TUnitProject tunitProject, string fileName) {
      if (!IsTUnitApplication(fileName)) throw new ArgumentException($"{fileName} is not a TUnit application");
      this.FileName = fileName;
      this.tunitProject = tunitProject;
      this.Reset();
    }

    public TimeSpan Duration { get; set; }

    public string FileName { get; private set; }

    public int TestCount {
      get {
        int count = 0;
        foreach (var testFixture in this.testFixtures) {
          count += testFixture.Value.TestCount;
        }
        return count;
      }
    }

    public string Name {
      get { return System.IO.Path.GetFileNameWithoutExtension(this.FileName); }
    }

    public TestFixture this[string testFixtureName] {
      get { return this.testFixtures[testFixtureName]; }
    }

    public string[] TestFixtureNames {
      get { return this.testFixtures.Keys.ToArray(); }
    }

    public TestFixture[] TestFixtures {
      get { return this.testFixtures.Values.ToArray(); }
    }

    public string[] TextOutput { get ; private set; }

    public TUnitProject TUnitProject {
      get { return this.tunitProject; }
    }

    public TestStatus Status { get; set; }

    public static bool IsTUnitApplication(string fileName) {
      if (!System.IO.File.Exists(fileName)) return false;
      System.Diagnostics.Process process = new System.Diagnostics.Process();
      process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName, "--help");
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();
      if (process.WaitForExit(1000) == false) return false;
      if (!process.StandardOutput.ReadToEnd().StartsWith("This program contains tests written using xtd::tunit.")) return false;
      if (!process.HasExited) process.Kill();
      process.Close();
      return true;
    }

    public void Load() {
      this.process = new System.Diagnostics.Process();
      this.process.StartInfo = new System.Diagnostics.ProcessStartInfo(this.FileName, "--list_tests");
      this.process.StartInfo.CreateNoWindow = true;
      this.process.StartInfo.UseShellExecute = false;
      this.process.StartInfo.RedirectStandardOutput = true;
      this.process.Start();
      while (!process.StandardOutput.EndOfStream) {
        string[] test = this.process.StandardOutput.ReadLine().Split('.');
        if (!this.testFixtures.ContainsKey(test[0])) this.testFixtures.Add(test[0], new TestFixture(this, test[0]));
        this.testFixtures[test[0]].AddTest(test[1]);
      }
      this.process.WaitForExit();
      this.process.Close();
      this.process = null;
    }

    public void Reset() {
      this.Status = TestStatus.NotStarted;
      this.TextOutput = new string[0];
      foreach (var testFixture in this.testFixtures)
        testFixture.Value.Reset();
    }

    public void Run() {
      this.Run("");
    }

    public void Run(string arguments) {
      this.process = new System.Diagnostics.Process();
      this.process.StartInfo = new System.Diagnostics.ProcessStartInfo(this.FileName, $"--output_color=false {arguments}");
      this.process.StartInfo.CreateNoWindow = true;
      this.process.StartInfo.UseShellExecute = false;
      this.process.StartInfo.RedirectStandardOutput = true;
      this.process.Start();
      ParseProcessOutput(this.process.StandardOutput);
      this.process.WaitForExit();
      this.process.Close();
      this.process = null;
    }

    private void ParseProcessOutput(System.IO.StreamReader streamReader) {
      List<string> lines = new List<string>();
      string line;
      List<string> errorsAndFailures = new List<string>();
      string stackTrace = "";
      string[] fixtureAndTestName = null;
      TimeSpan duration = TimeSpan.Zero;
      int countLine = 0;
      TestStatus status = TestStatus.NotStarted;
      while ((line = streamReader.ReadLine()) != null) {
        lines.Add(line);
        line = line.Trim();
        if (countLine++ < 2 || line == "") continue;
        if (line.StartsWith("SUCCEED") || line.StartsWith("IGNORED") || line.StartsWith("ABORTED") || line.StartsWith("FAILED ")) {
          if (status != TestStatus.NotStarted) {
            if (this[fixtureAndTestName[0]][fixtureAndTestName[1]].Status != status) {
              switch (this[fixtureAndTestName[0]][fixtureAndTestName[1]].Status) {
                case TestStatus.Succeed: this.tunitProject.SucceedCount--; this.tunitProject.RanCount--; break;
                case TestStatus.Ignored: this.tunitProject.IngoredCount--; this.tunitProject.RanCount--; break;
                case TestStatus.Aborted: this.tunitProject.AbortedCount--; this.tunitProject.RanCount--; break;
                case TestStatus.Failed: this.tunitProject.FailedCount--; this.tunitProject.RanCount--; break;
              }
              switch (status) {
                case TestStatus.Succeed: this.tunitProject.SucceedCount++; this.tunitProject.RanCount++; break;
                case TestStatus.Ignored: this.tunitProject.IngoredCount++; this.tunitProject.RanCount++; break;
                case TestStatus.Aborted: this.tunitProject.AbortedCount++; this.tunitProject.RanCount++; break;
                case TestStatus.Failed: this.tunitProject.FailedCount++; this.tunitProject.RanCount++; break;
              }
            }
            this[fixtureAndTestName[0]][fixtureAndTestName[1]].SetStatus(status, errorsAndFailures.ToArray(), stackTrace, duration);
            stackTrace = "";
            errorsAndFailures.Clear();
            status = TestStatus.NotStarted;
          }
          switch (line.Substring(0, 7)) {
            case "SUCCEED": status = TestStatus.Succeed; break;
            case "IGNORED": status = TestStatus.Ignored; break;
            case "ABORTED": status = TestStatus.Aborted; break;
            case "FAILED ": status = TestStatus.Failed; break;
          }
          duration = TimeSpan.FromMilliseconds(double.Parse(line.Substring(line.IndexOf("(") + 1, line.IndexOf(" ms") - line.IndexOf("("))));
          line = line.Substring(8, line.IndexOf(" (") - 8);
          fixtureAndTestName = line.Split('.');
        } else if (line.StartsWith("Stack Trace: in ")) {
          stackTrace = line.Substring(16);
        } else if (line.StartsWith("Test results:")) {
          lines.AddRange(streamReader.ReadToEnd().Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries));
        } else {
          errorsAndFailures.Add(line.Trim());
        }
      }

      if (status != TestStatus.NotStarted) {
        if (this[fixtureAndTestName[0]][fixtureAndTestName[1]].Status != status) {
          switch (this[fixtureAndTestName[0]][fixtureAndTestName[1]].Status) {
            case TestStatus.Succeed: this.tunitProject.SucceedCount--; this.tunitProject.RanCount--; break;
            case TestStatus.Ignored: this.tunitProject.IngoredCount--; this.tunitProject.RanCount--; break;
            case TestStatus.Aborted: this.tunitProject.AbortedCount--; this.tunitProject.RanCount--; break;
            case TestStatus.Failed: this.tunitProject.FailedCount--; this.tunitProject.RanCount--; break;
          }
          switch (status) {
            case TestStatus.Succeed: this.tunitProject.SucceedCount++; this.tunitProject.RanCount++; break;
            case TestStatus.Ignored: this.tunitProject.IngoredCount++; this.tunitProject.RanCount++; break;
            case TestStatus.Aborted: this.tunitProject.AbortedCount++; this.tunitProject.RanCount++; break;
            case TestStatus.Failed: this.tunitProject.FailedCount++; this.tunitProject.RanCount++; break;
          }
        }
        this[fixtureAndTestName[0]][fixtureAndTestName[1]].SetStatus(status, errorsAndFailures.ToArray(), stackTrace, duration);
      }
      if (this.TextOutput.Length != 0) lines.Insert(0, "");
      lines.InsertRange(0, this.TextOutput);
      this.TextOutput = lines.ToArray();
    }

    public void Stop() {
      if (this.process != null && !this.process.HasExited)
        this.process.Kill();
    }

    private Dictionary<string, TestFixture> testFixtures = new Dictionary<string, TestFixture>();
    private TUnitProject tunitProject;
    System.Diagnostics.Process process = null;
  }
}
