using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit_gui {
  public class TestEventArgs : EventArgs {
    public TestEventArgs(Test test) { this.test = test; }

    public Test  Test {
      get { return this.test; }
    }

    private Test test;
  }

  public delegate void TestEventHandler(object sender, TestEventArgs e);
}
