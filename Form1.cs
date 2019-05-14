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
      this.exitToolStripMenuItem.Click += this.OnFileExitClick;
      this.addTUnitFileToolStripMenuItem.Click += this.OnProjectAddTUnitFileClick;
      this.errorsFailuresToolStripMenuItem.Click += this.OnViewErrorsAndFailuresClick;
      this.testsNotRunToolStripMenuItem.Click += this.OnTestsNotRunClick;
      this.statusBarToolStripMenuItem.Click += this.OnViewStatusBarClick;
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
      this.statusStrip1.Visible = !this.statusStrip1.Visible;
    }

    private void OnProjectAddTUnitFileClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Application Files (*.exe)|*.exe|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        this.currentProject.Files = this.currentProject.Files.Append(openFileDialog.FileName).ToArray(); ;
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
        this.currentFileBName = openFileDialog.FileName;
        this.currentProject = TUnitProject.Read(this.currentFileBName);
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
          this.currentFileBName = null;
        }
        else {
          DialogResult result = MessageBox.Show("Save current project before closing ?", "Save project", MessageBoxButtons.YesNoCancel);
          if (result == DialogResult.Yes) {
            OnFileSaveClick(sender, e);
            if (this.currentProject.Saved) {
              this.currentProject = null;
              this.currentFileBName = null;
            }
          }
          if (result == DialogResult.No) this.currentProject = null;
        }
      }
    }

    private void OnFileSaveClick(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(this.currentFileBName)) {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.FileName = $"{this.currentProject.Name}.tunit";
        DialogResult result = saveFileDialog.ShowDialog();
        if (result == DialogResult.OK) this.currentFileBName = saveFileDialog.FileName;
      }

      if (!string.IsNullOrEmpty(this.currentFileBName))
        TUnitProject.Write(this.currentFileBName, this.currentProject);
    }

    private void OnFileNewClick(object sender, EventArgs e) {
      OnFileCloseClick(sender, e);
      if (this.currentProject == null)
        this.currentProject = new TUnitProject();
    }

    private void OnApplicationIdle(object sender, EventArgs e) {
      this.closeToolStripMenuItem.Enabled = this.currentProject != null;
      this.saveToolStripMenuItem.Enabled = this.currentProject != null;
      this.saveAsToolStripMenuItem.Enabled = this.currentProject != null;
      this.reloadProjectToolStripMenuItem.Enabled = this.currentProject != null;
      this.reloadTestToolStripMenuItem.Enabled = this.currentProject != null;

      if (currentProject != null && this.Text != string.Format("{0} {1} - TUnit", this.currentProject.Name,  this.currentProject.Saved ? "" : "* ")) this.Text = string.Format("{0}{1} - TUnit", this.currentProject.Name, this.currentProject.Saved ? "" : "*");
      if (currentProject == null && this.Text != "TUnit") this.Text = "TUnit";
    }

    private TUnitProject currentProject = null;
    private string currentFileBName = null;
    private TabPage errorsAndFailuresTabPage;
    private TabPage testsNotRunTabPage;
  }
}
