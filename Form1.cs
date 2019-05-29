using System;
using System.Linq;
using System.Windows.Forms;

namespace tunit {
  public partial class FormMain : Form {
    public FormMain() {
      InitializeComponent();

      this.ClientSize = new System.Drawing.Size(850, 525);

      Application.Idle += this.OnApplicationIdle;
      this.FormClosing += this.OnFormClosing;

      this.textOutputTabPage = this.tabControlResults.TabPages[0];
      this.succeedTestsTabPage = this.tabControlResults.TabPages[1];
      this.ignoredTestsTabPage = this.tabControlResults.TabPages[2];
      this.abortedTestsTabPage = this.tabControlResults.TabPages[3];
      this.failedTestsTabPage = this.tabControlResults.TabPages[4];

      this.textOutputTabPage.Tag = 0;
      this.succeedTestsTabPage.Tag = 1;
      this.ignoredTestsTabPage.Tag = 2;
      this.abortedTestsTabPage.Tag = 3;
      this.failedTestsTabPage.Tag = 4;

      this.tabControlResults.TabPages.Remove(textOutputTabPage);
      this.tabControlResults.TabPages.Remove(succeedTestsTabPage);
      this.tabControlResults.TabPages.Remove(ignoredTestsTabPage);
      this.tabControlResults.TabPages.Remove(abortedTestsTabPage);


      this.newToolStripMenuItem.Click += this.OnFileNewClick;
      this.openToolStripMenuItem.Click += this.OnFileOpenClick;
      this.closeToolStripMenuItem.Click += this.OnFileCloseClick;
      this.saveToolStripMenuItem.Click += this.OnFileSaveClick;
      this.saveAsToolStripMenuItem.Click += this.OnFileSaveAsClick;
      this.reloadProjectToolStripMenuItem.Click += this.OnReloadProjectClick;
      this.exitToolStripMenuItem.Click += this.OnFileExitClick;
      this.addTUnitFileToolStripMenuItem.Click += this.OnProjectAddTUnitFileClick;
      this.fullGUIToolStripMenuItem.Click += this.OnProjectFullGUIClick;
      this.miniGUIToolStripMenuItem.Click += this.OnViewMiniGUIClick;
      this.textOutputToolStripMenuItem.Click += this.OnViewTextOutputClick;
      this.succeedTestsToolStripMenuItem.Click += this.OnSucceedTestsClick;
      this.ignoredTestsToolStripMenuItem.Click += this.OnIgnoredTestsClick;
      this.abortedTestsToolStripMenuItem.Click += this.OnAbortedTestsClick;
      this.failedTestsToolStripMenuItem.Click += this.OnViewFailedTestsClick;
      this.statusBarToolStripMenuItem.Click += this.OnViewStatusBarClick;
      this.treeViewTests.AfterSelect += this.OnTreeViewTestsAfterSelect;
      this.runAllToolStripMenuItem.Click += this.OnRunAllTestsClick;
      this.runSelectedToolStripMenuItem.Click += this.OnRunSelectedTestsClick;
      this.runFailedToolStripMenuItem.Click += this.OnRunFailedTestsClick;
      this.stopRunToolStripMenuItem.Click += this.OnStopTestsClick;
      this.aboutToolStripMenuItem.Click += this.OnAboutClick;
      this.buttonRun.Click += this.OnRunSelectedTestsClick;
      this.buttonStop.Click += this.OnStopTestsClick;
      this.timerUpdateGui.Tick += this.OnTimerUpdateGuidTick;
    }

    private void OnTimerUpdateGuidTick(object sender, EventArgs e) {
      this.UpdateGui();
    }

    private void OnAboutClick(object sender, EventArgs e) {
      AboutBox aboutBox = new AboutBox();
      aboutBox.ShowDialog(this);
    }

    private void OnReloadProjectClick(object sender, EventArgs e) {
      this.ReloadProject();
    }

