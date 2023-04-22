namespace DiscScan
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1= new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textSourceFolder.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DiscScanner ds = new DiscScanner();
            ds.ScanDirectory(textSourceFolder.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textDestinationFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DiscScanner ds = new DiscScanner();
            ds.SyncDirectory(textSourceFolder.Text, textDestinationFolder.Text);
        }
    }
}