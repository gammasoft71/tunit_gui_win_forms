using System;
using System.Linq;
using System.Windows.Forms;

namespace tunit_gui {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      TUnitProject tup = new TUnitProject();
      tup.Name = "FirstTest";
      tup.Files = (tup.Files.Append("TunitTest1.exe")).ToArray();
      tup.Files = (tup.Files.Append("TunitTest2.exe")).ToArray();
      TUnitProject.Write("test.tunit", tup);
      TUnitProject tup2 = TUnitProject.Read("test.tunit");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new FormMain());
    }
  }
}
