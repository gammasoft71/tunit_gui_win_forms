using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit {
  public class TUnitProject {
    public TUnitProject() {
      this.Reset();
    }

    public TUnitProject(string fileName) {
      this.FileName = fileName;
      this.Reset();
    }

    public string Description {
      get { return this.File.Description; }
      set { this.File.Description = value; }
    }

    public string Name {
      get { return this.File.Name; }
      set { this.File.Name = value; }
    }

    public string FileName { get; set; }

    public int TestCount {
      get {
        int count = 0;
        foreach (var unitTest in this.unitTests) {
          count += unitTest.Value.TestCount;
        }
        return count;
      }
    }

    public int RanCount { get; set; }

    public int SucceedCount { get; set; }

    public int IngoredCount { get; set; }

    public int AbortedCount { get; set; }

    public int FailedCount { get; set; }

    public TimeSpan ElapsedTime { get; set; }

    public string[] TextOutput {
      get {
        List<string> textOutput = new List<string>();
        bool first = true;
        foreach (var unitTest in this.unitTests) {
          if (!first) textOutput.Add("");
          textOutput.AddRange(unitTest.Value.TextOutput);
          first = false;
        }
        return textOutput.ToArray();
      }
    }

    public bool Saved {
      get { return this.File.Saved; }
    }

    public UnitTest this[string fileName] {
      get { return this.unitTests[fileName];}
    }

    public string[] UnitTestNames {
      get { return this.unitTests.Keys.ToArray(); }
    }

    public UnitTest[] UnitTests {
      get { return this.unitTests.Values.ToArray(); }
    }

    public TestStatus Status { get; set; }

    private ProjectFile File { get; set; }

    public EventHandler TUnitProjectStart = null;
    public EventHandler TUnitProjectEnd = null;
    public TestEventHandler TestStart = null;
    public TestEventHandler TestEnd = null;

    private static void OnTestStart(object sender, TestEventArgs e) { }

    public void AddUnitTest(string fileName) {
      if (this.unitTests.ContainsKey(fileName)) throw new ArgumentException("fileName already exist");
      this.File.UnitTests = this.File.UnitTests.Append(fileName).ToArray();
      this.unitTests.Add(fileName, new UnitTest(this, fileName));
      this[fileName].Load();
    }

    public void RemoveUnitTest(string fileName) {
      this.unitTests.Remove(fileName);
      //this.File.UnitTests.Re
    }

    public void Load() {
      this.File = ProjectFile.Read(this.FileName);

      foreach (string fileName in this.File.UnitTests) {
        this.unitTests.Add(fileName, new UnitTest(this, fileName));
        this.unitTests[fileName].Load();
      }
    }

    public void New() {
      this.File = new ProjectFile();
    }

    public void Reset() {
      this.Status = TestStatus.NotStarted;
      foreach (var unitTest in this.unitTests)
        unitTest.Value.Reset();
      this.RanCount = 0;
      this.SucceedCount = 0;
      this.IngoredCount = 0;
      this.AbortedCount = 0;
      this.FailedCount = 0;
      this.ElapsedTime = TimeSpan.Zero;
    }

    public void Run() {
      if (this.TUnitProjectStart != null) this.TUnitProjectStart(this, EventArgs.Empty);
      System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
      foreach (var unitTest in this.unitTests)
        unitTest.Value.Run("");
      sw.Stop();
      this.ElapsedTime = sw.Elapsed;
      if (this.TUnitProjectEnd != null) this.TUnitProjectEnd(this, EventArgs.Empty);
    }

    public void Run(UnitTest unitTest) {
      if (this.TUnitProjectStart != null) this.TUnitProjectStart(this, EventArgs.Empty);
      System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
      unitTest.Run();
      sw.Stop();
      this.ElapsedTime = sw.Elapsed;
      if (this.TUnitProjectEnd != null) this.TUnitProjectEnd(this, EventArgs.Empty);
    }

    public void Run(TestFixture fixture) {
      if (this.TUnitProjectStart != null) this.TUnitProjectStart(this, EventArgs.Empty);
      System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
      fixture.UnitTest.Run($"--filter_tests={fixture.Name}.*");
      sw.Stop();
      this.ElapsedTime = sw.Elapsed;
      if (this.TUnitProjectEnd != null) this.TUnitProjectEnd(this, EventArgs.Empty);
    }

    public void Run(Test test) {
      if (this.TUnitProjectStart != null) this.TUnitProjectStart(this, EventArgs.Empty);
      System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
      test.TestFixture.UnitTest.Run($"--filter_tests={test.TestFixture.Name}.{test.Name}");
      sw.Stop();
      this.ElapsedTime = sw.Elapsed;
      if (this.TUnitProjectEnd != null) this.TUnitProjectEnd(this, EventArgs.Empty);
    }

    public void Stop() {
      foreach (var unitTest in this.unitTests)
        unitTest.Value.Stop();
    }

    public void Save() {
      ProjectFile.Write(this.FileName, this.File);
    }

    private Dictionary<string, UnitTest> unitTests = new Dictionary<string, UnitTest>();
  }
}
