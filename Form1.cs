using System;
using System.Linq;
using System.Windows.Forms;

namespace tunit_gui {
  public partial class FormMain : Form {
    public FormMain() {
      InitializeComponent();

      Application.Idle += this.OnApplicationIdle;
      this.FormClosing += this.OnFormClosing;
      this.openToolStripMenuItem.Click += this.OnOpenClick;
      this.newToolStripMenuItem.Click += this.OnNewToolStripMenuItemClick;
      this.closeToolStripMenuItem.Click += this.OnCloseToolStripMenuItemClick;
      this.saveToolStripMenuItem.Click += this.OnSaveClick;
      this.exitToolStripMenuItem.Click += this.OnCloseClick;
      this.addTUnitFileToolStripMenuItem.Click += this.OnAddTUnitFileClick;
    }

    private void OnAddTUnitFileClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Application Files (*.exe)|*.exe|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        this.currentProject.Files = this.currentProject.Files.Append(openFileDialog.FileName).ToArray(); ;
      }
    }

    private void OnCloseClick(object sender, EventArgs e) {
      this.Close();
    }

    private void OnOpenClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Files (*.tunit)|*.tunit|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        this.currentFileBName = openFileDialog.FileName;
        this.currentProject = TUnitProject.Read(this.currentFileBName);
      }
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e) {
      this.OnCloseToolStripMenuItemClick(sender, EventArgs.Empty);
      e.Cancel = this.currentProject != null;
    }

    private void OnCloseToolStripMenuItemClick(object sender, EventArgs e) {
      if (this.currentProject != null) {
        if (this.currentProject.Saved) {
          this.currentProject = null;
          this.currentFileBName = null;
        }
        else {
          DialogResult result = MessageBox.Show("Save current project before closing ?", "Save project", MessageBoxButtons.YesNoCancel);
          if (result == DialogResult.Yes) {
            OnSaveClick(sender, e);
            if (this.currentProject.Saved) {
              this.currentProject = null;
              this.currentFileBName = null;
            }
          }
          if (result == DialogResult.No) this.currentProject = null;
        }
      }
    }

    private void OnSaveClick(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(this.currentFileBName)) {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.FileName = $"{this.currentProject.Name}.tunit";
        DialogResult result = saveFileDialog.ShowDialog();
        if (result == DialogResult.OK) this.currentFileBName = saveFileDialog.FileName;
      }

      if (!string.IsNullOrEmpty(this.currentFileBName))
        TUnitProject.Write(this.currentFileBName, this.currentProject);
    }

    private void OnNewToolStripMenuItemClick(object sender, EventArgs e) {
      OnCloseToolStripMenuItemClick(sender, e);
      if (this.currentProject == null)
        this.currentProject = new TUnitProject();
    }

    private void OnApplicationIdle(object sender, EventArgs e) {
      this.closeToolStripMenuItem.Enabled = this.currentProject != null;
      this.saveToolStripMenuItem.Enabled = this.currentProject != null;
      this.saveAsToolStripMenuItem.Enabled = this.currentProject != null;
      this.reloadProjectToolStripMenuItem.Enabled = this.currentProject != null;
      this.reloadTestToolStripMenuItem.Enabled = this.currentProject != null;

      this.statusBarToolStripMenuItem.Checked = this.statusStrip1.Visible;

      if (currentProject != null && this.Text != string.Format("{0} {1} - TUnit", this.currentProject.Name,  this.currentProject.Saved ? "" : "* ")) this.Text = string.Format("{0}{1} - TUnit", this.currentProject.Name, this.currentProject.Saved ? "" : "*");
      if (currentProject == null && this.Text != "TUnit") this.Text = "TUnit";
    }

    private TUnitProject currentProject = null;
    private string currentFileBName = null;
  }
}