    private void OnRunSelectedTestsClick(object sender, EventArgs e) {
      TreeNode treeNode = this.treeViewTests.SelectedNode;
      if (treeNode != null) {
        this.ResetProject();
        if (treeNode.Tag is TUnitProject) {
          this.progressBarRun.Maximum = this.tunitProject.TestCount;
          this.tunitProject.Run();
        } else if (treeNode.Tag is UnitTest) {
          this.progressBarRun.Maximum = (treeNode.Tag as UnitTest).TestCount;
          this.tunitProject.Run(treeNode.Tag as UnitTest);
        } else if (treeNode.Tag is TestFixture) {
          this.progressBarRun.Maximum = (treeNode.Tag as TestFixture).TestCount;
          this.tunitProject.Run(treeNode.Tag as TestFixture);
        } else if (treeNode.Tag is Test) {
          this.progressBarRun.Maximum = 1;
          this.tunitProject.Run(treeNode.Tag as Test);
        }
      }
    }

    private void OnRunAllTestsClick(object sender, EventArgs e) {
      this.progressBarRun.Maximum = this.tunitProject.TestCount;
      this.ResetProject();
      this.tunitProject.Run();
    }

    private void OnRunFailedTestsClick(object sender, EventArgs e) {
      this.progressBarRun.Value = 0;
      this.progressBarRun.Maximum = this.tunitProject.FailedCount;
      this.treeViewFailedTests.Nodes.Clear();
      foreach (TreeNode nodeTUnitProject in this.treeViewTests.Nodes) {
        foreach (TreeNode nodeUnitTest in nodeTUnitProject.Nodes) {
          foreach (TreeNode nodeTestFixture in nodeUnitTest.Nodes) {
            foreach (TreeNode nodeTest in nodeTestFixture.Nodes) {
              if ((nodeTest.Tag as Test).Status == TestStatus.Failed) {
                this.tunitProject.Run(nodeTest.Tag as Test);
              }
            }
          }
        }
      }
    }

    private void OnStopTestsClick(object sender, EventArgs e) {
      this.tunitProject.Stop();
    }

    private void OnTreeViewTestsAfterSelect(object sender, TreeViewEventArgs e) {
      this.labelSelectedTest.Text = this.treeViewTests.SelectedNode.Text;
    }

    private void OnProjectFullGUIClick(object sender, EventArgs e) {
      this.fullGUIToolStripMenuItem.Checked = true;
      this.miniGUIToolStripMenuItem.Checked = false;
      this.splitContainerMain.Panel2Collapsed = false;
      this.statusStripMain.Visible = true;
      this.ClientSize = new System.Drawing.Size(850, 525);
    }

    private void OnViewMiniGUIClick(object sender, EventArgs e) {
      this.fullGUIToolStripMenuItem.Checked = false;
      this.miniGUIToolStripMenuItem.Checked = true;
      this.splitContainerMain.Panel2Collapsed = true;
      this.statusStripMain.Visible = false;
      this.ClientSize = new System.Drawing.Size(324, 525);
    }

    private void AddTabPageToTabControlResult(TabPage tabPage) {
      int indexToInsert = 0;
      foreach (TabPage item in this.tabControlResults.TabPages)
        if ((Int32)item.Tag < (Int32)tabPage.Tag) indexToInsert++;
      this.tabControlResults.TabPages.Insert(indexToInsert, tabPage);
    }

    private void OnViewTextOutputClick(object sender, EventArgs e) {
      if (this.textOutputToolStripMenuItem.Checked)
        AddTabPageToTabControlResult(textOutputTabPage);
      else
        this.tabControlResults.TabPages.Remove(textOutputTabPage);
    }

    private void OnSucceedTestsClick(object sender, EventArgs e) {
      if (this.succeedTestsToolStripMenuItem.Checked)
        AddTabPageToTabControlResult(succeedTestsTabPage);
      else
        this.tabControlResults.TabPages.Remove(succeedTestsTabPage);
    }

