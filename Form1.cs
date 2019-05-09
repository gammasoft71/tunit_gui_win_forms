using System;
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
      this.saveToolStripMenuItem.Click += this.OnSaveToolStripMenuItemClick;
      this.exitToolStripMenuItem.Click += this.OnCloseClick;
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
        if (this.currentProject.Saved)
          this.currentProject = null;
        else {
          DialogResult result = MessageBox.Show("Save current project before closing ?", "Save project", MessageBoxButtons.YesNoCancel);
          if (result == DialogResult.Yes) {
            OnSaveToolStripMenuItemClick(sender, e);
            if (this.currentProject.Saved) this.currentProject = null;
          }
          if (result == DialogResult.No) this.currentProject = null;
        }
      }
    }

    private void OnSaveToolStripMenuItemClick(object sender, EventArgs e) {
      if (this.currentFileBName == null) {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.FileName = $"{this.currentProject.Name}.tunit";
        DialogResult result = saveFileDialog.ShowDialog();
        if (result == DialogResult.OK) this.currentFileBName = saveFileDialog.FileName;
      }

      if (this.currentFileBName != null)
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
