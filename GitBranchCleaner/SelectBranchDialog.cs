using System.Data;
using System.Diagnostics;

namespace GitBranchCleaner
{
    public partial class SelectBranchDialog : Form
    {
        public string SelectedBranch { get; private set; }

        public SelectBranchDialog(string repositoryPath)
        {
            InitializeComponent();
            LoadBranches(repositoryPath);
        }

        private void LoadBranches(string repositoryPath)
        {
            var branchProcess = new Process();
            branchProcess.StartInfo.FileName = "git";
            branchProcess.StartInfo.Arguments = "branch --format=\"%(refname:short)\"";
            branchProcess.StartInfo.WorkingDirectory = repositoryPath;
            branchProcess.StartInfo.UseShellExecute = false;
            branchProcess.StartInfo.RedirectStandardOutput = true;
            branchProcess.Start();

            var branchOutput = branchProcess.StandardOutput.ReadToEnd();
            branchProcess.WaitForExit();

            var branches = branchOutput.Split('\n')
                                                .Where(s => !string.IsNullOrEmpty(s))
                                                .ToArray();

            foreach (var branch in branches)
            {
                var branchName = branch.Trim();
                if (!branchName.StartsWith("HEAD"))
                {
                    listBranches.Items.Add(branchName);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listBranches.SelectedIndex != -1)
            {
                SelectedBranch = listBranches.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select a branch.", "Branch Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBranches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
