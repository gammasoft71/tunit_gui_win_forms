namespace tunit {
  partial class FormTestProperties {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.buttonOk = new System.Windows.Forms.Button();
      this.labelStatus = new System.Windows.Forms.Label();
      this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.labelTime = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
      this.labelTestName = new System.Windows.Forms.Label();
      this.richTextBoxFile = new System.Windows.Forms.RichTextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.labelTestFixtureName = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.richTextBoxStackTrace = new System.Windows.Forms.RichTextBox();
      this.label9 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonOk
      // 
      this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOk.Location = new System.Drawing.Point(201, 337);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 0;
      this.buttonOk.Text = "Ok";
      this.buttonOk.UseVisualStyleBackColor = true;
      // 
      // labelStatus
      // 
      this.labelStatus.AutoSize = true;
      this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelStatus.Location = new System.Drawing.Point(82, 22);
      this.labelStatus.Name = "labelStatus";
      this.labelStatus.Size = new System.Drawing.Size(59, 13);
      this.labelStatus.TabIndex = 2;
      this.labelStatus.Text = "Not started";
      // 
      // richTextBoxResult
      // 
      this.richTextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBoxResult.BackColor = System.Drawing.SystemColors.Control;
      this.richTextBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.richTextBoxResult.Location = new System.Drawing.Point(82, 154);
      this.richTextBoxResult.Name = "richTextBoxResult";
      this.richTextBoxResult.ReadOnly = true;
      this.richTextBoxResult.Size = new System.Drawing.Size(194, 67);
      this.richTextBoxResult.TabIndex = 3;
      this.richTextBoxResult.Text = "";
      this.richTextBoxResult.WordWrap = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(14, 275);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Duration:";
      // 
      // labelTime
      // 
      this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTime.BackColor = System.Drawing.SystemColors.Control;
      this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTime.Location = new System.Drawing.Point(82, 274);
      this.labelTime.Name = "labelTime";
      this.labelTime.Size = new System.Drawing.Size(194, 13);
      this.labelTime.TabIndex = 5;
      this.labelTime.Text = "00:00:00";
      this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(14, 154);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(40, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Result:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 66);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(26, 13);
      this.label6.TabIndex = 7;
      this.label6.Text = "File:";
      // 
      // pictureBoxStatus
      // 
      this.pictureBoxStatus.Image = global::tunit.Properties.Resources.NotStarted;
      this.pictureBoxStatus.Location = new System.Drawing.Point(15, 12);
      this.pictureBoxStatus.Name = "pictureBoxStatus";
      this.pictureBoxStatus.Size = new System.Drawing.Size(32, 32);
      this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxStatus.TabIndex = 1;
      this.pictureBoxStatus.TabStop = false;
      // 
      // labelTestName
      // 
      this.labelTestName.AutoSize = true;
      this.labelTestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTestName.Location = new System.Drawing.Point(82, 90);
      this.labelTestName.Name = "labelTestName";
      this.labelTestName.Size = new System.Drawing.Size(35, 13);
      this.labelTestName.TabIndex = 9;
      this.labelTestName.Text = "Name";
      // 
      // richTextBoxFile
      // 
      this.richTextBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBoxFile.BackColor = System.Drawing.SystemColors.Control;
      this.richTextBoxFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.richTextBoxFile.Location = new System.Drawing.Point(82, 66);
      this.richTextBoxFile.Name = "richTextBoxFile";
      this.richTextBoxFile.ReadOnly = true;
      this.richTextBoxFile.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBoxFile.Size = new System.Drawing.Size(194, 13);
      this.richTextBoxFile.TabIndex = 10;
      this.richTextBoxFile.Text = "FileName";
      this.richTextBoxFile.WordWrap = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 90);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Test:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 114);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Test Fixture:";
      // 
      // labelTestFixtureName
      // 
      this.labelTestFixtureName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTestFixtureName.AutoSize = true;
      this.labelTestFixtureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTestFixtureName.Location = new System.Drawing.Point(82, 114);
      this.labelTestFixtureName.Name = "labelTestFixtureName";
      this.labelTestFixtureName.Size = new System.Drawing.Size(35, 13);
      this.labelTestFixtureName.TabIndex = 12;
      this.labelTestFixtureName.Text = "Name";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.BackColor = System.Drawing.Color.Black;
      this.label5.Location = new System.Drawing.Point(12, 54);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(264, 1);
      this.label5.TabIndex = 14;
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.BackColor = System.Drawing.Color.Black;
      this.label7.Location = new System.Drawing.Point(12, 140);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(264, 1);
      this.label7.TabIndex = 15;
      // 
      // label8
      // 
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label8.BackColor = System.Drawing.Color.Black;
      this.label8.Location = new System.Drawing.Point(12, 262);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(264, 1);
      this.label8.TabIndex = 16;
      // 
      // richTextBoxStackTrace
      // 
      this.richTextBoxStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBoxStackTrace.BackColor = System.Drawing.SystemColors.Control;
      this.richTextBoxStackTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxStackTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.richTextBoxStackTrace.Location = new System.Drawing.Point(82, 236);
      this.richTextBoxStackTrace.Name = "richTextBoxStackTrace";
      this.richTextBoxStackTrace.ReadOnly = true;
      this.richTextBoxStackTrace.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBoxStackTrace.Size = new System.Drawing.Size(194, 13);
      this.richTextBoxStackTrace.TabIndex = 18;
      this.richTextBoxStackTrace.Text = "CallStack";
      this.richTextBoxStackTrace.WordWrap = false;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(11, 236);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(69, 13);
      this.label9.TabIndex = 17;
      this.label9.Text = "Stack Trace:";
      // 
      // FormTestProperties
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonOk;
      this.ClientSize = new System.Drawing.Size(292, 372);
      this.Controls.Add(this.richTextBoxStackTrace);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.labelTestFixtureName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.richTextBoxFile);
      this.Controls.Add(this.labelTestName);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.labelTime);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.richTextBoxResult);
      this.Controls.Add(this.labelStatus);
      this.Controls.Add(this.pictureBoxStatus);
      this.Controls.Add(this.buttonOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormTestProperties";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Properties";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.PictureBox pictureBoxStatus;
    private System.Windows.Forms.Label labelStatus;
    private System.Windows.Forms.RichTextBox richTextBoxResult;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label labelTime;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label labelTestName;
    private System.Windows.Forms.RichTextBox richTextBoxFile;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label labelTestFixtureName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.RichTextBox richTextBoxStackTrace;
    private System.Windows.Forms.Label label9;
  }
}