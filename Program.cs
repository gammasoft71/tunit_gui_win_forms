using System;
using System.Linq;
using System.Windows.Forms;

namespace tunit {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      /*
      TUnitProject project = new TUnitProject("C:\\Users\\Yves\\OneDrive\\Bureau\\xtd_strings.tunit");
      int number = 0;
      project.TestEnd += delegate (object sender, TestEventArgs e) {
        System.Diagnostics.Debug.WriteLine($"    {++number:D3}/{project.TestCount} {e.Test.Status,-7} [{e.Test.TestFixture.UnitTest.Name}].[{e.Test.TestFixture.Name}].[{e.Test.Name}]");
        foreach (string line in e.Test.ErrorsAndFailures)
          System.Diagnostics.Debug.WriteLine($"      {line}");
        if (e.Test.StackTrace != "")
          System.Diagnostics.Debug.WriteLine($"      Stack trace : {e.Test.StackTrace}");
      };
      project.Load();

      System.Diagnostics.Debug.WriteLine($"FileName = {project.FileName}");
      System.Diagnostics.Debug.WriteLine($"  Name = {project.Name}");
      System.Diagnostics.Debug.WriteLine($"  Description = {project.Description}");
      System.Diagnostics.Debug.WriteLine($"  Count = {project.TestCount}");
      System.Diagnostics.Debug.WriteLine($"  Status = {project.Status}");

      System.Diagnostics.Debug.WriteLine("  Unit tests:");
      foreach (var unitTest in project.UnitTests) {
        System.Diagnostics.Debug.WriteLine($"    FileName = {unitTest.FileName}");
        System.Diagnostics.Debug.WriteLine($"      Name = {unitTest.Name}");
        System.Diagnostics.Debug.WriteLine($"      Count = {unitTest.TestCount}");
        System.Diagnostics.Debug.WriteLine($"      Status = {unitTest.Status}");
      }

      System.Diagnostics.Debug.WriteLine("");
      System.Diagnostics.Debug.WriteLine("  Run tests:");

      project.Run();
      */

      /*
      foreach (string unitTestname in project.UnitTestNames) {
        project.Run(project[unitTestname]);
      }
      */

      /*
      foreach (string unitTestname in project.UnitTestNames) {
        foreach (string testFixtureName in project[unitTestname].TestFixtureNames) {
          project.Run(project[unitTestname][testFixtureName]);
        }
      }
      */

      /*
      foreach (string unitTestname in project.UnitTestNames) {
        foreach (string testFixtureName in project[unitTestname].TestFixtureNames) {
          foreach (string testName in project[unitTestname][testFixtureName].TestNames) {
            project.Run(project[unitTestname][testFixtureName][testName]);
          }
        }
      }
      */

      /*
      System.Diagnostics.Debug.WriteLine("");
      System.Diagnostics.Debug.WriteLine($"  Status = {project.Status}");
      */

      /*
      System.Diagnostics.Debug.WriteLine("");
      System.Diagnostics.Debug.WriteLine("  TextOutput");
      foreach (var line in project.TextOutPut)
        System.Diagnostics.Debug.WriteLine(line);
      */

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      //Application.Run(new FormMainOld());
      Application.Run(new FormMain());
    }
  }
}
