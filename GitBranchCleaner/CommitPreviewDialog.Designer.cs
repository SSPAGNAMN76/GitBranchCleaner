namespace GitBranchCleaner
{
    partial class CommitPreviewDialog
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
            lblCommitMessage = new Label();
            txtPreview = new TextBox();
            btnOK = new Button();
            SuspendLayout();
            // 
            // lblCommitMessage
            // 
            lblCommitMessage.Location = new Point(12, 25);
            lblCommitMessage.Name = "lblCommitMessage";
            lblCommitMessage.Size = new Size(384, 54);
            lblCommitMessage.TabIndex = 0;
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(12, 104);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.Size = new Size(384, 289);
            txtPreview.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(14, 406);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click_1;
            // 
            // CommitPreviewDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 450);
            Controls.Add(btnOK);
            Controls.Add(txtPreview);
            Controls.Add(lblCommitMessage);
            Name = "CommitPreviewDialog";
            Text = "Commit Preview Dialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCommitMessage;
        private TextBox txtPreview;
        private Button btnOK;
    }
}