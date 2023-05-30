using System.Diagnostics;

namespace GitBranchCleaner
{
    public partial class MainForm : Form
    {
        private string _repositoryPath;
        private string _selectedBranch;
        private string[] _diffFiles;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _repositoryPath = folderDialog.SelectedPath;
                    lblRepositoryPath.Text = _repositoryPath;
                }
            }
        }

        private void btnSelectBranch_Click(object sender, EventArgs e)
        {
            using (var branchDialog = new SelectBranchDialog(_repositoryPath))
            {
                if (branchDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedBranch = branchDialog.SelectedBranch;
                    lblSelectedBranch.Text = _selectedBranch;
                }
            }
        }

        private void btnDiff_Click(object sender, EventArgs e)
        {
            var diffProcess = new Process();
            diffProcess.StartInfo.FileName = "git";
            diffProcess.StartInfo.Arguments = $"--no-pager diff --name-only master..{_selectedBranch}";
            diffProcess.StartInfo.WorkingDirectory = _repositoryPath;
            diffProcess.StartInfo.UseShellExecute = false;
            diffProcess.StartInfo.RedirectStandardOutput = true;
            diffProcess.Start();

            var diffOutput = diffProcess.StandardOutput.ReadToEnd();
            diffProcess.WaitForExit();

            _diffFiles = diffOutput.Split('\n')
                                    .Where(s => !string.IsNullOrEmpty(s))
                                    .ToArray();
            listDiffFiles.Items.Clear();
            listDiffFiles.Items.AddRange(_diffFiles);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            foreach (var diffFile in listDiffFiles.CheckedItems)
            {
                var checkProcess = new Process();
                checkProcess.StartInfo.FileName = "git";
                checkProcess.StartInfo.Arguments = $"ls-files \"{diffFile.ToString()}\"";
                checkProcess.StartInfo.WorkingDirectory = _repositoryPath;
                checkProcess.StartInfo.RedirectStandardOutput = true;
                checkProcess.StartInfo.UseShellExecute = false;
                checkProcess.StartInfo.CreateNoWindow = true;
                checkProcess.Start();

                string output = checkProcess.StandardOutput.ReadToEnd();
                checkProcess.WaitForExit();

                if (string.IsNullOrEmpty(output))
                {
                    // File doesn't exist in master, prepare for deletion
                    var deleteProcess = new Process();
                    deleteProcess.StartInfo.FileName = "git";
                    deleteProcess.StartInfo.Arguments = $"rm \"{diffFile.ToString()}\"";
                    deleteProcess.StartInfo.WorkingDirectory = _repositoryPath;
                    deleteProcess.Start();
                    deleteProcess.WaitForExit();
                }
                else
                {
                    // File exists in master, restore version
                    var restoreProcess = new Process();
                    restoreProcess.StartInfo.FileName = "git";
                    restoreProcess.StartInfo.Arguments = $"checkout master -- \"{diffFile.ToString()}\"";
                    restoreProcess.StartInfo.WorkingDirectory = _repositoryPath;
                    restoreProcess.Start();
                    restoreProcess.WaitForExit();
                }
            }

            MessageBox.Show("Selected changes have been processed.", "Processing Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            var previewProcess = new Process();
            string commitMessage = $"Commit geneated by APP at {DateTime.UtcNow.ToLongDateString()} ";
            previewProcess.StartInfo.FileName = "git";
            previewProcess.StartInfo.Arguments = $"--no-pager diff --cached";
            previewProcess.StartInfo.WorkingDirectory = _repositoryPath;
            previewProcess.StartInfo.UseShellExecute = false;
            previewProcess.StartInfo.RedirectStandardOutput = true;
            previewProcess.Start();

            var previewOutput = previewProcess.StandardOutput.ReadToEnd();
            previewProcess.WaitForExit();

            var commitPreviewDialog = new CommitPreviewDialog(commitMessage, previewOutput);
            if (commitPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                var commitProcess = new Process();
                commitProcess.StartInfo.FileName = "git";
                commitProcess.StartInfo.Arguments = $"commit -m \"{commitMessage}\"";
                commitProcess.StartInfo.WorkingDirectory = _repositoryPath;
                commitProcess.Start();
                commitProcess.WaitForExit();

                MessageBox.Show("Commit has been made successfully.", "Commit Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _repositoryPath = string.Empty;
                _selectedBranch = string.Empty;
                _diffFiles = null;

                lblRepositoryPath.Text = string.Empty;
                lblSelectedBranch.Text = string.Empty;
                listDiffFiles.Items.Clear();
            }

            this.Show();
            this.WindowState = FormWindowState.Normal; ;
        }

        private void cmdPushPull_Click(object sender, EventArgs e)
        {
            PerformGitPush();
            PerformGitPull();
            MessageBox.Show("Push/Pull OK", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PerformGitPush()
        {
            string branchName = GetCurrentBranchName();

            // Execute the Git push command
            string gitCommand = $"push origin {branchName}";
            ExecuteGitCommand(gitCommand);
        }

        public void PerformGitPull()
        {
            string branchName = GetCurrentBranchName();

            // Execute the Git pull command
            string gitCommand = $"pull origin {branchName}";
            ExecuteGitCommand(gitCommand);
        }

        private string GetCurrentBranchName()
        {
            // Retrieve the current branch name using Git command
            string gitCommand = "rev-parse --abbrev-ref HEAD";
            string branchName = ExecuteGitCommand(gitCommand);

            string toRet = branchName.Trim();

            if (toRet == _selectedBranch)
                return toRet;
            
            MessageBox.Show("The current branch does not match the one set in the application.","Information");
            return string.Empty;
        }

        private string ExecuteGitCommand(string command)
        {
            string gitExecutable = "git";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = gitExecutable,
                Arguments = command,
                WorkingDirectory = _repositoryPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}