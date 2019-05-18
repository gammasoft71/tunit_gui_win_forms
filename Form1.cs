using System;
using System.Linq;
using System.Windows.Forms;

namespace tunit_gui {
  public partial class FormMain : Form {
    public FormMain() {
      InitializeComponent();

      Application.Idle += this.OnApplicationIdle;
      this.FormClosing += this.OnFormClosing;

      this.errorsAndFailuresTabPage = this.tabControlResults.TabPages[0];
      this.testsNotRunTabPage = this.tabControlResults.TabPages[1];

      this.newToolStripMenuItem.Click += this.OnFileNewClick;
      this.openToolStripMenuItem.Click += this.OnFileOpenClick;
      this.closeToolStripMenuItem.Click += this.OnFileCloseClick;
      this.saveToolStripMenuItem.Click += this.OnFileSaveClick;
      this.saveAsToolStripMenuItem.Click += this.OnFileSaveAsClick;
      this.exitToolStripMenuItem.Click += this.OnFileExitClick;
      this.addTUnitFileToolStripMenuItem.Click += this.OnProjectAddTUnitFileClick;
      this.fullGUIToolStripMenuItem.Click += this.OnProjectFullGUIClick;
      this.miniGUIToolStripMenuItem.Click += this.OnViewMiniGUIClick;
      this.errorsFailuresToolStripMenuItem.Click += this.OnViewErrorsAndFailuresClick;
      this.testsNotRunToolStripMenuItem.Click += this.OnTestsNotRunClick;
      this.statusBarToolStripMenuItem.Click += this.OnViewStatusBarClick;
      this.treeViewTests.AfterSelect += this.OnTreeViewTestsAfterSelect;
      this.runAllToolStripMenuItem.Click += this.OnRunAllTestsClick;
    }

    private void OnRunAllTestsClick(object sender, EventArgs e) {
      this.tunitProject.Run();
    }

    private void OnTreeViewTestsAfterSelect(object sender, TreeViewEventArgs e) {
      this.labelSelectedTest.Text = this.treeViewTests.SelectedNode.Text;
    }

    private void OnProjectFullGUIClick(object sender, EventArgs e) {
      this.fullGUIToolStripMenuItem.Checked = true;
      this.miniGUIToolStripMenuItem.Checked = false;
      this.splitContainerMain.Panel2Collapsed = false;
      this.statusStripMain.Visible = true;
      this.ClientSize = new System.Drawing.Size(800, 450);
    }

    private void OnViewMiniGUIClick(object sender, EventArgs e) {
      this.fullGUIToolStripMenuItem.Checked = false;
      this.miniGUIToolStripMenuItem.Checked = true;
      this.splitContainerMain.Panel2Collapsed = true;
      this.statusStripMain.Visible = false;
      this.ClientSize = new System.Drawing.Size(400, 450);
    }

    private void OnTestsNotRunClick(object sender, EventArgs e) {
      if (this.testsNotRunToolStripMenuItem.Checked)
        this.tabControlResults.TabPages.Insert(this.tabControlResults.TabPages.Count - 1, testsNotRunTabPage);
      else
        this.tabControlResults.TabPages.Remove(testsNotRunTabPage);
    }

    private void OnViewErrorsAndFailuresClick(object sender, EventArgs e) {
      if (this.errorsFailuresToolStripMenuItem.Checked)
        this.tabControlResults.TabPages.Insert(0, errorsAndFailuresTabPage);
      else
        this.tabControlResults.TabPages.Remove(errorsAndFailuresTabPage);
    }

    private void OnViewStatusBarClick(object sender, EventArgs e) {
      this.statusStripMain.Visible = !this.statusStripMain.Visible;
    }

    private string[] GetTUnitFixtures(string fileName) {
      System.Diagnostics.Process process = new System.Diagnostics.Process();
      process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName, "--list_tests");
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();
      System.Collections.Generic.SortedSet<string> results = new System.Collections.Generic.SortedSet<string>();
      while (!process.StandardOutput.EndOfStream)
        results.Add(process.StandardOutput.ReadLine().Split('.')[0]);
      process.WaitForExit();
      return results.ToArray();
    }