    private void OnIgnoredTestsClick(object sender, EventArgs e) {
      if (this.ignoredTestsToolStripMenuItem.Checked)
        AddTabPageToTabControlResult(ignoredTestsTabPage);
      else
        this.tabControlResults.TabPages.Remove(ignoredTestsTabPage);
    }

    private void OnAbortedTestsClick(object sender, EventArgs e) {
      if (this.abortedTestsToolStripMenuItem.Checked)
        AddTabPageToTabControlResult(abortedTestsTabPage);
      else
        this.tabControlResults.TabPages.Remove(abortedTestsTabPage);
    }

    private void OnViewFailedTestsClick(object sender, EventArgs e) {
      if (this.failedTestsToolStripMenuItem.Checked)
        AddTabPageToTabControlResult(failedTestsTabPage);
      else
        this.tabControlResults.TabPages.Remove(failedTestsTabPage);
    }

    private void OnViewStatusBarClick(object sender, EventArgs e) {
      this.statusStripMain.Visible = !this.statusStripMain.Visible;
    }

    private void ReloadProject() {
      this.tunitProject.Reset();
      this.progressBarRun.Value = 0;
      this.progressBarRun.Maximum = this.tunitProject.TestCount;
      this.richTextBoxTextOutput.Text = "";
      this.treeViewTests.SuspendLayout();
      this.treeViewSucceedTests.Nodes.Clear();
      this.treeViewIgnoredTests.Nodes.Clear();
      this.treeViewAbortedTests.Nodes.Clear();
      this.treeViewFailedTests.Nodes.Clear();
      this.treeViewTests.Nodes.Clear();
      this.treeViewTests.Nodes.Add(string.IsNullOrEmpty(this.tunitProject.FileName) ? this.tunitProject.Name : this.tunitProject.FileName);
      this.treeViewTests.Nodes[0].Tag = this.tunitProject;
      foreach (var unitTest in this.tunitProject.UnitTests) {
        TreeNode unitTestNode = this.treeViewTests.Nodes[0].Nodes.Add(unitTest.FileName);
        unitTestNode.Name = unitTest.FileName;
        unitTestNode.Tag = unitTest;
        foreach (var testFixture in unitTest.TestFixtures) {
          TreeNode testFixtureNode = unitTestNode.Nodes.Add(testFixture.Name);
          testFixtureNode.Name = testFixture.Name;
          testFixtureNode.Tag = testFixture;
          foreach (var test in testFixture.Tests) {
            TreeNode testNode = testFixtureNode.Nodes.Add(test.Name);
            testNode.Name = test.Name;
            testNode.Tag = test;
          }
        }
      }
      this.treeViewTests.ExpandAll();
      this.treeViewTests.SelectedNode = this.treeViewTests.Nodes[0];
      this.treeViewTests.ResumeLayout();
    }

