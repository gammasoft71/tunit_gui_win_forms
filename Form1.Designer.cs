namespace tunit_gui
{
  partial class FormMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.splitContainerMain = new System.Windows.Forms.SplitContainer();
      this.tabControlTests = new System.Windows.Forms.TabControl();
      this.tabPageTests = new System.Windows.Forms.TabPage();
      this.treeViewTests = new System.Windows.Forms.TreeView();
      this.tabPageCategories = new System.Windows.Forms.TabPage();
      this.panelRun = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.labelRun = new System.Windows.Forms.Label();
      this.progressBarRun = new System.Windows.Forms.ProgressBar();
      this.buttonStop = new System.Windows.Forms.Button();
      this.buttonRun = new System.Windows.Forms.Button();
      this.tabControlResults = new System.Windows.Forms.TabControl();
      this.tabPageErrorsAndFailures = new System.Windows.Forms.TabPage();
      this.panel1 = new System.Windows.Forms.Panel();
      this.richTextBoxStackTrace = new System.Windows.Forms.RichTextBox();
      this.richTextBoxErrorsAndFailures = new System.Windows.Forms.RichTextBox();
      this.tabPageTestsNotRun = new System.Windows.Forms.TabPage();
      this.treeViewTestsNotRun = new System.Windows.Forms.TreeView();
      this.tabPageTextOutput = new System.Windows.Forms.TabPage();
      this.richTextBoxTextOutput = new System.Windows.Forms.RichTextBox();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.reloadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reloadTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.recentProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tUnitHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.runAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.runSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.runFailedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
      this.stopRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fullGUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.miniGUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
      this.resultTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.errorsFailuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.testsNotRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
      this.testOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
      this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
      this.splitContainerMain.Panel1.SuspendLayout();
      this.splitContainerMain.Panel2.SuspendLayout();
      this.splitContainerMain.SuspendLayout();
      this.tabControlTests.SuspendLayout();
      this.tabPageTests.SuspendLayout();
      this.panelRun.SuspendLayout();
      this.tabControlResults.SuspendLayout();
      this.tabPageErrorsAndFailures.SuspendLayout();
      this.tabPageTestsNotRun.SuspendLayout();
      this.tabPageTextOutput.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainerMain
      // 
      this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainerMain.Location = new System.Drawing.Point(0, 27);
      this.splitContainerMain.Name = "splitContainerMain";
      // 
      // splitContainerMain.Panel1
      // 
      this.splitContainerMain.Panel1.Controls.Add(this.tabControlTests);
      this.splitContainerMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      // 
      // splitContainerMain.Panel2
      // 
      this.splitContainerMain.Panel2.Controls.Add(this.panelRun);
      this.splitContainerMain.Panel2.Controls.Add(this.tabControlResults);
      this.splitContainerMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainerMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainerMain.Size = new System.Drawing.Size(800, 398);
      this.splitContainerMain.SplitterDistance = 266;
      this.splitContainerMain.TabIndex = 0;
      // 
      // tabControlTests
      // 
      this.tabControlTests.Alignment = System.Windows.Forms.TabAlignment.Left;
      this.tabControlTests.Controls.Add(this.tabPageTests);
      this.tabControlTests.Controls.Add(this.tabPageCategories);
      this.tabControlTests.Location = new System.Drawing.Point(0, 0);
      this.tabControlTests.Multiline = true;
      this.tabControlTests.Name = "tabControlTests";
      this.tabControlTests.SelectedIndex = 0;
      this.tabControlTests.Size = new System.Drawing.Size(266, 398);
      this.tabControlTests.TabIndex = 0;
      // 
      // tabPageTests
      // 
      this.tabPageTests.Controls.Add(this.treeViewTests);
      this.tabPageTests.Location = new System.Drawing.Point(23, 4);
      this.tabPageTests.Name = "tabPageTests";
      this.tabPageTests.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageTests.Size = new System.Drawing.Size(239, 390);
      this.tabPageTests.TabIndex = 1;
      this.tabPageTests.Text = "Tests";
      this.tabPageTests.UseVisualStyleBackColor = true;
      // 
      // treeViewTests
      // 
      this.treeViewTests.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.treeViewTests.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeViewTests.Location = new System.Drawing.Point(3, 3);
      this.treeViewTests.Name = "treeViewTests";
      this.treeViewTests.Size = new System.Drawing.Size(233, 384);
      this.treeViewTests.TabIndex = 0;
      // 
      // tabPageCategories
      // 
      this.tabPageCategories.Location = new System.Drawing.Point(23, 4);
      this.tabPageCategories.Name = "tabPageCategories";
      this.tabPageCategories.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageCategories.Size = new System.Drawing.Size(239, 390);
      this.tabPageCategories.TabIndex = 0;
      this.tabPageCategories.Text = "Categories";
      this.tabPageCategories.UseVisualStyleBackColor = true;
      // 
      // panelRun
      // 
      this.panelRun.Controls.Add(this.label1);
      this.panelRun.Controls.Add(this.labelRun);
      this.panelRun.Controls.Add(this.progressBarRun);
      this.panelRun.Controls.Add(this.buttonStop);
      this.panelRun.Controls.Add(this.buttonRun);
      this.panelRun.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelRun.Location = new System.Drawing.Point(0, 0);
      this.panelRun.Name = "panelRun";
      this.panelRun.Size = new System.Drawing.Size(530, 120);
      this.panelRun.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(172, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(348, 23);
      this.label1.TabIndex = 4;
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelRun
      // 
      this.labelRun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelRun.Location = new System.Drawing.Point(10, 70);
      this.labelRun.Name = "labelRun";
      this.labelRun.Size = new System.Drawing.Size(510, 38);
      this.labelRun.TabIndex = 3;
      // 
      // progressBarRun
      // 
      this.progressBarRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBarRun.Location = new System.Drawing.Point(10, 40);
      this.progressBarRun.Name = "progressBarRun";
      this.progressBarRun.Size = new System.Drawing.Size(510, 23);
      this.progressBarRun.TabIndex = 2;
      // 
      // buttonStop
      // 
      this.buttonStop.Enabled = false;
      this.buttonStop.Location = new System.Drawing.Point(91, 10);
      this.buttonStop.Name = "buttonStop";
      this.buttonStop.Size = new System.Drawing.Size(75, 23);
      this.buttonStop.TabIndex = 1;
      this.buttonStop.Text = "Stop";
      this.buttonStop.UseVisualStyleBackColor = true;
      // 
      // buttonRun
      // 
      this.buttonRun.Enabled = false;
      this.buttonRun.Location = new System.Drawing.Point(10, 10);
      this.buttonRun.Name = "buttonRun";
      this.buttonRun.Size = new System.Drawing.Size(75, 23);
      this.buttonRun.TabIndex = 0;
      this.buttonRun.Text = "Run";
      this.buttonRun.UseVisualStyleBackColor = true;
      // 
      // tabControlResults
      // 
      this.tabControlResults.Alignment = System.Windows.Forms.TabAlignment.Bottom;
      this.tabControlResults.Controls.Add(this.tabPageErrorsAndFailures);
      this.tabControlResults.Controls.Add(this.tabPageTestsNotRun);
      this.tabControlResults.Controls.Add(this.tabPageTextOutput);
      this.tabControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlResults.Location = new System.Drawing.Point(0, 0);
      this.tabControlResults.Name = "tabControlResults";
      this.tabControlResults.SelectedIndex = 0;
      this.tabControlResults.Size = new System.Drawing.Size(530, 398);
      this.tabControlResults.TabIndex = 0;
      // 
      // tabPageErrorsAndFailures
      // 
      this.tabPageErrorsAndFailures.Controls.Add(this.panel1);
      this.tabPageErrorsAndFailures.Controls.Add(this.richTextBoxStackTrace);
      this.tabPageErrorsAndFailures.Controls.Add(this.richTextBoxErrorsAndFailures);
      this.tabPageErrorsAndFailures.Location = new System.Drawing.Point(4, 4);
      this.tabPageErrorsAndFailures.Name = "tabPageErrorsAndFailures";
      this.tabPageErrorsAndFailures.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageErrorsAndFailures.Size = new System.Drawing.Size(522, 372);
      this.tabPageErrorsAndFailures.TabIndex = 0;
      this.tabPageErrorsAndFailures.Text = "Errors and Failures";
      this.tabPageErrorsAndFailures.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(3, 271);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(516, 2);
      this.panel1.TabIndex = 2;
      // 
      // richTextBoxStackTrace
      // 
      this.richTextBoxStackTrace.BackColor = System.Drawing.Color.White;
      this.richTextBoxStackTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxStackTrace.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.richTextBoxStackTrace.Location = new System.Drawing.Point(3, 273);
      this.richTextBoxStackTrace.Name = "richTextBoxStackTrace";
      this.richTextBoxStackTrace.ReadOnly = true;
      this.richTextBoxStackTrace.Size = new System.Drawing.Size(516, 96);
      this.richTextBoxStackTrace.TabIndex = 1;
      this.richTextBoxStackTrace.Text = "";
      // 
      // richTextBoxErrorsAndFailures
      // 
      this.richTextBoxErrorsAndFailures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBoxErrorsAndFailures.BackColor = System.Drawing.Color.White;
      this.richTextBoxErrorsAndFailures.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxErrorsAndFailures.Location = new System.Drawing.Point(9, 122);
      this.richTextBoxErrorsAndFailures.Name = "richTextBoxErrorsAndFailures";
      this.richTextBoxErrorsAndFailures.ReadOnly = true;
      this.richTextBoxErrorsAndFailures.Size = new System.Drawing.Size(510, 151);
      this.richTextBoxErrorsAndFailures.TabIndex = 0;
      this.richTextBoxErrorsAndFailures.Text = "";
      // 
      // tabPageTestsNotRun
      // 
      this.tabPageTestsNotRun.Controls.Add(this.treeViewTestsNotRun);
      this.tabPageTestsNotRun.Location = new System.Drawing.Point(4, 4);
      this.tabPageTestsNotRun.Name = "tabPageTestsNotRun";
      this.tabPageTestsNotRun.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageTestsNotRun.Size = new System.Drawing.Size(522, 372);
      this.tabPageTestsNotRun.TabIndex = 1;
      this.tabPageTestsNotRun.Text = "Tests Not Run";
      this.tabPageTestsNotRun.UseVisualStyleBackColor = true;
      // 
      // treeViewTestsNotRun
      // 
      this.treeViewTestsNotRun.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.treeViewTestsNotRun.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeViewTestsNotRun.Location = new System.Drawing.Point(3, 3);
      this.treeViewTestsNotRun.Name = "treeViewTestsNotRun";
      this.treeViewTestsNotRun.Size = new System.Drawing.Size(516, 366);
      this.treeViewTestsNotRun.TabIndex = 0;
      // 
      // tabPageTextOutput
      // 
      this.tabPageTextOutput.Controls.Add(this.richTextBoxTextOutput);
      this.tabPageTextOutput.Location = new System.Drawing.Point(4, 4);
      this.tabPageTextOutput.Name = "tabPageTextOutput";
      this.tabPageTextOutput.Size = new System.Drawing.Size(522, 372);
      this.tabPageTextOutput.TabIndex = 2;
      this.tabPageTextOutput.Text = "Text Output";
      this.tabPageTextOutput.UseVisualStyleBackColor = true;
      // 
      // richTextBoxTextOutput
      // 
      this.richTextBoxTextOutput.BackColor = System.Drawing.Color.White;
      this.richTextBoxTextOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxTextOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBoxTextOutput.Location = new System.Drawing.Point(0, 0);
      this.richTextBoxTextOutput.Name = "richTextBoxTextOutput";
      this.richTextBoxTextOutput.ReadOnly = true;
      this.richTextBoxTextOutput.Size = new System.Drawing.Size(522, 372);
      this.richTextBoxTextOutput.TabIndex = 0;
      this.richTextBoxTextOutput.Text = "";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Location = new System.Drawing.Point(0, 428);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(800, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.testsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 24);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.reloadProjectToolStripMenuItem,
            this.reloadTestToolStripMenuItem,
            this.toolStripMenuItem3,
            this.recentProjectsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.newToolStripMenuItem.Text = "&New";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.openToolStripMenuItem.Text = "&Open";
      // 
      // closeToolStripMenuItem
      // 
      this.closeToolStripMenuItem.Enabled = false;
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.closeToolStripMenuItem.Text = "&Close";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Enabled = false;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Enabled = false;
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.saveAsToolStripMenuItem.Text = "Save as...";
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 6);
      // 
      // reloadProjectToolStripMenuItem
      // 
      this.reloadProjectToolStripMenuItem.Enabled = false;
      this.reloadProjectToolStripMenuItem.Name = "reloadProjectToolStripMenuItem";
      this.reloadProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
      this.reloadProjectToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.reloadProjectToolStripMenuItem.Text = "Reload Project";
      // 
      // reloadTestToolStripMenuItem
      // 
      this.reloadTestToolStripMenuItem.Enabled = false;
      this.reloadTestToolStripMenuItem.Name = "reloadTestToolStripMenuItem";
      this.reloadTestToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
      this.reloadTestToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.reloadTestToolStripMenuItem.Text = "Reload Tests";
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(187, 6);
      // 
      // recentProjectsToolStripMenuItem
      // 
      this.recentProjectsToolStripMenuItem.Enabled = false;
      this.recentProjectsToolStripMenuItem.Name = "recentProjectsToolStripMenuItem";
      this.recentProjectsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.recentProjectsToolStripMenuItem.Text = "Recent projects";
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(187, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullGUIToolStripMenuItem,
            this.miniGUIToolStripMenuItem,
            this.toolStripMenuItem7,
            this.resultTabsToolStripMenuItem,
            this.toolStripMenuItem9,
            this.statusBarToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      // 
      // testsToolStripMenuItem
      // 
      this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runAllToolStripMenuItem,
            this.runSelectedToolStripMenuItem,
            this.runFailedToolStripMenuItem,
            this.toolStripMenuItem6,
            this.stopRunToolStripMenuItem});
      this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
      this.testsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
      this.testsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
      this.testsToolStripMenuItem.Text = "T&ests";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tUnitHelpToolStripMenuItem,
            this.toolStripMenuItem5,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // tUnitHelpToolStripMenuItem
      // 
      this.tUnitHelpToolStripMenuItem.Name = "tUnitHelpToolStripMenuItem";
      this.tUnitHelpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.tUnitHelpToolStripMenuItem.Text = "TUnit &Help...";
      // 
      // toolStripMenuItem5
      // 
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new System.Drawing.Size(177, 6);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      // 
      // runAllToolStripMenuItem
      // 
      this.runAllToolStripMenuItem.Enabled = false;
      this.runAllToolStripMenuItem.Name = "runAllToolStripMenuItem";
      this.runAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.runAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.runAllToolStripMenuItem.Text = "&Run All";
      // 
      // runSelectedToolStripMenuItem
      // 
      this.runSelectedToolStripMenuItem.Enabled = false;
      this.runSelectedToolStripMenuItem.Name = "runSelectedToolStripMenuItem";
      this.runSelectedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
      this.runSelectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.runSelectedToolStripMenuItem.Text = "Run &Selected";
      // 
      // runFailedToolStripMenuItem
      // 
      this.runFailedToolStripMenuItem.Enabled = false;
      this.runFailedToolStripMenuItem.Name = "runFailedToolStripMenuItem";
      this.runFailedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
      this.runFailedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.runFailedToolStripMenuItem.Text = "Run &Failed";
      // 
      // toolStripMenuItem6
      // 
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new System.Drawing.Size(177, 6);
      // 
      // stopRunToolStripMenuItem
      // 
      this.stopRunToolStripMenuItem.Enabled = false;
      this.stopRunToolStripMenuItem.Name = "stopRunToolStripMenuItem";
      this.stopRunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.stopRunToolStripMenuItem.Text = "S&top Run";
      // 
      // fullGUIToolStripMenuItem
      // 
      this.fullGUIToolStripMenuItem.Checked = true;
      this.fullGUIToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.fullGUIToolStripMenuItem.Name = "fullGUIToolStripMenuItem";
      this.fullGUIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.fullGUIToolStripMenuItem.Text = "&Full GUI";
      // 
      // miniGUIToolStripMenuItem
      // 
      this.miniGUIToolStripMenuItem.Name = "miniGUIToolStripMenuItem";
      this.miniGUIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.miniGUIToolStripMenuItem.Text = "&Mini GUI";
      // 
      // toolStripMenuItem7
      // 
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new System.Drawing.Size(177, 6);
      // 
      // resultTabsToolStripMenuItem
      // 
      this.resultTabsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorsFailuresToolStripMenuItem,
            this.testsNotRunToolStripMenuItem,
            this.toolStripMenuItem8,
            this.testOutputToolStripMenuItem});
      this.resultTabsToolStripMenuItem.Name = "resultTabsToolStripMenuItem";
      this.resultTabsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.resultTabsToolStripMenuItem.Text = "&Result tabs";
      // 
      // errorsFailuresToolStripMenuItem
      // 
      this.errorsFailuresToolStripMenuItem.Checked = true;
      this.errorsFailuresToolStripMenuItem.CheckOnClick = true;
      this.errorsFailuresToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.errorsFailuresToolStripMenuItem.Name = "errorsFailuresToolStripMenuItem";
      this.errorsFailuresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.errorsFailuresToolStripMenuItem.Text = "&Errors && Failures";
      // 
      // testsNotRunToolStripMenuItem
      // 
      this.testsNotRunToolStripMenuItem.Checked = true;
      this.testsNotRunToolStripMenuItem.CheckOnClick = true;
      this.testsNotRunToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.testsNotRunToolStripMenuItem.Name = "testsNotRunToolStripMenuItem";
      this.testsNotRunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.testsNotRunToolStripMenuItem.Text = "&Tests Not Run";
      // 
      // toolStripMenuItem8
      // 
      this.toolStripMenuItem8.Name = "toolStripMenuItem8";
      this.toolStripMenuItem8.Size = new System.Drawing.Size(177, 6);
      // 
      // testOutputToolStripMenuItem
      // 
      this.testOutputToolStripMenuItem.Name = "testOutputToolStripMenuItem";
      this.testOutputToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.testOutputToolStripMenuItem.Text = "Test &Output...";
      // 
      // toolStripMenuItem9
      // 
      this.toolStripMenuItem9.Name = "toolStripMenuItem9";
      this.toolStripMenuItem9.Size = new System.Drawing.Size(177, 6);
      // 
      // statusBarToolStripMenuItem
      // 
      this.statusBarToolStripMenuItem.Checked = true;
      this.statusBarToolStripMenuItem.CheckOnClick = true;
      this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
      this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.statusBarToolStripMenuItem.Text = "&Status &Bar";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.splitContainerMain);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FormMain";
      this.Text = "TUnit";
      this.splitContainerMain.Panel1.ResumeLayout(false);
      this.splitContainerMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
      this.splitContainerMain.ResumeLayout(false);
      this.tabControlTests.ResumeLayout(false);
      this.tabPageTests.ResumeLayout(false);
      this.panelRun.ResumeLayout(false);
      this.tabControlResults.ResumeLayout(false);
      this.tabPageErrorsAndFailures.ResumeLayout(false);
      this.tabPageTestsNotRun.ResumeLayout(false);
      this.tabPageTextOutput.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainerMain;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.TabControl tabControlResults;
    private System.Windows.Forms.TabPage tabPageErrorsAndFailures;
    private System.Windows.Forms.TabPage tabPageTestsNotRun;
    private System.Windows.Forms.Panel panelRun;
    private System.Windows.Forms.TabPage tabPageTextOutput;
    private System.Windows.Forms.Button buttonStop;
    private System.Windows.Forms.Button buttonRun;
    private System.Windows.Forms.ProgressBar progressBarRun;
    private System.Windows.Forms.Label labelRun;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RichTextBox richTextBoxStackTrace;
    private System.Windows.Forms.RichTextBox richTextBoxErrorsAndFailures;
    private System.Windows.Forms.TreeView treeViewTestsNotRun;
    private System.Windows.Forms.RichTextBox richTextBoxTextOutput;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TabControl tabControlTests;
    private System.Windows.Forms.TabPage tabPageTests;
    private System.Windows.Forms.TreeView treeViewTests;
    private System.Windows.Forms.TabPage tabPageCategories;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem reloadProjectToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reloadTestToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem recentProjectsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fullGUIToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem miniGUIToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
    private System.Windows.Forms.ToolStripMenuItem resultTabsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem errorsFailuresToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem testsNotRunToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
    private System.Windows.Forms.ToolStripMenuItem testOutputToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
    private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem runAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem runSelectedToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem runFailedToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    private System.Windows.Forms.ToolStripMenuItem stopRunToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tUnitHelpToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
  }
}

