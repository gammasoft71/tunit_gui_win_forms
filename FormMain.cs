﻿using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using tunit.Properties;

namespace tunit {
  class FormMain : Form {
    private class LineSeparator : Label {
      protected override void OnPaint(PaintEventArgs e) {
        e.Graphics.Clear(Enabled ?  SystemColors.WindowText : ControlPaint.LightLight(SystemColors.WindowText));
      }
    }

    public FormMain() {
      ClientSize = new System.Drawing.Size(850, 525);
      Menu = new MainMenu(
        new MenuItem[] {
          new MenuItem("&File", new MenuItem[] {
            new MenuItem("&New", OnFileNewClick, Shortcut.CtrlN),
            new MenuItem("&Open", OnFileOpenClick, Shortcut.CtrlO),
            (menuItemFileClose = new MenuItem("&Close", OnFileCloseClick, Shortcut.CtrlW){Enabled = false}),
            new MenuItem("-"),
            (menuItemFileSave = new MenuItem ("&Save", OnFileSaveClick, Shortcut.CtrlS){Enabled = false}),
            (menuItemFileSaveAs = new MenuItem("Save &As...", OnFileSaveAsClick){Enabled = false}),
            new MenuItem("-"),
            (menuItemFileReloadProject = new MenuItem("Re&load project", OnFileReloadProjectClick, Shortcut.CtrlL){Enabled = false}),
            (menuItemFileReloadTests = new MenuItem("&Reload tests", OnFileReloadTestsClick, Shortcut.CtrlR){Enabled = false}),
            new MenuItem("-"),
            new MenuItem("Recent Projects", new MenuItem[] { }){Enabled = false},
            new MenuItem("-"),
            new MenuItem("&Exit", OnFileExitClick, Shortcut.AltF4),
          }),
          new MenuItem("&View", new MenuItem[] {
            (menuItemViewFullGui = new MenuItem("&Full gui", OnViewFullGuiClick) { Checked = true}),
            (menuItemViewMiniGui = new MenuItem("&Mini gui", OnViewMiniGuiClick)),
            new MenuItem("-"),
            new MenuItem("Result tabs", new MenuItem[] {
              (menuItemViewResultTabsConsoleOutput = new MenuItem("&Console output", OnViewResultTabsConsoleOutputClick)),
              (menuItemViewResultTabsSucceedTests = new MenuItem("&Succeed tests", OnViewResultTabsSucceedTestsClick)),
              (menuItemViewResultTabsIgnoredTests = new MenuItem("&Ignored tests", OnViewResultTabsIgnoredTestsClick)),
              (menuItemViewResultTabsAbortedTests = new MenuItem("&Aborted tests", OnViewResultTabsAbortedTestsClick)),
              (menuItemViewResultTabsFailedTests = new MenuItem("&Failed tests", OnViewResultTabsFailedTestsClick) { Checked = true}),
            }),
            (menuItemViewStatusWithLogo = new MenuItem("&Status with logo", OnViewStatusWithLogoClick)),
            new MenuItem("Status &bar", OnViewStatusBarClick) { Checked = true},
          }),
          new MenuItem("&Project", new MenuItem[] {
            (menuItemProjectAddTUnitFile = new MenuItem("&Add TUnit file...", OnProjectAddTUnitFileClick) {Enabled = false}),
            (menuItemProjectTUnitProperties = new MenuItem("&TUnit properties...", OnProjectTUnitPropertiesClick) {Enabled = false}),
            new MenuItem("-"),
            new MenuItem("&Options...", OnProjectOptionsClick) {Enabled = false},
          }),
          new MenuItem("T&ests", new MenuItem[] {
            (menuItemTestsRunAll = new MenuItem("&Run all", OnTestsRunAllClick, Shortcut.F5) {Enabled = false}),
            (menuItemTestsRunSelected = new MenuItem("Run &Selected", OnTestsRunSelectedClick, Shortcut.F6) {Enabled = false}),
            (menuItemTestsRunFailed = new MenuItem("Run &Failed", OnTestsRunFailedClick, Shortcut.F7) {Enabled = false}),
            new MenuItem("-"),
            (menuItemTestsStopRun = new MenuItem("S&top Run", OnTestsStopRunClick, Shortcut.AltBksp) {Enabled = false}),
          }),
           new MenuItem("&Help", new MenuItem[] {
             new MenuItem("&About...",  OnHelpAboutClick),
           }),
        });
      Icon = Resources.TUnitIcon;
      Text = "TUnit";

      contextMenu = new ContextMenu();
      contextMenu.MenuItems.AddRange(
        new MenuItem[] {
          new MenuItem("Run", OnTestsRunSelectedClick),
          new MenuItem("-"),
          new MenuItem("Properties...", OnProjectTUnitPropertiesClick),
      });

      splitContainer = new SplitContainer { Parent = this, Dock = DockStyle.Fill, SplitterDistance = 265 };

      imageList = new ImageList { TransparentColor = Color.Transparent };
      imageList.Images.AddRange(new Image[] { Resources.NotStartedColor, Resources.SucceedColor, Resources.IgnoredColor, Resources.AbortedColor, Resources.FailedColor });

      treeViewTests = new TreeView {ImageList = imageList,  Parent = splitContainer.Panel1, Dock = DockStyle.Fill };
      treeViewTests.AfterSelect += OnTreeViewTestsAfterSelect;
      treeViewTests.NodeMouseDoubleClick += OnTreeViewTestsNodeMouseDoubleClick;
      treeViewTests.NodeMouseClick += OnTreeViewTestsNodeMouseClick;

      tabControlResults = new TabControl { Parent = splitContainer.Panel2, Dock = DockStyle.Fill, Alignment = TabAlignment.Bottom };
      tabControlResults.TabPages.AddRange(new TabPage[] {
        (tabPageConsoleOutput = new TabPage { Tag = 0, Text = "Console Output" }),
        (tabPageSucceedTests = new TabPage { Tag = 1, Text = "Succeed Tests" }),
        (tabPageIgnoredTests = new TabPage { Tag = 2, Text = "Ignored Tests" }),
        (tabPageAbortedTests = new TabPage { Tag = 3, Text = "Aborted Tests" }),
        (tabPageFailedTests = new TabPage { Tag = 4, Text = "Failed Tests" }),
      });

      richTextBoxOutput = new RichTextBox { BackColor = Color.Black, Dock = DockStyle.Fill, ForeColor = Color.White, Parent = tabPageConsoleOutput, Font = new Font(FontFamily.GenericMonospace, SystemFonts.DefaultFont.Size) };
      treeViewSucceedTests = new TreeView { Dock = DockStyle.Fill, Parent = tabPageSucceedTests };
      treeViewIgnoredTests = new TreeView { Dock = DockStyle.Fill, Parent = tabPageIgnoredTests };
      treeViewAbortedTests = new TreeView { Dock = DockStyle.Fill, Parent = tabPageAbortedTests };
      treeViewFailedTests = new TreeView { Dock = DockStyle.Fill, Parent = tabPageFailedTests };

      panelRun = new Panel { Enabled = false, Parent = splitContainer.Panel2, Dock = DockStyle.Top, Height = 103};

      buttonRun = new Button { Location = new Point(10, 10), Parent = panelRun, Text = "&Run" };
      buttonRun.Click += OnTestsRunSelectedClick;

      buttonStop = new Button { Location = new Point(buttonRun.Left + buttonRun.Width + 10, 10), Parent = panelRun, Text = "&Stop" };
      buttonStop.Click += OnTestsStopRunClick;

      labelSelectedTest = new Label { AutoSize = true, Location = new Point(buttonStop.Left + buttonStop.Width + 10, 13), Parent = panelRun};

      progressBarRun = new ProgressBar { Location = new Point (10, buttonRun.Top + buttonRun.Height + 10), Parent = panelRun, Width = panelRun.Width - 20, Anchor = AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Right };
      labelRepeat = new Label { AutoSize = true, Location = new Point (10, progressBarRun.Top + progressBarRun.Height + 13), Parent = panelRun, Text = "Repeat" };
      numericUpDownRepeat = new NumericUpDown { Location = new Point(labelRepeat.Left + labelRepeat.Width + 10, progressBarRun.Top + progressBarRun.Height + 10), Maximum = 1000000, Minimum = 1 , Parent = panelRun, Width = 70};
      numericUpDownRepeat.ValueChanged += delegate {
        Settings.Default.RepeatTests = (int)numericUpDownRepeat.Value;
      };
      checkBoxForever = new CheckBox {AutoSize = true, Location = new Point(numericUpDownRepeat.Left + numericUpDownRepeat.Width + 10, progressBarRun.Top + progressBarRun.Height + 12), Parent = panelRun, Text = "Forever" };
      checkBoxForever.Click += delegate {
        Settings.Default.RepeatForEver = checkBoxForever.Checked;
      };
      labelRunSeparator1 = new LineSeparator {Location = new Point(checkBoxForever.Left + checkBoxForever.Width + 10, progressBarRun.Top + progressBarRun.Height + 10), Parent = panelRun, Size = new Size(1, numericUpDownRepeat.Height) };
      checkBoxShuffle = new CheckBox { AutoSize = true, Location = new Point(labelRunSeparator1.Left + labelRunSeparator1.Width + 10, progressBarRun.Top + progressBarRun.Height + 12), Parent = panelRun, Text = "Shuffle" };
      checkBoxShuffle.Click += delegate {
        Settings.Default.ShuffleTests = checkBoxShuffle.Checked;
      };
      labelSeed = new Label { AutoSize = true, Location = new Point(checkBoxShuffle.Left + checkBoxShuffle.Width + 10, progressBarRun.Top + progressBarRun.Height + 13), Parent = panelRun, Text = "Seed" };
      numericUpDownSeed = new NumericUpDown { Location = new Point(labelSeed.Left + labelSeed.Width + 10, progressBarRun.Top + progressBarRun.Height + 10), Maximum = Int32.MaxValue, Minimum = 0, Parent = panelRun, Width = 70 };
      numericUpDownSeed.ValueChanged += delegate {
        Settings.Default.RandomSeed = (int)numericUpDownSeed.Value;
      };
      labelRunSeparator2 = new LineSeparator { Location = new Point(numericUpDownSeed.Left + numericUpDownSeed.Width + 10, progressBarRun.Top + progressBarRun.Height + 10), Parent = panelRun, Size = new Size(1, numericUpDownRepeat.Height) };
      checkBoxRunIgneredTests = new CheckBox { AutoSize = true, Location = new Point(labelRunSeparator2.Left + labelRunSeparator2.Width + 10, progressBarRun.Top + progressBarRun.Height + 12), Parent = panelRun, Text = "Run ignored tests" };
      checkBoxRunIgneredTests.Click += delegate {
        Settings.Default.AlsoRunIgnoredTests = checkBoxRunIgneredTests.Checked;
      };

      labelColor = new Label { Parent = this, Dock = DockStyle.Top, Height = 4};

      statusBar = new StatusBar { Parent = this, ShowPanels = true };
      statusBar.Panels.AddRange(new StatusBarPanel[] {
        (statusBarPanelTestCases = new StatusBarPanel { BorderStyle = StatusBarPanelBorderStyle.Sunken, Text = "Test Cases : 0", AutoSize = StatusBarPanelAutoSize.Contents}),
        (statusBarPanelRanTests = new StatusBarPanel { BorderStyle = StatusBarPanelBorderStyle.Sunken, Text = "Ran Tests : 0", AutoSize = StatusBarPanelAutoSize.Contents}),
        (statusBarPanelSucceedTests =  new StatusBarPanel { BorderStyle = StatusBarPanelBorderStyle.Sunken, Icon = Icon.FromHandle(new Bitmap(imageList.Images[1], new Size(16, 16)).GetHicon()), Text = "Succeed Tests : 0", AutoSize = StatusBarPanelAutoSize.Contents}),
        (statusBarPanelIgnoredTests = new StatusBarPanel { BorderStyle = StatusBarPanelBorderStyle.Sunken, Icon = Icon.FromHandle(new Bitmap(imageList.Images[2], new Size(16, 16)).GetHicon()), Text = "Ignored Tests : 0", AutoSize = StatusBarPanelAutoSize.Contents}),
        (statusBarPanelAbortedTests = new StatusBarPanel { BorderStyle = StatusBarPanelBorderStyle.Sunken, Icon = Icon.FromHandle(new Bitmap(imageList.Images[3], new Size(16, 16)).GetHicon()), Text = "Aborted Tests : 0", AutoSize = StatusBarPanelAutoSize.Contents}),
        (statusBarPanelFailedTests = new StatusBarPanel { BorderStyle = StatusBarPanelBorderStyle.Sunken, Icon = Icon.FromHandle(new Bitmap(imageList.Images[4], new Size(16, 16)).GetHicon()), Text = "Failed Tests : 0", AutoSize = StatusBarPanelAutoSize.Contents}),
        (statusBarPanelDuration = new StatusBarPanel { BorderStyle = StatusBarPanelBorderStyle.Sunken, Text = "Time : 0", AutoSize = StatusBarPanelAutoSize.Contents}),
      });

      timerUpdateGui = new System.Windows.Forms.Timer();

      LoadSettings();
      Application.Idle += OnApplicationIdle;
      FormClosed += OnFormCloed;
      FormClosing += OnFormClosing;
      timerUpdateGui.Tick += OnTimerUpdateGuidTick;
    }

