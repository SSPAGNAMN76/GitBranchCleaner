namespace GitBranchCleaner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBrowse = new Button();
            lblRepositoryPath = new Label();
            lblSelectedBranch = new Label();
            btnSelectBranch = new Button();
            btnDiff = new Button();
            btnRestore = new Button();
            listDiffFiles = new CheckedListBox();
            btnCommit = new Button();
            cmdPushPull = new Button();
            SuspendLayout();
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(39, 35);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(157, 36);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Select Repo Folder";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // lblRepositoryPath
            // 
            lblRepositoryPath.Location = new Point(202, 35);
            lblRepositoryPath.Name = "lblRepositoryPath";
            lblRepositoryPath.Size = new Size(300, 36);
            lblRepositoryPath.TabIndex = 1;
            // 
            // lblSelectedBranch
            // 
            lblSelectedBranch.Location = new Point(202, 77);
            lblSelectedBranch.Name = "lblSelectedBranch";
            lblSelectedBranch.Size = new Size(300, 36);
            lblSelectedBranch.TabIndex = 3;
            // 
            // btnSelectBranch
            // 
            btnSelectBranch.Location = new Point(39, 77);
            btnSelectBranch.Name = "btnSelectBranch";
            btnSelectBranch.Size = new Size(157, 36);
            btnSelectBranch.TabIndex = 2;
            btnSelectBranch.Text = "Select Branch";
            btnSelectBranch.UseVisualStyleBackColor = true;
            btnSelectBranch.Click += btnSelectBranch_Click;
            // 
            // btnDiff
            // 
            btnDiff.Location = new Point(38, 123);
            btnDiff.Name = "btnDiff";
            btnDiff.Size = new Size(158, 29);
            btnDiff.TabIndex = 4;
            btnDiff.Text = "Perform Diff";
            btnDiff.UseVisualStyleBackColor = true;
            btnDiff.Click += btnDiff_Click;
            // 
            // btnRestore
            // 
            btnRestore.Location = new Point(618, 164);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(211, 29);
            btnRestore.TabIndex = 6;
            btnRestore.Text = "Perform Restore To Master";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // listDiffFiles
            // 
            listDiffFiles.FormattingEnabled = true;
            listDiffFiles.Location = new Point(39, 164);
            listDiffFiles.Name = "listDiffFiles";
            listDiffFiles.Size = new Size(573, 246);
            listDiffFiles.TabIndex = 7;
            // 
            // btnCommit
            // 
            btnCommit.Location = new Point(619, 199);
            btnCommit.Name = "btnCommit";
            btnCommit.Size = new Size(210, 26);
            btnCommit.TabIndex = 8;
            btnCommit.Text = "Commit";
            btnCommit.UseVisualStyleBackColor = true;
            btnCommit.Click += btnCommit_Click;
            // 
            // cmdPushPull
            // 
            cmdPushPull.Location = new Point(618, 231);
            cmdPushPull.Name = "cmdPushPull";
            cmdPushPull.Size = new Size(210, 26);
            cmdPushPull.TabIndex = 9;
            cmdPushPull.Text = "Push-Pull";
            cmdPushPull.UseVisualStyleBackColor = true;
            cmdPushPull.Click += cmdPushPull_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 469);
            Controls.Add(cmdPushPull);
            Controls.Add(btnCommit);
            Controls.Add(listDiffFiles);
            Controls.Add(btnRestore);
            Controls.Add(btnDiff);
            Controls.Add(lblSelectedBranch);
            Controls.Add(btnSelectBranch);
            Controls.Add(lblRepositoryPath);
            Controls.Add(btnBrowse);
            Name = "MainForm";
            Text = "Git Branch Cleaner";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBrowse;
        private Label lblRepositoryPath;
        private Label lblSelectedBranch;
        private Button btnSelectBranch;
        private Button btnDiff;
        private Button btnRestore;
        private CheckedListBox listDiffFiles;
        private Button btnCommit;
        private Button cmdPushPull;
    }
}