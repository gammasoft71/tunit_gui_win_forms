using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tunit {
  public partial class FormTestFixtureProperties : Form {
    public FormTestFixtureProperties() {
      InitializeComponent();
    }
    public FormTestFixtureProperties(string file, string testFixtureName, int tests, TestStatus testStatus, TimeSpan duration) {
      InitializeComponent();
      this.Text = $"{testFixtureName} properties";
      this.labelTestFixtureName.Text = testFixtureName;
      this.labelTests.Text = tests.ToString();
      switch (testStatus) {
        case TestStatus.NotStarted:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.NotStarted;
          this.labelStatus.Text = "Not Started";
          break;
        case TestStatus.Succeed:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.Succeed;
          this.labelStatus.Text = "Succeed";
          break;
        case TestStatus.Ignored:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.Ignored;
          this.labelStatus.Text = "Ignored";
          break;
        case TestStatus.Aborted:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.Aborted;
          this.labelStatus.Text = "Aborted";
          break;
        case TestStatus.Failed:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.Failed;
          this.labelStatus.Text = "Failed";
          break;
        default:
          break;
      }
      this.richTextBoxFile.Text = file;
      this.labelTime.Text = duration.ToString();
    }
  }
}
