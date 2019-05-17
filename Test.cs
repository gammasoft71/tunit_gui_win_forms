using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit_gui {
  public class Test {
    public Test(TestFixture testFixture, string name) {
      this.testFixture = testFixture;
      this.Name = name;
      this.Reset();
    }

    public string Name { get; private set; }

    public TestStatus Status { get; set; }

    public string StackTrace { get; private set; }

    public string[] ErrorsAndFailures { get; private set; }

    public TestFixture TestFixture {
      get { return this.testFixture; }
    }

    public void Reset() {
      this.Status = TestStatus.NotStarted;
      this.ErrorsAndFailures = new string[0];
    }

    public void SetStatus(TestStatus status, string[] infos, string stackTrace) {
      if (this.TestFixture.UnitTest.TUnitProject.TestStart != null) this.TestFixture.UnitTest.TUnitProject.TestStart(this, new TestEventArgs(this));
      this.Status = status;
      ErrorsAndFailures = infos;

      this.StackTrace = stackTrace;

      if (this.TestFixture.Status < this.Status) this.TestFixture.Status = this.Status;
      if (this.TestFixture.UnitTest.Status < this.Status) this.TestFixture.UnitTest.Status = this.Status;
      if (this.TestFixture.UnitTest.TUnitProject.Status < this.Status) this.TestFixture.UnitTest.TUnitProject.Status = this.Status;

      if (this.TestFixture.UnitTest.TUnitProject.TestEnd != null) this.TestFixture.UnitTest.TUnitProject.TestEnd(this, new TestEventArgs(this));
    }

    private TestFixture testFixture;
  }
}
