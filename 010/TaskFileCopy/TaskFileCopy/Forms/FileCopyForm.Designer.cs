namespace TaskFileCopy
{
    partial class FileCopyForm
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDestinition = new System.Windows.Forms.Label();
            this.tbxSource = new System.Windows.Forms.TextBox();
            this.tbxDestinition = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.SelectFolder = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progbarFileCopy = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SourceLabel
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(26, 30);
            this.lblSource.Name = "SourceLabel";
            this.lblSource.Size = new System.Drawing.Size(44, 13);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source:";
            // 
            // DestinitionLabel
            // 
            this.lblDestinition.AutoSize = true;
            this.lblDestinition.Location = new System.Drawing.Point(26, 72);
            this.lblDestinition.Name = "DestinitionLabel";
            this.lblDestinition.Size = new System.Drawing.Size(59, 13);
            this.lblDestinition.TabIndex = 1;
            this.lblDestinition.Text = "Destinition:";
            // 
            // SourceTextBox
            // 
            this.tbxSource.Location = new System.Drawing.Point(90, 27);
            this.tbxSource.Name = "SourceTextBox";
            this.tbxSource.Size = new System.Drawing.Size(437, 20);
            this.tbxSource.TabIndex = 2;
            // 
            // DestinitionTextBox
            // 
            this.tbxDestinition.Location = new System.Drawing.Point(90, 69);
            this.tbxDestinition.Name = "DestinitionTextBox";
            this.tbxDestinition.Size = new System.Drawing.Size(437, 20);
            this.tbxDestinition.TabIndex = 4;
            // 
            // SelectFileBtn
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(533, 25);
            this.btnSelectFile.Name = "SelectFileBtn";
            this.btnSelectFile.Size = new System.Drawing.Size(70, 23);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "File...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // SelectFolderBtn
            // 
            this.SelectFolder.Location = new System.Drawing.Point(533, 67);
            this.SelectFolder.Name = "SelectFolderBtn";
            this.SelectFolder.Size = new System.Drawing.Size(70, 23);
            this.SelectFolder.TabIndex = 5;
            this.SelectFolder.Text = "Folder...";
            this.SelectFolder.UseVisualStyleBackColor = true;
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolderBtn_Click);
            // 
            // StartBtn
            // 
            this.btnStart.Location = new System.Drawing.Point(296, 106);
            this.btnStart.Name = "StartBtn";
            this.btnStart.Size = new System.Drawing.Size(70, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // CancelBtn
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 106);
            this.btnCancel.Name = "CancelBtn";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // FileCopyProgressBar
            // 
            this.progbarFileCopy.Location = new System.Drawing.Point(29, 145);
            this.progbarFileCopy.Name = "FileCopyProgressBar";
            this.progbarFileCopy.Size = new System.Drawing.Size(574, 20);
            this.progbarFileCopy.TabIndex = 8;
            // 
            // StatusLabel
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(28, 177);
            this.lblStatus.Name = "StatusLabel";
            this.lblStatus.Size = new System.Drawing.Size(81, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Progress Status";
            // 
            // FileCopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 145);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progbarFileCopy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.SelectFolder);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.tbxDestinition);
            this.Controls.Add(this.tbxSource);
            this.Controls.Add(this.lblDestinition);
            this.Controls.Add(this.lblSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FileCopyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Copy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestinition;
        private System.Windows.Forms.TextBox tbxSource;
        private System.Windows.Forms.TextBox tbxDestinition;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button SelectFolder;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progbarFileCopy;
        private System.Windows.Forms.Label lblStatus;
    }
}