    private void ResetProject() {
      this.tunitProject.Reset();
      this.progressBarRun.Value = 0;
      this.progressBarRun.Maximum = this.tunitProject.TestCount;
      this.treeViewSucceedTests.Nodes.Clear();
      this.treeViewIgnoredTests.Nodes.Clear();
      this.treeViewAbortedTests.Nodes.Clear();
      this.treeViewFailedTests.Nodes.Clear();
      this.richTextBoxTextOutput.Text = "";
      this.treeViewTests.SuspendLayout();
      foreach(TreeNode node1 in this.treeViewTests.Nodes) {
        if (node1.ImageIndex != (int)TestStatus.NotStarted) node1.ImageIndex = node1.SelectedImageIndex = (int)TestStatus.NotStarted;
        foreach (TreeNode node2 in node1.Nodes) {
          if (node2.ImageIndex != (int)TestStatus.NotStarted) node2.ImageIndex = node2.SelectedImageIndex = (int)TestStatus.NotStarted;
          foreach (TreeNode node3 in node2.Nodes) {
            if (node3.ImageIndex != (int)TestStatus.NotStarted) node3.ImageIndex = node3.SelectedImageIndex = (int)TestStatus.NotStarted;
            foreach (TreeNode node4 in node3.Nodes) {
              if (node4.ImageIndex != (int)TestStatus.NotStarted) node4.ImageIndex = node4.SelectedImageIndex = (int)TestStatus.NotStarted;
            }
          }
        }
      }
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
      if (this.treeViewTests.Nodes[0].ImageIndex != (int)this.tunitProject.Status) this.treeViewTests.Nodes[0].SelectedImageIndex = this.treeViewTests.Nodes[0].ImageIndex = (int)this.tunitProject.Status;
      TreeNode nodeFound = this.treeViewTests.Nodes[0].Nodes.Find(e.Test.TestFixture.UnitTest.FileName, false)[0];
      if (nodeFound != null) {
        if (nodeFound.ImageIndex != (int)e.Test.TestFixture.UnitTest.Status) nodeFound.SelectedImageIndex = nodeFound.ImageIndex = (int)e.Test.TestFixture.UnitTest.Status;
        nodeFound = nodeFound.Nodes.Find(e.Test.TestFixture.Name, false)[0];
        if (nodeFound != null) {
          if (nodeFound.ImageIndex != (int)e.Test.TestFixture.Status) nodeFound.SelectedImageIndex = nodeFound.ImageIndex = (int)e.Test.TestFixture.Status;
          nodeFound = nodeFound.Nodes.Find(e.Test.Name, false)[0];
          if (nodeFound != null) {
            if (nodeFound.ImageIndex != (int)e.Test.Status) nodeFound.SelectedImageIndex = nodeFound.ImageIndex = (int)e.Test.Status;
          }
        }
      }

      TreeNode treeNode = null;

      switch (e.Test.Status) {
        case TestStatus.Succeed: treeNode = this.treeViewSucceedTests.Nodes.Add($"{e.Test.TestFixture.Name}.{e.Test.Name}"); break;
        case TestStatus.Ignored: treeNode = this.treeViewIgnoredTests.Nodes.Add($"{e.Test.TestFixture.Name}.{e.Test.Name}"); break;
        case TestStatus.Aborted: treeNode = this.treeViewAbortedTests.Nodes.Add($"{e.Test.TestFixture.Name}.{e.Test.Name}"); break;
        case TestStatus.Failed: treeNode = this.treeViewFailedTests.Nodes.Add($"{e.Test.TestFixture.Name}.{e.Test.Name}"); break;
      }

      if (treeNode != null) {
        treeNode.Nodes.Add($"File : {e.Test.TestFixture.UnitTest.FileName}");
        if (!string.IsNullOrEmpty(e.Test.StackTrace))
          treeNode.Nodes.Add($"StackTrace : {e.Test.StackTrace}");
      }

      this.progressBarRun.Increment(1);
      //Application.DoEvents();
    }

    private void OnTUnitProjectStart(object sender, EventArgs e) {
      this.running = true;
      this.stopWatch.Reset();
      this.stopWatch.Start();
      this.timerUpdateGui.Enabled = true;
      this.UpdateGui();
      Application.DoEvents();
    }

    private void OnTUnitProjectEnd(object sender, EventArgs e) {
      this.running = false;
      this.stopWatch.Stop();
      this.timerUpdateGui.Enabled = false;
      this.richTextBoxTextOutput.Text = string.Join(Environment.NewLine, this.tunitProject.TextOutput);
      this.UpdateGui();
      Application.DoEvents();
    }

