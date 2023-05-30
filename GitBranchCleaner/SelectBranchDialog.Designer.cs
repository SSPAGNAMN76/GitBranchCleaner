namespace GitBranchCleaner
{
    partial class SelectBranchDialog
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
            listBranches = new ListBox();
            btnOK = new Button();
            SuspendLayout();
            // 
            // listBranches
            // 
            listBranches.FormattingEnabled = true;
            listBranches.ItemHeight = 20;
            listBranches.Location = new Point(21, 16);
            listBranches.Name = "listBranches";
            listBranches.Size = new Size(265, 404);
            listBranches.TabIndex = 0;
            listBranches.SelectedIndexChanged += listBranches_SelectedIndexChanged;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(22, 435);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 38);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK!";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // SelectBranchDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 488);
            Controls.Add(btnOK);
            Controls.Add(listBranches);
            Name = "SelectBranchDialog";
            Text = "Select Branch Dialog";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBranches;
        private Button btnOK;
    }
}