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
    }

    private void OnProjectFullGUIClick(object sender, EventArgs e) {
      this.fullGUIToolStripMenuItem.Checked = true;
      this.miniGUIToolStripMenuItem.Checked = false;
      this.splitContainerMain.Panel2Collapsed = false;
      this.Width = 800;
    }

    private void OnViewMiniGUIClick(object sender, EventArgs e) {
      this.fullGUIToolStripMenuItem.Checked = false;
      this.miniGUIToolStripMenuItem.Checked = true;
      this.splitContainerMain.Panel2Collapsed = true;
      this.Width = 400;
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

    private bool IsTUnitApplication(string fileName) {
      System.Diagnostics.Process process = new System.Diagnostics.Process();
      process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName, "--help");
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();
      if (process.WaitForExit(1000) == false) return false;
      if (!process.StandardOutput.ReadToEnd().StartsWith("This program contains tests written using xtd::tunit.")) return false;
      return true;
    }

    private string[] GetTUnitFixtures(string fileName) {
      System.Diagnostics.Process process = new System.Diagnostics.Process();
      process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName, "--list_tests");
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();
      process.WaitForExit();
      System.Collections.Generic.SortedSet<string> results = new System.Collections.Generic.SortedSet<string>();
      while (!process.StandardOutput.EndOfStream)
        results.Add(process.StandardOutput.ReadLine().Split('.')[0]);
      return results.ToArray();
    }

    private string[] GetTUnitTests(string fileName, string fixture) {
      System.Diagnostics.Process process = new System.Diagnostics.Process();
      process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName, "--list_tests");
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();
      process.WaitForExit();
      System.Collections.Generic.List<string> results = new System.Collections.Generic.List<string>();
      while (!process.StandardOutput.EndOfStream) {
        string[] fixtureTest = process.StandardOutput.ReadLine().Split('.');
        if (fixtureTest[0] == fixture)
          results.Add(fixtureTest[1]);
      }
      return results.ToArray();
    }

    private void ReloadProject() {
      this.treeViewTests.Nodes.Clear();
      this.treeViewTests.Nodes.Add(string.IsNullOrEmpty(this.currentFileName) ? this.currentProject.Name : this.currentFileName);
      foreach (var fileName in this.currentProject.Files) {
        ReloadTests(fileName);
      }
    }

    private void ReloadTests(string fileName) {
      TreeNode fileNameTreeNode = this.treeViewTests.Nodes[0].Nodes.ContainsKey(fileName) ? this.treeViewTests.Nodes[0].Nodes[this.treeViewTests.Nodes[0].Nodes.IndexOfKey(fileName)] : this.treeViewTests.Nodes[0].Nodes.Add(fileName);
      fileNameTreeNode.Nodes.Clear();
      foreach (var fixture in GetTUnitFixtures(fileName)) {
        TreeNode fixtureTreeNode = fileNameTreeNode.Nodes.Add(fixture);
        foreach (var test in GetTUnitTests(fileName, fixture)) {
          fixtureTreeNode.Nodes.Add(test);
        }
      }
    }

    private void OnProjectAddTUnitFileClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Application Files (*.exe)|*.exe|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        if (!IsTUnitApplication(openFileDialog.FileName)) {
          MessageBox.Show($"{openFileDialog.FileName} is not a TUnit application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } else {
          this.currentProject.Files = this.currentProject.Files.Append(openFileDialog.FileName).ToArray();
          this.ReloadTests(openFileDialog.FileName);
        }
      }
    }

    private void OnFileExitClick(object sender, EventArgs e) {
      this.Close();
    }

    private void OnFileOpenClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Files (*.tunit)|*.tunit|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        this.currentFileName = openFileDialog.FileName;
        this.currentProject = TUnitProject.Read(this.currentFileName);
        this.ReloadProject();
      }
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e) {
      this.OnFileCloseClick(sender, EventArgs.Empty);
      e.Cancel = this.currentProject != null;
    }

    private void OnFileCloseClick(object sender, EventArgs e) {
      if (this.currentProject != null) {
        if (this.currentProject.Saved) {
          this.currentProject = null;
          this.currentFileName = null;
        }
        else {
          DialogResult result = MessageBox.Show("Save current project before closing ?", "Save project", MessageBoxButtons.YesNoCancel);
          if (result == DialogResult.Yes) {
            OnFileSaveClick(sender, e);
            if (this.currentProject.Saved) {
              this.currentProject = null;
              this.currentFileName = null;
            }
          }
          if (result == DialogResult.No) this.currentProject = null;
        }
      }
    }

    private void OnFileSaveClick(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(this.currentFileName))
        OnFileSaveAsClick(sender, e);
      else if (!string.IsNullOrEmpty(this.currentFileName))
        TUnitProject.Write(this.currentFileName, this.currentProject);
    }

    private void OnFileSaveAsClick(object sender, EventArgs e) {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.FileName = $"{this.currentProject.Name}.tunit";
      DialogResult result = saveFileDialog.ShowDialog();
      if (result == DialogResult.OK) this.currentFileName = saveFileDialog.FileName;

      if (!string.IsNullOrEmpty(this.currentFileName))
        TUnitProject.Write(this.currentFileName, this.currentProject);
    }

    private void OnFileNewClick(object sender, EventArgs e) {
      OnFileCloseClick(sender, e);
      if (this.currentProject == null) {
        this.currentProject = new TUnitProject();
        this.ReloadProject();
      }
    }

    private int GetTestsCount() {
      int result = 0;
      foreach (var file in this.currentProject.Files)
        foreach (var fixture in this.GetTUnitFixtures(file))
          result += GetTUnitTests(file, fixture).Length;
      return result;
    }

    private void OnApplicationIdle(object sender, EventArgs e) {
      this.closeToolStripMenuItem.Enabled = this.currentProject != null;
      this.saveToolStripMenuItem.Enabled = this.currentProject != null;
      this.saveAsToolStripMenuItem.Enabled = this.currentProject != null;
      this.reloadProjectToolStripMenuItem.Enabled = this.currentProject != null;
      this.reloadTestToolStripMenuItem.Enabled = this.currentProject != null;
      this.addTUnitFileToolStripMenuItem.Enabled = this.currentProject != null;

      if (currentProject != null && this.Text != string.Format("{0} {1} - TUnit", string.IsNullOrEmpty(this.currentFileName) ? this.currentProject.Name : System.IO.Path.GetFileNameWithoutExtension(this.currentFileName),  this.currentProject.Saved ? "" : "* ")) this.Text = string.Format("{0}{1} - TUnit", string.IsNullOrEmpty(this.currentFileName) ? this.currentProject.Name : System.IO.Path.GetFileNameWithoutExtension(this.currentFileName), this.currentProject.Saved ? "" : "*");
      if (currentProject == null && this.Text != "TUnit") this.Text = "TUnit";
    }

    private TUnitProject currentProject = null;
    private string currentFileName = null;
    private TabPage errorsAndFailuresTabPage;
    private TabPage testsNotRunTabPage;
  }
}
