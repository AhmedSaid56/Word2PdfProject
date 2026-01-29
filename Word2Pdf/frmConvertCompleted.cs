using System;
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
            await clsPDFGeneratorService.OpenPdfFileAsync(_CurrentOutputPath);
            await Task.Delay(1000); // 1 second
            lblOpenProgress.Text = string.Empty;
        }

        private async Task HandleOpenLocation()
        {
            lblOpenProgress.Text = "Opening File Location...";
            await clsPDFGeneratorService.OpenFileLocationAsync(_CurrentOutputPath);
            await Task.Delay(1000); // 1 second
            lblOpenProgress.Text = string.Empty;
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