    private void AddTabPageToTabControlResult(TabPage tabPage) {
      int indexToInsert = 0;
      foreach (TabPage item in tabControlResults.TabPages)
        if ((Int32)item.Tag < (Int32)tabPage.Tag) indexToInsert++;
      tabControlResults.TabPages.Insert(indexToInsert, tabPage);
    }

    private void CloseProject() {
      Enabled = false;
      progressBarRun.Value = 0;
      labelColor.BackColor = System.Drawing.SystemColors.Control;
      statusBarPanelTestCases.Text = "Test Cases : 0";
      statusBarPanelRanTests.Text = "Ran Tests : 0";
      statusBarPanelSucceedTests.Text = "Succeed Tests : 0";
      statusBarPanelIgnoredTests.Text = "Ignored Tests : 0";
      statusBarPanelAbortedTests.Text = "Aborted Tests : 0";
      statusBarPanelFailedTests.Text = "Failed Tests : 0";
      statusBarPanelDuration.Text = $"Time : {TimeSpan.Zero}";
      tunitProject.TestEnd -= OnTestEnd;
      tunitProject.TUnitProjectStart -= OnTUnitProjectStart;
      tunitProject.TUnitProjectEnd -= OnTUnitProjectEnd;
      tunitProject = null;
      Application.DoEvents();
      treeViewTests.Nodes.Clear();
      Enabled = true;
    }

