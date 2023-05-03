using DiscScan.Models;
using System.IO;

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
        /// <summary>
        /// Scan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DiscScanner ds = new DiscScanner();
            List<ScanInfo> scanInfos = ds.ScanDirectory(textSourceFolder.Text);
            if (scanInfos.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScanInfo.csv"), false))
                {
                    foreach (ScanInfo scanInfo in scanInfos)
                    {
                        scanInfo.ToCSV(writer);
                    }
                }
            }
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