    private void OnFileOpenClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Files (*.tunit)|*.tunit|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        OnFileCloseClick(sender, e);
        if (this.tunitProject == null) {
          this.Enabled = false;
          this.SuspendLayout();
          this.tunitProject = new TUnitProject(openFileDialog.FileName);
          this.tunitProject.Load();
          this.tunitProject.TestEnd += this.OnTestEnd;
          this.tunitProject.TUnitProjectStart += this.OnTUnitProjectStart;
          this.tunitProject.TUnitProjectEnd += this.OnTUnitProjectEnd;
          this.ReloadProject();
          this.Enabled = true;
          this.ResumeLayout();
        }
      }
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e) {
      this.OnFileCloseClick(sender, EventArgs.Empty);
      e.Cancel = this.tunitProject != null;
    }

    private void CloseProject() {
      this.Enabled = false;
      this.progressBarRun.Value = 0;
      this.labelColor.BackColor = System.Drawing.SystemColors.Control;
      this.toolStripStatusLabelTestCases.Text = "Test Cases : 0";
      this.toolStripStatusLabelRanTests.Text = "Ran Tests : 0";
      this.toolStripStatusLabelSucceedTests.Text = "Succeed Tests : 0";
      this.toolStripStatusLabelIgnoredTests.Text = "Ignored Tests : 0";
      this.toolStripStatusLabelAbortedTests.Text = "Aborted Tests : 0";
      this.toolStripStatusLabelFailedTests.Text = "Failed Tests : 0";
      this.toolStripStatusLabelTestsDuration.Text = $"Time : {TimeSpan.Zero}";
      this.tunitProject.TestEnd -= this.OnTestEnd;
      this.tunitProject.TUnitProjectStart -= this.OnTUnitProjectStart;
      this.tunitProject.TUnitProjectEnd -= this.OnTUnitProjectEnd;
      this.tunitProject = null;
      Application.DoEvents();
      this.treeViewTests.Nodes.Clear();
      this.Enabled = true;
    }

    private void OnFileCloseClick(object sender, EventArgs e) {
      if (this.tunitProject != null) {
        if (this.tunitProject.Saved) {
          this.CloseProject();
        } else {
          DialogResult result = MessageBox.Show("Save current project before closing ?", "Save project", MessageBoxButtons.YesNoCancel);
          if (result == DialogResult.Yes) {
            OnFileSaveClick(sender, e);
            if (this.tunitProject.Saved) {
              this.CloseProject();
            }
          }
          if (result == DialogResult.No) {
            this.tunitProject = null;
            this.treeViewTests.Nodes.Clear();
          }
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
        this.tunitProject.New();
        this.tunitProject.TestEnd += this.OnTestEnd;
        this.tunitProject.TUnitProjectStart += this.OnTUnitProjectStart;
        this.tunitProject.TUnitProjectEnd += this.OnTUnitProjectEnd;
        this.ReloadProject();
      }
    }

    private void UpdateGui() {
      this.closeToolStripMenuItem.Enabled = this.tunitProject != null;
      this.saveToolStripMenuItem.Enabled = this.tunitProject != null;
      this.saveAsToolStripMenuItem.Enabled = this.tunitProject != null;
      this.reloadProjectToolStripMenuItem.Enabled = this.tunitProject != null;
      this.statusBarToolStripMenuItem.Checked = this.statusStripMain.Visible;
      this.reloadTestToolStripMenuItem.Enabled = this.tunitProject != null;
      this.addTUnitFileToolStripMenuItem.Enabled = this.tunitProject != null;
      this.runAllToolStripMenuItem.Enabled = this.tunitProject != null && !this.running;
      this.runSelectedToolStripMenuItem.Enabled = this.tunitProject != null && !this.running;
      this.runFailedToolStripMenuItem.Enabled = this.tunitProject != null && this.tunitProject.FailedCount != 0 && !this.running;
      this.stopRunToolStripMenuItem.Enabled = this.tunitProject != null && this.running;
      this.panelRun.Enabled = this.tunitProject != null;
      this.buttonRun.Enabled = this.tunitProject != null && !this.running;
      this.buttonStop.Enabled = this.tunitProject != null && this.running;
      this.numericUpDownRepeat.Enabled = !this.checkBoxForever.Checked;
      this.textBoxSeed.Enabled = this.checkBoxShuffle.Checked;

      if (this.tunitProject == null) {
        this.toolStripStatusLabelTestCases.Text = "Test Cases : 0";
        this.toolStripStatusLabelRanTests.Text = "Ran Tests : 0";
        this.toolStripStatusLabelSucceedTests.Text = "Succeed Tests : 0";
        this.toolStripStatusLabelIgnoredTests.Text = "Ignored Tests : 0";
        this.toolStripStatusLabelAbortedTests.Text = "Aborted Tests : 0";
        this.toolStripStatusLabelFailedTests.Text = "Failed Tests : 0";
        this.toolStripStatusLabelTestsDuration.Text = $"Time : {TimeSpan.Zero}";

        this.labelColor.BackColor = System.Drawing.SystemColors.Control;
      } else {
        this.toolStripStatusLabelTestCases.Text = $"Test Cases : {this.tunitProject.TestCount}";
        this.toolStripStatusLabelRanTests.Text = $"Ran Tests : {this.tunitProject.RanCount}";
        this.toolStripStatusLabelSucceedTests.Text = $"Succeed Tests : {this.tunitProject.SucceedCount}";
        this.toolStripStatusLabelIgnoredTests.Text = $"Ignored Tests : {this.tunitProject.IngoredCount}";
        this.toolStripStatusLabelAbortedTests.Text = $"Aborted Tests : {this.tunitProject.AbortedCount}";
        this.toolStripStatusLabelFailedTests.Text = $"Failed Tests : {this.tunitProject.FailedCount}";
        //this.toolStripStatusLabelTestsDuration.Text = $"Time : {this.tunitProject.ElapsedTime}";
        this.toolStripStatusLabelTestsDuration.Text = $"Time : {this.stopWatch.Elapsed}";

        switch (this.tunitProject.Status) {
          case TestStatus.NotStarted: this.labelColor.BackColor = System.Drawing.Color.FromArgb(255, 95, 95, 95); break;
          case TestStatus.Succeed: this.labelColor.BackColor = System.Drawing.Color.FromArgb(255, 76, 175, 81); break;
          case TestStatus.Ignored: this.labelColor.BackColor = System.Drawing.Color.FromArgb(255, 244, 243, 54); break;
          case TestStatus.Aborted: this.labelColor.BackColor = System.Drawing.Color.FromArgb(255, 195, 195, 195); break;
          case TestStatus.Failed: this.labelColor.BackColor = System.Drawing.Color.FromArgb(255, 244, 67, 55); break;
        }
      }

      if (this.tunitProject != null && this.Text != string.Format("{0} {1} - TUnit", string.IsNullOrEmpty(this.tunitProject.FileName) ? this.tunitProject.Name : System.IO.Path.GetFileNameWithoutExtension(this.tunitProject.FileName), this.tunitProject.Saved ? "" : "* ")) this.Text = string.Format("{0}{1} - TUnit", string.IsNullOrEmpty(this.tunitProject.FileName) ? this.tunitProject.Name : System.IO.Path.GetFileNameWithoutExtension(this.tunitProject.FileName), this.tunitProject.Saved ? "" : "*");
      if (this.tunitProject == null && this.Text != "TUnit") this.Text = "TUnit";
    }

    private void OnApplicationIdle(object sender, EventArgs e) {
      UpdateGui();
    }

    private TUnitProject tunitProject = null;
    private TabPage succeedTestsTabPage;
    private TabPage ignoredTestsTabPage;
    private TabPage abortedTestsTabPage;
    private TabPage failedTestsTabPage;
    private TabPage textOutputTabPage;
    private bool running = false;
    private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
  }
}