    private void LoadSettings() {
      if (Settings.Default.IsMiniGui)
        OnViewMiniGuiClick(this, EventArgs.Empty);
      ClientSize = Settings.Default.ClentSize;
      if (Settings.Default.Location != new System.Drawing.Point(-1, -1)) {
        StartPosition = FormStartPosition.Manual;
        Location = Settings.Default.Location;
      }

      if (!Settings.Default.IsConsoleOutputVisible) tabControlResults.TabPages.Remove(tabPageConsoleOutput);
      if (!Settings.Default.IsSucceedTestsVisible) tabControlResults.TabPages.Remove(tabPageSucceedTests);
      if (!Settings.Default.IsIgnoredTestsVisible) tabControlResults.TabPages.Remove(tabPageIgnoredTests);
      if (!Settings.Default.IsAbortedTestsVisible) tabControlResults.TabPages.Remove(tabPageAbortedTests);
      if (!Settings.Default.IsFailedTestsVisible) tabControlResults.TabPages.Remove(tabPageFailedTests);

      menuItemViewResultTabsConsoleOutput.Checked = Settings.Default.IsConsoleOutputVisible;
      menuItemViewResultTabsSucceedTests.Checked = Settings.Default.IsSucceedTestsVisible;
      menuItemViewResultTabsIgnoredTests.Checked = Settings.Default.IsIgnoredTestsVisible;
      menuItemViewResultTabsAbortedTests.Checked = Settings.Default.IsAbortedTestsVisible;
      menuItemViewResultTabsFailedTests.Checked = Settings.Default.IsFailedTestsVisible;
      statusBar.Visible = Settings.Default.IsStatusBarVisible;

      if (Settings.Default.RecentFiles == null) Settings.Default.RecentFiles = new System.Collections.Specialized.StringCollection();
      tabControlResults.SelectedIndex = Settings.Default.TabControlResultSelectedIndex;

      if (Settings.Default.IsMaximize)
        WindowState = FormWindowState.Maximized;

      menuItemViewStatusWithLogo.Checked = !Settings.Default.StatusWithLogo;
      OnViewStatusWithLogoClick(menuItemViewStatusWithLogo, new EventArgs());

      numericUpDownRepeat.Value = Settings.Default.RepeatTests;
      checkBoxForever.Checked = Settings.Default.RepeatForEver;
      checkBoxShuffle.Checked = Settings.Default.ShuffleTests;
      numericUpDownSeed.Value = Settings.Default.RandomSeed;
      checkBoxRunIgneredTests.Checked = Settings.Default.AlsoRunIgnoredTests;
    }

