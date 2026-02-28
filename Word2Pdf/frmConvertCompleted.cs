using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word2Pdf_BusinessLayer.Services;

namespace Word2Pdf
{
    public partial class frmConvertCompleted : Form
    {
        private string _CurrentOutputPath;

        public frmConvertCompleted(string outputPath)
        {
            InitializeComponent();
            _CurrentOutputPath = outputPath;
        }

        private async Task HandleOpenPdfFile()
        {
            lblOpenProgress.Text = "Opening PDF File...";

            if (File.Exists(_CurrentOutputPath))
            {
                await clsPDFGeneratorService.OpenPdfFileAsync(_CurrentOutputPath);
                await Task.Delay(1000); // 1 second
                lblOpenProgress.Text = string.Empty;
            }
            else
                MessageBox.Show("The File is Not Found!!!!!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task HandleOpenLocation()
        {
            lblOpenProgress.Text = "Opening File Location...";

            if (File.Exists(_CurrentOutputPath))
            {
                await clsPDFGeneratorService.OpenFileLocationAsync(_CurrentOutputPath);
                await Task.Delay(1000); // 1 second
                lblOpenProgress.Text = string.Empty;
            }
            else
                MessageBox.Show("The File is Not Found!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnOpenFileLocation_Click(object sender, EventArgs e)
        {
            await HandleOpenLocation();
        }

        private async void btnOpenPDF_Click(object sender, EventArgs e)
        {
            await HandleOpenPdfFile();
        }

    }
}
