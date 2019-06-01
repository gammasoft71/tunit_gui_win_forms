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
      this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
      this.labelStatus = new System.Windows.Forms.Label();
      this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.labelTime = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.labelFile = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonOk
      // 
      this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOk.Location = new System.Drawing.Point(171, 315);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 0;
      this.buttonOk.Text = "Ok";
      this.buttonOk.UseVisualStyleBackColor = true;
      // 
      // pictureBoxStatus
      // 
      this.pictureBoxStatus.Image = global::tunit.Properties.Resources.NotStarted;
      this.pictureBoxStatus.Location = new System.Drawing.Point(13, 13);
      this.pictureBoxStatus.Name = "pictureBoxStatus";
      this.pictureBoxStatus.Size = new System.Drawing.Size(32, 32);
      this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxStatus.TabIndex = 1;
      this.pictureBoxStatus.TabStop = false;
      // 
      // labelStatus
      // 
      this.labelStatus.AutoSize = true;
      this.labelStatus.Location = new System.Drawing.Point(61, 24);
      this.labelStatus.Name = "labelStatus";
      this.labelStatus.Size = new System.Drawing.Size(59, 13);
      this.labelStatus.TabIndex = 2;
      this.labelStatus.Text = "Not started";
      // 
      // richTextBoxResult
      // 
      this.richTextBoxResult.Location = new System.Drawing.Point(13, 117);
      this.richTextBoxResult.Name = "richTextBoxResult";
      this.richTextBoxResult.ReadOnly = true;
      this.richTextBoxResult.Size = new System.Drawing.Size(233, 96);
      this.richTextBoxResult.TabIndex = 3;
      this.richTextBoxResult.Text = "";
      this.richTextBoxResult.WordWrap = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 232);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Time";
      // 
      // labelTime
      // 
      this.labelTime.BackColor = System.Drawing.SystemColors.Window;
      this.labelTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labelTime.Location = new System.Drawing.Point(49, 230);
      this.labelTime.Name = "labelTime";
      this.labelTime.Size = new System.Drawing.Size(87, 15);
      this.labelTime.TabIndex = 5;
      this.labelTime.Text = "0";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(15, 101);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(37, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Result";
      // 
      // labelFile
      // 
      this.labelFile.BackColor = System.Drawing.SystemColors.Window;
      this.labelFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labelFile.Location = new System.Drawing.Point(42, 70);
      this.labelFile.Name = "labelFile";
      this.labelFile.Size = new System.Drawing.Size(204, 15);
      this.labelFile.TabIndex = 8;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(13, 71);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(23, 13);
      this.label6.TabIndex = 7;
      this.label6.Text = "File";
      // 
      // FormTestProperties
      // 
      this.AcceptButton = this.buttonOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(258, 350);
      this.Controls.Add(this.labelFile);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.labelTime);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.richTextBoxResult);
      this.Controls.Add(this.labelStatus);
      this.Controls.Add(this.pictureBoxStatus);
      this.Controls.Add(this.buttonOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "FormTestProperties";
      this.Text = "Test Properties";
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
    private System.Windows.Forms.Label labelFile;
    private System.Windows.Forms.Label label6;
  }
}