    private void OnApplicationIdle(object sender, EventArgs e) {
      UpdateGui();
    }

    private void OnHelpAboutClick(object sender, EventArgs e) {
      AboutBox aboutBox = new AboutBox();
      aboutBox.ShowDialog(this);
    }

    private void OnFileCloseClick(object sender, EventArgs e) {
      if (tunitProject != null) {
        if (tunitProject.Saved) {
          CloseProject();
        } else {
          DialogResult result = MessageBox.Show("Save current project before closing ?", "Save project", MessageBoxButtons.YesNoCancel);
          if (result == DialogResult.Yes) {
            OnFileSaveClick(sender, e);
            if (tunitProject.Saved) {
              CloseProject();
            }
          }
          if (result == DialogResult.No) {
            tunitProject = null;
            treeViewTests.Nodes.Clear();
          }
        }
      }
    }

    private void OnFileExitClick(object sender, EventArgs e) {
      Close();
    }

    private void OnFileNewClick(object sender, EventArgs e) {
      OnFileCloseClick(sender, e);
      if (tunitProject == null) {
        tunitProject = new TUnitProject();
        tunitProject.New();
        tunitProject.TestEnd += OnTestEnd;
        tunitProject.TUnitProjectStart += OnTUnitProjectStart;
        tunitProject.TUnitProjectEnd += OnTUnitProjectEnd;
        ReloadProject();
      }
    }

