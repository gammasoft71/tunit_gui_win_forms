using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit_gui {
  public class TestFixture {
    public TestFixture(UnitTest unitTest, string name) {
      this.unitTest = unitTest;
      this.Name = name;
      this.Reset();
    }

    public int TestCount {
      get { return this.tests.Count; }
    }

    public string Name { get; private set; }

    public Test this[string testName] {
      get { return this.tests[testName]; }
    }

    public string[] TestNames {
      get { return this.tests.Keys.ToArray(); }
    }

    public UnitTest UnitTest {
      get { return this.unitTest; }
    }

    public Test[] Tests {
      get { return this.tests.Values.ToArray(); }
    }

    public TestStatus Status { get; set; }

    public void AddTest(string testName) { this.tests.Add(testName, new Test(this, testName)); }

    public void Reset() {
      this.Status = TestStatus.NotStarted;
      foreach (var test in this.tests)
        test.Value.Reset();
    }

    private Dictionary<string, Test> tests = new Dictionary<string, Test>();
    private UnitTest unitTest;
  }
}
