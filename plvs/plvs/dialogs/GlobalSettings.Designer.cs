﻿namespace Atlassian.plvs.dialogs {
    partial class GlobalSettings
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
            this.checkAutoupdate = new System.Windows.Forms.CheckBox();
            this.checkUnstable = new System.Windows.Forms.CheckBox();
            this.checkStats = new System.Windows.Forms.CheckBox();
            this.buttonCheckNow = new System.Windows.Forms.Button();
            this.radioStable = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioUnstable = new System.Windows.Forms.RadioButton();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numericJiraBatchSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericJiraBatchSize)).BeginInit();
            this.SuspendLayout();
            // 
            // checkAutoupdate
            // 
            this.checkAutoupdate.AutoSize = true;
            this.checkAutoupdate.Location = new System.Drawing.Point(6, 19);
            this.checkAutoupdate.Name = "checkAutoupdate";
            this.checkAutoupdate.Size = new System.Drawing.Size(264, 17);
            this.checkAutoupdate.TabIndex = 0;
            this.checkAutoupdate.Text = "Automatically check for availability of new versions";
            this.checkAutoupdate.UseVisualStyleBackColor = true;
            this.checkAutoupdate.CheckedChanged += new System.EventHandler(this.checkAutoupdate_CheckedChanged);
            // 
            // checkUnstable
            // 
            this.checkUnstable.AutoSize = true;
            this.checkUnstable.Location = new System.Drawing.Point(22, 43);
            this.checkUnstable.Name = "checkUnstable";
            this.checkUnstable.Size = new System.Drawing.Size(239, 17);
            this.checkUnstable.TabIndex = 1;
            this.checkUnstable.Text = "Check stable versions and snaphost versions";
            this.checkUnstable.UseVisualStyleBackColor = true;
            // 
            // checkStats
            // 
            this.checkStats.AutoSize = true;
            this.checkStats.Location = new System.Drawing.Point(22, 67);
            this.checkStats.Name = "checkStats";
            this.checkStats.Size = new System.Drawing.Size(133, 17);
            this.checkStats.TabIndex = 2;
            this.checkStats.Text = "Report usage statistics";
            this.checkStats.UseVisualStyleBackColor = true;
            // 
            // buttonCheckNow
            // 
            this.buttonCheckNow.Location = new System.Drawing.Point(358, 19);
            this.buttonCheckNow.Name = "buttonCheckNow";
            this.buttonCheckNow.Size = new System.Drawing.Size(162, 23);
            this.buttonCheckNow.TabIndex = 3;
            this.buttonCheckNow.Text = "Check Now";
            this.buttonCheckNow.UseVisualStyleBackColor = true;
            this.buttonCheckNow.Click += new System.EventHandler(this.buttonCheckNow_Click);
            // 
            // radioStable
            // 
            this.radioStable.AutoSize = true;
            this.radioStable.Location = new System.Drawing.Point(358, 48);
            this.radioStable.Name = "radioStable";
            this.radioStable.Size = new System.Drawing.Size(93, 17);
            this.radioStable.TabIndex = 4;
            this.radioStable.TabStop = true;
            this.radioStable.Text = "Stable Version";
            this.radioStable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioUnstable);
            this.groupBox1.Controls.Add(this.radioStable);
            this.groupBox1.Controls.Add(this.checkAutoupdate);
            this.groupBox1.Controls.Add(this.buttonCheckNow);
            this.groupBox1.Controls.Add(this.checkUnstable);
            this.groupBox1.Controls.Add(this.checkStats);
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automatic Updates";
            // 
            // radioUnstable
            // 
            this.radioUnstable.AutoSize = true;
            this.radioUnstable.Location = new System.Drawing.Point(358, 71);
            this.radioUnstable.Name = "radioUnstable";
            this.radioUnstable.Size = new System.Drawing.Size(162, 17);
            this.radioUnstable.TabIndex = 5;
            this.radioUnstable.TabStop = true;
            this.radioUnstable.Text = "Stable and Snapshot Version";
            this.radioUnstable.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(403, 292);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(484, 292);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 274);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(538, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.numericJiraBatchSize);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 248);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "JIRA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numericJiraBatchSize
            // 
            this.numericJiraBatchSize.Location = new System.Drawing.Point(114, 14);
            this.numericJiraBatchSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericJiraBatchSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericJiraBatchSize.Name = "numericJiraBatchSize";
            this.numericJiraBatchSize.Size = new System.Drawing.Size(60, 20);
            this.numericJiraBatchSize.TabIndex = 0;
            this.numericJiraBatchSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Issues Batch Size";
            // 
            // GlobalSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 327);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GlobalSettings";
            this.ShowIcon = false;
            this.Text = "Global Settings";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GlobalSettings_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericJiraBatchSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkAutoupdate;
        private System.Windows.Forms.CheckBox checkUnstable;
        private System.Windows.Forms.CheckBox checkStats;
        private System.Windows.Forms.Button buttonCheckNow;
        private System.Windows.Forms.RadioButton radioStable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioUnstable;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericJiraBatchSize;

    }
}