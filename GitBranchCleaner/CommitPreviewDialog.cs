namespace GitBranchCleaner
{
    public partial class CommitPreviewDialog : Form
    {
        public CommitPreviewDialog(string commitMessage, string previewOutput)
        {
            InitializeComponent();

            lblCommitMessage.Text = commitMessage;
            txtPreview.Text = previewOutput;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