    private string[] GetTUnitTests(string fileName, string fixture) {
      System.Diagnostics.Process process = new System.Diagnostics.Process();
      process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName, "--list_tests");
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();
      System.Collections.Generic.List<string> results = new System.Collections.Generic.List<string>();
      while (!process.StandardOutput.EndOfStream) {
        string[] fixtureTest = process.StandardOutput.ReadLine().Split('.');
        if (fixtureTest[0] == fixture)
          results.Add(fixtureTest[1]);
      }
      process.WaitForExit();
      return results.ToArray();
    }

    private void ReloadProject() {
      this.treeViewTests.SuspendLayout();
      this.treeViewTests.Nodes.Clear();
      this.treeViewTests.Nodes.Add(string.IsNullOrEmpty(this.tunitProject.FileName) ? this.tunitProject.Name : this.tunitProject.FileName);
      foreach (var unitTest in this.tunitProject.UnitTests) {
        TreeNode unitTestNode = this.treeViewTests.Nodes[0].Nodes.Add(unitTest.FileName);
        unitTestNode.Name = unitTest.FileName;
        foreach (var testFixture in unitTest.TestFixtures) {
          TreeNode testFixtureNode = unitTestNode.Nodes.Add(testFixture.Name);
          testFixtureNode.Name = testFixture.Name;
          foreach (var test in testFixture.Tests) {
            TreeNode testNode = testFixtureNode.Nodes.Add(test.Name);
            testNode.Name = test.Name;
          }
        }
      }
      this.treeViewTests.ExpandAll();
      this.treeViewTests.SelectedNode = this.treeViewTests.Nodes[0];
      this.treeViewTests.ResumeLayout();
    }

    private void OnProjectAddTUnitFileClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Application Files (*.exe)|*.exe|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        if (!UnitTest.IsTUnitApplication(openFileDialog.FileName)) {
          MessageBox.Show($"{openFileDialog.FileName} is not a TUnit application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } else {
          this.tunitProject.AddUnitTest(openFileDialog.FileName);
          //this.ReloadTests(openFileDialog.FileName);
          this.ReloadProject();
        }
      }
    }

    private void OnFileExitClick(object sender, EventArgs e) {
      this.Close();
    }

    private void OnTestEnd(object sender, TestEventArgs e) {
      this.treeViewTests.Nodes[0].SelectedImageIndex = this.treeViewTests.Nodes[0].ImageIndex = (int)this.tunitProject.Status;
      TreeNode nodeFound = this.treeViewTests.Nodes[0].Nodes.Find(e.Test.TestFixture.UnitTest.FileName, false)[0];
      if (nodeFound != null) {
        nodeFound.SelectedImageIndex = nodeFound.ImageIndex = (int)e.Test.TestFixture.UnitTest.Status;
        nodeFound = nodeFound.Nodes.Find(e.Test.TestFixture.Name, false)[0];
        if (nodeFound != null) {
          nodeFound.SelectedImageIndex = nodeFound.ImageIndex = (int)e.Test.TestFixture.Status;
          nodeFound = nodeFound.Nodes.Find(e.Test.Name, false)[0];
          if (nodeFound != null)
            nodeFound.SelectedImageIndex = nodeFound.ImageIndex = (int)e.Test.Status;
        }
      }

      this.richTextBoxTextOutput.Text = string.Join(Environment.NewLine, this.tunitProject.TextOutput);
    }

    private void OnFileOpenClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Files (*.tunit)|*.tunit|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        this.tunitProject = new TUnitProject(openFileDialog.FileName);
        this.tunitProject.Load();
        this.tunitProject.TestEnd += this.OnTestEnd;
        this.ReloadProject();
      }
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e) {
      this.OnFileCloseClick(sender, EventArgs.Empty);
      e.Cancel = this.tunitProject != null;
    }

    private void OnFileCloseClick(object sender, EventArgs e) {
      if (this.tunitProject != null) {
        if (this.tunitProject.Saved) {
          this.tunitProject.TestEnd -= this.OnTestEnd;
          this.tunitProject = null;
          this.treeViewTests.Nodes.Clear();
        } else {
          DialogResult result = MessageBox.Show("Save current project before closing ?", "Save project", MessageBoxButtons.YesNoCancel);
          if (result == DialogResult.Yes) {
            OnFileSaveClick(sender, e);
            if (this.tunitProject.Saved) {
              this.tunitProject.TestEnd -= this.OnTestEnd;
              this.tunitProject = null;
              this.treeViewTests.Nodes.Clear();
            }
          }
          if (result == DialogResult.No) this.tunitProject = null;
        }
      }
    }

    private void OnFileSaveClick(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(this.tunitProject.FileName))
        OnFileSaveAsClick(sender, e);
      else if (!string.IsNullOrEmpty(this.tunitProject.FileName))
        this.tunitProject.Save();
    }

    private void OnFileSaveAsClick(object sender, EventArgs e) {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.FileName = $"{this.tunitProject.Name}.tunit";
      DialogResult result = saveFileDialog.ShowDialog();
      if (result == DialogResult.OK) this.tunitProject.FileName = saveFileDialog.FileName;

      if (!string.IsNullOrEmpty(this.tunitProject.FileName))
        this.tunitProject.Save();
    }

    private void OnFileNewClick(object sender, EventArgs e) {
      OnFileCloseClick(sender, e);
      if (this.tunitProject == null) {
        this.tunitProject = new TUnitProject();
        this.tunitProject.TestEnd += this.OnTestEnd;
        this.ReloadProject();
      }
    }

    private void OnApplicationIdle(object sender, EventArgs e) {
      this.closeToolStripMenuItem.Enabled = this.tunitProject != null;
      this.saveToolStripMenuItem.Enabled = this.tunitProject != null;
      this.saveAsToolStripMenuItem.Enabled = this.tunitProject != null;
      this.reloadProjectToolStripMenuItem.Enabled = this.tunitProject != null;
      this.statusBarToolStripMenuItem.Checked = this.statusStripMain.Visible;
      this.reloadTestToolStripMenuItem.Enabled = this.tunitProject != null;
      this.addTUnitFileToolStripMenuItem.Enabled = this.tunitProject != null;
      this.runAllToolStripMenuItem.Enabled = this.tunitProject != null;
      this.runSelectedToolStripMenuItem.Enabled = this.tunitProject != null;
      this.runFailedToolStripMenuItem.Enabled = this.tunitProject != null;
      this.panelRun.Enabled = this.tunitProject != null;
      this.buttonRun.Enabled = this.tunitProject != null;

      if (this.tunitProject == null) {
        this.panelRun.BackColor = System.Drawing.SystemColors.Control;
        this.labelRun.ForeColor = System.Drawing.SystemColors.ControlText;
        this.labelSelectedTest.ForeColor = System.Drawing.SystemColors.ControlText;
      } else {
        switch(this.tunitProject.Status) {
          case TestStatus.NotStarted: this.panelRun.BackColor = System.Drawing.Color.FromArgb(255, 95, 95, 95); break;
          case TestStatus.Succeed: this.panelRun.BackColor = System.Drawing.Color.FromArgb(255, 76, 175, 81); break;
          case TestStatus.Ignored: this.panelRun.BackColor = System.Drawing.Color.FromArgb(255, 195, 195, 195); break;
          case TestStatus.Aborted: this.panelRun.BackColor = System.Drawing.Color.FromArgb(255, 244, 243, 54); break;
          case TestStatus.Failed: this.panelRun.BackColor = System.Drawing.Color.FromArgb(255, 244, 67, 55); break;
        }

        if (this.tunitProject.Status == TestStatus.NotStarted) {
          this.labelRun.ForeColor = System.Drawing.Color.White;
          this.labelSelectedTest.ForeColor = System.Drawing.Color.White;
        }
      }

      if (this.tunitProject != null && this.Text != string.Format("{0} {1} - TUnit", string.IsNullOrEmpty(this.tunitProject.FileName) ? this.tunitProject.Name : System.IO.Path.GetFileNameWithoutExtension(this.tunitProject.FileName),  this.tunitProject.Saved ? "" : "* ")) this.Text = string.Format("{0}{1} - TUnit", string.IsNullOrEmpty(this.tunitProject.FileName) ? this.tunitProject.Name : System.IO.Path.GetFileNameWithoutExtension(this.tunitProject.FileName), this.tunitProject.Saved ? "" : "*");
      if (this.tunitProject == null && this.Text != "TUnit") this.Text = "TUnit";
    }

    private TUnitProject tunitProject = null;
    private TabPage errorsAndFailuresTabPage;
    private TabPage testsNotRunTabPage;
  }
}
