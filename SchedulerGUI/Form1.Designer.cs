namespace SchedulerGUI
{
    partial class generatorGUI
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
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.sourceBrowseButton = new System.Windows.Forms.Button();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.sourceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputFolder = new System.Windows.Forms.Label();
            this.outputFolderButton = new System.Windows.Forms.Button();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.outputBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.generateScheduleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(166, 52);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(274, 20);
            this.sourceTextBox.TabIndex = 0;
            // 
            // sourceBrowseButton
            // 
            this.sourceBrowseButton.Location = new System.Drawing.Point(29, 52);
            this.sourceBrowseButton.Name = "sourceBrowseButton";
            this.sourceBrowseButton.Size = new System.Drawing.Size(131, 20);
            this.sourceBrowseButton.TabIndex = 1;
            this.sourceBrowseButton.Text = "Browse";
            this.sourceBrowseButton.UseVisualStyleBackColor = true;
            this.sourceBrowseButton.Click += new System.EventHandler(this.sourceBrowseButton_Click);
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(26, 36);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(70, 13);
            this.sourceLabel.TabIndex = 2;
            this.sourceLabel.Text = "Excel Source";
            // 
            // sourceFileDialog
            // 
            this.sourceFileDialog.FileName = "sourceFile";
            // 
            // outputFolder
            // 
            this.outputFolder.AutoSize = true;
            this.outputFolder.Location = new System.Drawing.Point(26, 92);
            this.outputFolder.Name = "outputFolder";
            this.outputFolder.Size = new System.Drawing.Size(71, 13);
            this.outputFolder.TabIndex = 3;
            this.outputFolder.Text = "Output Folder";
            // 
            // outputFolderButton
            // 
            this.outputFolderButton.Location = new System.Drawing.Point(29, 108);
            this.outputFolderButton.Name = "outputFolderButton";
            this.outputFolderButton.Size = new System.Drawing.Size(131, 20);
            this.outputFolderButton.TabIndex = 4;
            this.outputFolderButton.Text = "Browse";
            this.outputFolderButton.UseVisualStyleBackColor = true;
            this.outputFolderButton.Click += new System.EventHandler(this.outputFolderButton_Click);
            // 
            // OutputFolderTextBox
            // 
            this.outputFolderTextBox.Location = new System.Drawing.Point(169, 108);
            this.outputFolderTextBox.Name = "OutputFolderTextBox";
            this.outputFolderTextBox.Size = new System.Drawing.Size(271, 20);
            this.outputFolderTextBox.TabIndex = 5;
            // 
            // generateScheduleButton
            // 
            this.generateScheduleButton.Location = new System.Drawing.Point(121, 167);
            this.generateScheduleButton.Name = "generateScheduleButton";
            this.generateScheduleButton.Size = new System.Drawing.Size(232, 70);
            this.generateScheduleButton.TabIndex = 6;
            this.generateScheduleButton.Text = "Generate Schedules";
            this.generateScheduleButton.UseVisualStyleBackColor = true;
            this.generateScheduleButton.Click += new System.EventHandler(this.generateScheduleButton_Click);
            // 
            // generatorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 266);
            this.Controls.Add(this.generateScheduleButton);
            this.Controls.Add(this.outputFolderTextBox);
            this.Controls.Add(this.outputFolderButton);
            this.Controls.Add(this.outputFolder);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.sourceBrowseButton);
            this.Controls.Add(this.sourceTextBox);
            this.Name = "generatorGUI";
            this.Text = "Schedule Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Button sourceBrowseButton;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.OpenFileDialog sourceFileDialog;
        private System.Windows.Forms.Label outputFolder;
        private System.Windows.Forms.Button outputFolderButton;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.FolderBrowserDialog outputBrowserDialog;
        private System.Windows.Forms.Button generateScheduleButton;
    }
}