    private void OnFileOpenClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit project or application Files (*.tunit;*.exe)|*.tunit;*.exe|TUnit project Files (*.tunit)|*.tunit|TUnit application Files (*.exe)|*.exe|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        OnFileCloseClick(sender, e);
        if (tunitProject == null) {
          if (System.IO.Path.GetExtension(openFileDialog.FileName) != ".tunit") {
            tunitProject = new TUnitProject();
            tunitProject.New(System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName));
            tunitProject.TestEnd += OnTestEnd;
            tunitProject.TUnitProjectStart += OnTUnitProjectStart;
            tunitProject.TUnitProjectEnd += OnTUnitProjectEnd;
            if (!UnitTest.IsTUnitApplication(openFileDialog.FileName)) {
              MessageBox.Show($"{openFileDialog.FileName} is not a TUnit application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
              tunitProject.AddUnitTest(openFileDialog.FileName);
              //ReloadTests(openFileDialog.FileName);
              ReloadProject();
            }
          } else {
            Enabled = false;

            if (Settings.Default.RecentFiles.Count > 5) Settings.Default.RecentFiles.RemoveAt(0);
            Settings.Default.RecentFiles.Add(openFileDialog.FileName);

            SuspendLayout();
            tunitProject = new TUnitProject(openFileDialog.FileName);
            tunitProject.Load();
            tunitProject.TestEnd += OnTestEnd;
            tunitProject.TUnitProjectStart += OnTUnitProjectStart;
            tunitProject.TUnitProjectEnd += OnTUnitProjectEnd;
            ReloadProject();
            Enabled = true;
            ResumeLayout();
          }
        }
      }
    }

    private void OnFileReloadProjectClick(object sender, EventArgs e) {
      ReloadProject();
    }

    private void OnFileReloadTestsClick(object sender, EventArgs e) {
      progressBarRun.Maximum = tunitProject.TestCount;
      ResetProject();
      tunitProject.Run();
    }

    private void OnFileSaveClick(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(tunitProject.FileName))
        OnFileSaveAsClick(sender, e);
      else if (!string.IsNullOrEmpty(tunitProject.FileName))
        tunitProject.Save();
    }

    private void OnFileSaveAsClick(object sender, EventArgs e) {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.FileName = $"{tunitProject.Name}.tunit";
      DialogResult result = saveFileDialog.ShowDialog();
      if (result == DialogResult.OK) tunitProject.FileName = saveFileDialog.FileName;

      if (!string.IsNullOrEmpty(tunitProject.FileName))
        tunitProject.Save();
    }

    private void OnFormCloed(object sender, FormClosedEventArgs e) {
      SaveSettings();
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e) {
      OnFileCloseClick(sender, EventArgs.Empty);
      e.Cancel = tunitProject != null;
    }

    private void OnProjectAddTUnitFileClick(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TUnit Application Files (*.exe)|*.exe|All Files (*.*)|*.*";
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK) {
        if (!UnitTest.IsTUnitApplication(openFileDialog.FileName)) {
          MessageBox.Show($"{openFileDialog.FileName} is not a TUnit application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } else {
          tunitProject.AddUnitTest(openFileDialog.FileName);
          //ReloadTests(openFileDialog.FileName);
          ReloadProject();
        }
      }
    }

    private void OnProjectOptionsClick(object sender, EventArgs e) {
    }

    private void OnProjectTUnitPropertiesClick(object sender, EventArgs e) {
      TreeNode treeNode = treeViewTests.SelectedNode;
      if (treeNode != null) {
        if (treeNode.Tag is TUnitProject) {
        } else if (treeNode.Tag is UnitTest) {
        } else if (treeNode.Tag is TestFixture) {
          FormTestFixtureProperties testFixtureProperties = new FormTestFixtureProperties(treeNode.Tag as TestFixture);
          testFixtureProperties.ShowDialog();
        } else if (treeNode.Tag is Test) {
          FormTestProperties testProperties = new FormTestProperties(treeNode.Tag as Test);
          testProperties.ShowDialog();
        }
      }
    }

    private void OnTestEnd(object sender, TestEventArgs e) {
      if (treeViewTests.Nodes[0].ImageIndex != (int)tunitProject.Status) treeViewTests.Nodes[0].SelectedImageIndex = treeViewTests.Nodes[0].ImageIndex = (int)tunitProject.Status;
      TreeNode nodeFound = treeViewTests.Nodes[0].Nodes.Find(e.Test.TestFixture.UnitTest.FileName, false)[0];
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
        case TestStatus.Succeed: treeNode = treeViewSucceedTests.Nodes.Add($"{e.Test.TestFixture.Name}.{e.Test.Name} ({e.Test.Duration})"); break;
        case TestStatus.Ignored: treeNode = treeViewIgnoredTests.Nodes.Add($"{e.Test.TestFixture.Name}.{e.Test.Name} ({e.Test.Duration})"); break;
        case TestStatus.Aborted: treeNode = treeViewAbortedTests.Nodes.Add($"{e.Test.TestFixture.Name}.{e.Test.Name} ({e.Test.Duration})"); break;
        case TestStatus.Failed: treeNode = treeViewFailedTests.Nodes.Add($"{e.Test.TestFixture.Name}.{e.Test.Name} ({e.Test.Duration})"); break;
      }

      if (treeNode != null) {
        treeNode.Nodes.Add($"File: {e.Test.TestFixture.UnitTest.FileName}");
        foreach (string message in e.Test.Messages)
          treeNode.Nodes.Add(message);
        if (!string.IsNullOrEmpty(e.Test.StackTrace))
          treeNode.Nodes.Add($"StackTrace: {e.Test.StackTrace}");
      }

      if (checkBoxForever.Checked == false)
        progressBarRun.Increment(1);
      //UpdateGui();
      Application.DoEvents();
    }

    private void OnTestsRunAllClick(object sender, EventArgs e) {
      progressBarRun.Maximum = tunitProject.TestCount;
      ResetProject();
      tunitProject.Run();
    }

    private void OnTestsRunSelectedClick(object sender, EventArgs e) {
      TreeNode treeNode = treeViewTests.SelectedNode;
      if (treeNode != null) {
        ResetProject();
        if (treeNode.Tag is TUnitProject) {
          progressBarRun.Maximum = tunitProject.TestCount;
          tunitProject.Run();
        } else if (treeNode.Tag is UnitTest) {
          progressBarRun.Maximum = (treeNode.Tag as UnitTest).TestCount;
          tunitProject.Run(treeNode.Tag as UnitTest);
        } else if (treeNode.Tag is TestFixture) {
          progressBarRun.Maximum = (treeNode.Tag as TestFixture).TestCount;
          tunitProject.Run(treeNode.Tag as TestFixture);
        } else if (treeNode.Tag is Test) {
          progressBarRun.Maximum = 1;
          tunitProject.Run(treeNode.Tag as Test);
        }
      }
    }

    private void OnTestsRunFailedClick(object sender, EventArgs e) {
      progressBarRun.Value = 0;
      progressBarRun.Maximum = tunitProject.FailedCount;
      treeViewFailedTests.Nodes.Clear();
      foreach (TreeNode nodeTUnitProject in treeViewTests.Nodes) {
        foreach (TreeNode nodeUnitTest in nodeTUnitProject.Nodes) {
          foreach (TreeNode nodeTestFixture in nodeUnitTest.Nodes) {
            foreach (TreeNode nodeTest in nodeTestFixture.Nodes) {
              if ((nodeTest.Tag as Test).Status == TestStatus.Failed) {
                tunitProject.Run(nodeTest.Tag as Test);
              }
            }
          }
        }
      }
    }

    private void OnTestsStopRunClick(object sender, EventArgs e) {
      tunitProject.Stop();
    }

    private void OnTimerUpdateGuidTick(object sender, EventArgs e) {
      UpdateGui();
    }

    private void OnTUnitProjectEnd(object sender, EventArgs e) {
      running = false;
      stopWatch.Stop();
      timerUpdateGui.Enabled = false;
      richTextBoxOutput.Text = string.Join(Environment.NewLine, tunitProject.TextOutput);
      progressBarRun.Style = ProgressBarStyle.Continuous;
      progressBarRun.Value = progressBarRun.Maximum;
      UpdateGui();
      Application.DoEvents();
    }

    private void OnTreeViewTestsNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
      this.selectedTreeNode = e.Node;
    }

    private void OnTreeViewTestsNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
      this.selectedTreeNode = e.Node;
      this.OnTestsRunSelectedClick(sender, EventArgs.Empty);
    }

    private void OnTreeViewTestsAfterSelect(object sender, TreeViewEventArgs e) {
      selectedTreeNode = treeViewTests.SelectedNode;
      this.labelSelectedTest.Text = this.treeViewTests.SelectedNode.Text;
    }

    private void OnTUnitProjectStart(object sender, EventArgs e) {
      running = true;
      stopWatch.Reset();
      stopWatch.Start();
      timerUpdateGui.Enabled = true;
      progressBarRun.Style = checkBoxForever.Checked ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
      UpdateGui();
      Application.DoEvents();
    }

    private void OnViewFullGuiClick(object sender, EventArgs e) {
      menuItemViewMiniGui.Checked = !menuItemViewFullGui.Checked;
      splitContainer.Panel2Collapsed = false;
      statusBar.Visible = true;
      ClientSize = new System.Drawing.Size(850, 525);
    }

    private void OnViewMiniGuiClick(object sender, EventArgs e) {
      menuItemViewFullGui.Checked = !menuItemViewMiniGui.Checked;
      splitContainer.Panel2Collapsed = true;
      statusBar.Visible = false;
      ClientSize = new System.Drawing.Size(324, 525);
    }

    private void OnViewStatusWithLogoClick(object sender, EventArgs e) {
      menuItemViewStatusWithLogo.Checked = !menuItemViewStatusWithLogo.Checked;
      imageList.Images.Clear();
      if (menuItemViewStatusWithLogo.Checked) imageList.Images.AddRange(new Image[] { Resources.NotStartedPicture, Resources.SucceedPicture, Resources.IgnoredPicture, Resources.AbortedPicture, Resources.FailedPicture });
      else imageList.Images.AddRange(new Image[] { Resources.NotStartedColor, Resources.SucceedColor, Resources.IgnoredColor, Resources.AbortedColor, Resources.FailedColor });
      statusBarPanelSucceedTests.Icon = Icon.FromHandle(new Bitmap(imageList.Images[1], new Size(16, 16)).GetHicon());
      statusBarPanelIgnoredTests.Icon = Icon.FromHandle(new Bitmap(imageList.Images[2], new Size(16, 16)).GetHicon());
      statusBarPanelAbortedTests.Icon = Icon.FromHandle(new Bitmap(imageList.Images[3], new Size(16, 16)).GetHicon());
      statusBarPanelFailedTests.Icon = Icon.FromHandle(new Bitmap(imageList.Images[4], new Size(16, 16)).GetHicon());
    }

    private void OnViewResultTabsConsoleOutputClick(object sender, EventArgs e) {
      (sender as MenuItem).Checked = !(sender as MenuItem).Checked;
      if ((sender as MenuItem).Checked) {
        AddTabPageToTabControlResult(tabPageConsoleOutput);
        tabControlResults.SelectedTab = tabPageConsoleOutput;
      } else
        tabControlResults.TabPages.Remove(tabPageConsoleOutput);
    }

    private void OnViewResultTabsSucceedTestsClick(object sender, EventArgs e) {
      (sender as MenuItem).Checked = !(sender as MenuItem).Checked;
      if ((sender as MenuItem).Checked) {
        AddTabPageToTabControlResult(tabPageSucceedTests);
        tabControlResults.SelectedTab = tabPageSucceedTests;
      } else
        tabControlResults.TabPages.Remove(tabPageSucceedTests);
    }

    private void OnViewResultTabsIgnoredTestsClick(object sender, EventArgs e) {
      (sender as MenuItem).Checked = !(sender as MenuItem).Checked;
      if ((sender as MenuItem).Checked) {
        AddTabPageToTabControlResult(tabPageIgnoredTests);
        tabControlResults.SelectedTab = tabPageIgnoredTests;
      } else
        tabControlResults.TabPages.Remove(tabPageIgnoredTests);
    }

    private void OnViewResultTabsAbortedTestsClick(object sender, EventArgs e) {
      (sender as MenuItem).Checked = !(sender as MenuItem).Checked;
      if ((sender as MenuItem).Checked) {
        AddTabPageToTabControlResult(tabPageAbortedTests);
        tabControlResults.SelectedTab = tabPageAbortedTests;
      } else
        tabControlResults.TabPages.Remove(tabPageAbortedTests);
    }

    private void OnViewResultTabsFailedTestsClick(object sender, EventArgs e) {
      (sender as MenuItem).Checked = !(sender as MenuItem).Checked;
      if ((sender as MenuItem).Checked) {
        AddTabPageToTabControlResult(tabPageFailedTests);
        tabControlResults.SelectedTab = tabPageFailedTests;
      } else
        tabControlResults.TabPages.Remove(tabPageFailedTests);
    }

    private void OnViewStatusBarClick(object sender, EventArgs e) {
      statusBar.Visible = (sender as MenuItem).Checked = !(sender as MenuItem).Checked;
    }

    private void ReloadProject() {
      tunitProject.Reset();
      progressBarRun.Value = 0;
      progressBarRun.Maximum = tunitProject.TestCount;
      richTextBoxOutput.Text = "";
      treeViewTests.SuspendLayout();
      treeViewSucceedTests.Nodes.Clear();
      treeViewIgnoredTests.Nodes.Clear();
      treeViewAbortedTests.Nodes.Clear();
      treeViewFailedTests.Nodes.Clear();
      treeViewTests.Nodes.Clear();
      treeViewTests.Nodes.Add(string.IsNullOrEmpty(tunitProject.FileName) ? tunitProject.Name : tunitProject.FileName);
      treeViewTests.Nodes[0].ContextMenu = contextMenu;
      treeViewTests.Nodes[0].Tag = tunitProject;
      foreach (var unitTest in tunitProject.UnitTests) {
        TreeNode unitTestNode = treeViewTests.Nodes[0].Nodes.Add(unitTest.FileName);
        unitTestNode.Name = unitTest.FileName;
        unitTestNode.ContextMenu = contextMenu;
        unitTestNode.Tag = unitTest;
        foreach (var testFixture in unitTest.TestFixtures) {
          TreeNode testFixtureNode = unitTestNode.Nodes.Add(testFixture.Name);
          testFixtureNode.Name = testFixture.Name;
          testFixtureNode.ContextMenu = contextMenu;
          testFixtureNode.Tag = testFixture;
          foreach (var test in testFixture.Tests) {
            TreeNode testNode = testFixtureNode.Nodes.Add(test.Name);
            testNode.Name = test.Name;
            testNode.ContextMenu = contextMenu;
            testNode.Tag = test;
          }
        }
      }
      treeViewTests.ExpandAll();
      treeViewTests.SelectedNode = treeViewTests.Nodes[0];
      treeViewTests.ResumeLayout();
    }

    private void ResetProject() {
      tunitProject.Reset();
      progressBarRun.Value = 0;
      progressBarRun.Maximum = tunitProject.TestCount;
      treeViewSucceedTests.Nodes.Clear();
      treeViewIgnoredTests.Nodes.Clear();
      treeViewAbortedTests.Nodes.Clear();
      treeViewFailedTests.Nodes.Clear();
      richTextBoxOutput.Text = "";
      treeViewTests.SuspendLayout();
      foreach (TreeNode node1 in treeViewTests.Nodes) {
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
      treeViewTests.ResumeLayout();
    }

    private void SaveSettings() {
      Settings.Default.IsMaximize = WindowState == FormWindowState.Maximized;
      if (WindowState != FormWindowState.Maximized) {
        var clientSize = ClientSize;
        clientSize.Height = ClientSize.Height - SystemInformation.MenuHeight;
        Settings.Default.ClentSize = clientSize;
        Settings.Default.Location = Location;
      }
      Settings.Default.IsMiniGui = menuItemViewMiniGui.Checked;
      Settings.Default.IsConsoleOutputVisible = tabControlResults.TabPages.Contains(tabPageConsoleOutput);
      Settings.Default.IsSucceedTestsVisible = tabControlResults.TabPages.Contains(tabPageSucceedTests);
      Settings.Default.IsIgnoredTestsVisible = tabControlResults.TabPages.Contains(tabPageIgnoredTests);
      Settings.Default.IsAbortedTestsVisible = tabControlResults.TabPages.Contains(tabPageAbortedTests);
      Settings.Default.IsFailedTestsVisible = tabControlResults.TabPages.Contains(tabPageFailedTests);
      Settings.Default.IsStatusBarVisible = statusBar.Visible;
      Settings.Default.TabControlResultSelectedIndex = tabControlResults.SelectedIndex;
      Settings.Default.StatusWithLogo = menuItemViewStatusWithLogo.Checked;

      Settings.Default.RepeatTests = (int)numericUpDownRepeat.Value;
      Settings.Default.RepeatForEver = checkBoxForever.Checked;
      Settings.Default.ShuffleTests = checkBoxShuffle.Checked;
      Settings.Default.RandomSeed = (int)numericUpDownSeed.Value;
      Settings.Default.AlsoRunIgnoredTests = checkBoxRunIgneredTests.Checked;

      Settings.Default.Save();
    }

    private void UpdateGui() {
      menuItemFileClose.Enabled = tunitProject != null;
      menuItemFileSave.Enabled = tunitProject != null;
      menuItemFileSaveAs.Enabled = tunitProject != null;
      menuItemFileClose.Enabled = tunitProject != null;
      menuItemFileReloadProject.Enabled = tunitProject != null;
      menuItemFileReloadTests.Enabled = tunitProject != null;
      menuItemProjectAddTUnitFile.Enabled = tunitProject != null;
      menuItemTestsRunAll.Enabled = tunitProject != null && !running;
      menuItemTestsRunSelected.Enabled = tunitProject != null && !running;
      menuItemTestsRunFailed.Enabled = tunitProject != null && tunitProject.FailedCount != 0 && !running;
      menuItemTestsStopRun.Enabled = tunitProject != null && running;
      panelRun.Enabled = tunitProject != null;
      buttonRun.Enabled = tunitProject != null && !running;
      buttonStop.Enabled = tunitProject != null && running;
      numericUpDownRepeat.Enabled = !checkBoxForever.Checked;
      numericUpDownSeed.Enabled = checkBoxShuffle.Checked;

      if (tunitProject == null) {
        statusBarPanelTestCases.Text = "Test Cases : 0";
        statusBarPanelRanTests.Text = "Ran Tests : 0";
        statusBarPanelSucceedTests.Text = "Succeed Tests : 0";
        statusBarPanelIgnoredTests.Text = "Ignored Tests : 0";
        statusBarPanelAbortedTests.Text = "Aborted Tests : 0";
        statusBarPanelFailedTests.Text = "Failed Tests : 0";
        statusBarPanelDuration.Text = $"Time : {TimeSpan.Zero}";

        labelColor.BackColor = System.Drawing.SystemColors.Control;
      } else {
        statusBarPanelTestCases.Text = $"Test Cases : {tunitProject.TestCount}";
        statusBarPanelRanTests.Text = $"Ran Tests : {tunitProject.RanCount}";
        statusBarPanelSucceedTests.Text = $"Succeed Tests : {tunitProject.SucceedCount}";
        statusBarPanelIgnoredTests.Text = $"Ignored Tests : {tunitProject.IngoredCount}";
        statusBarPanelAbortedTests.Text = $"Aborted Tests : {tunitProject.AbortedCount}";
        statusBarPanelFailedTests.Text = $"Failed Tests : {tunitProject.FailedCount}";
        //statusBarPanelDuration.Text = $"Time : {tunitProject.ElapsedTime}";
        statusBarPanelDuration.Text = $"Time : {stopWatch.Elapsed}";

        switch (tunitProject.Status) {
          case TestStatus.NotStarted: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 96, 96, 96); break;
          case TestStatus.Succeed: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 0, 255, 0); break;
          case TestStatus.Ignored: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 0); break;
          case TestStatus.Aborted: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224); break;
          case TestStatus.Failed: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 255, 0, 0); break;
        }

        /*
        switch (tunitProject.Status) {
          case TestStatus.NotStarted: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 95, 95, 95); break;
          case TestStatus.Succeed: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 76, 175, 81); break;
          case TestStatus.Ignored: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 244, 243, 54); break;
          case TestStatus.Aborted: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 195, 195, 195); break;
          case TestStatus.Failed: labelColor.BackColor = System.Drawing.Color.FromArgb(255, 244, 67, 55); break;
        } */
      }

      if (tunitProject != null && Text != string.Format("{0} {1} - TUnit", string.IsNullOrEmpty(tunitProject.FileName) ? tunitProject.Name : System.IO.Path.GetFileNameWithoutExtension(tunitProject.FileName), tunitProject.Saved ? "" : "* ")) Text = string.Format("{0}{1} - TUnit", string.IsNullOrEmpty(tunitProject.FileName) ? tunitProject.Name : System.IO.Path.GetFileNameWithoutExtension(tunitProject.FileName), tunitProject.Saved ? "" : "*");
      if (tunitProject == null && Text != "TUnit") Text = "TUnit";
    }

    Button buttonStop;
    Button buttonRun;
    CheckBox checkBoxForever;
    CheckBox checkBoxRunIgneredTests;
    CheckBox checkBoxShuffle;
    ContextMenu contextMenu;
    Label labelColor;
    Label labelRepeat;
    Label labelSeed;
    Label labelSelectedTest;
    LineSeparator labelRunSeparator1;
    LineSeparator labelRunSeparator2;
    ImageList imageList;
    MenuItem menuItemFileClose;
    MenuItem menuItemFileSave;
    MenuItem menuItemFileSaveAs;
    MenuItem menuItemFileReloadProject;
    MenuItem menuItemFileReloadTests;
    MenuItem menuItemProjectAddTUnitFile;
    MenuItem menuItemProjectTUnitProperties;
    MenuItem menuItemTestsRunAll;
    MenuItem menuItemTestsRunSelected;
    MenuItem menuItemTestsRunFailed;
    MenuItem menuItemTestsStopRun;
    MenuItem menuItemViewFullGui;
    MenuItem menuItemViewMiniGui;
    MenuItem menuItemViewResultTabsConsoleOutput;
    MenuItem menuItemViewResultTabsAbortedTests;
    MenuItem menuItemViewResultTabsFailedTests;
    MenuItem menuItemViewResultTabsIgnoredTests;
    MenuItem menuItemViewResultTabsSucceedTests;
    MenuItem menuItemViewStatusWithLogo;
    MenuItem menuItemViewStatusBar;
    NumericUpDown numericUpDownRepeat;
    NumericUpDown numericUpDownSeed;
    Panel panelRun;
    ProgressBar progressBarRun;
    SplitContainer splitContainer;
    StatusBar statusBar;
    StatusBarPanel statusBarPanelTestCases;
    StatusBarPanel statusBarPanelRanTests;
    StatusBarPanel statusBarPanelSucceedTests;
    StatusBarPanel statusBarPanelIgnoredTests;
    StatusBarPanel statusBarPanelAbortedTests;
    StatusBarPanel statusBarPanelFailedTests;
    StatusBarPanel statusBarPanelDuration;
    RichTextBox richTextBoxOutput;
    TabControl tabControlResults;
    TabPage tabPageConsoleOutput;
    TabPage tabPageSucceedTests;
    TabPage tabPageIgnoredTests;
    TabPage tabPageAbortedTests;
    TabPage tabPageFailedTests;
    System.Windows.Forms.Timer timerUpdateGui;
    TreeView treeViewAbortedTests;
    TreeView treeViewFailedTests;
    TreeView treeViewIgnoredTests;
    TreeView treeViewSucceedTests;
    TreeView treeViewTests;

    private TUnitProject tunitProject = null;
    private bool running = false;
    private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
    private TreeNode selectedTreeNode = null;
  }
}
