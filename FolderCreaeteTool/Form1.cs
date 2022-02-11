namespace FolderCreaeteTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    txtDest.Text = dlg.SelectedPath;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDest.Text))
            {
                MessageBox.Show("Dest Dir is Empty");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is Empty");
                return;
            }

            try
            {
                var path = Path.Combine(txtDest.Text.Trim(), txtName.Text.Trim());
                var cnt = (int)nmCount.Value;
                for (var i = 0; i < cnt; i++)
                {
                    Directory.CreateDirectory(path + i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}