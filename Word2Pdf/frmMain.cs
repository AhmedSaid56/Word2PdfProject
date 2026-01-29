using System;
using System.IO;
using System.Windows.Forms;
using Word2Pdf_BusinessLayer;
using Word2Pdf_BusinessLayer.Services;

namespace Word2Pdf
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private string ChooseWordFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose File Word";
                openFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK &&
                    !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    return openFileDialog.FileName;
                }

                MessageBox.Show(
                    "No Word file was selected. Operation cancelled.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return string.Empty; 
            }
        }

        private void RefreshMain()
        {
            lblConverting.Text = string.Empty;
        }

        private async void HandelConvertWordToPdf()
        {
            RefreshMain();

            string filePath = ChooseWordFile();

            if (string.IsNullOrEmpty(filePath))
                return;

            string outputPath = Path.ChangeExtension(filePath, ".pdf");

            try
            {

                lblConverting.Text = "Converting in progress...";

                var model = await clsWordReaderService.ReadWordFileAsync(filePath);

                await clsPDFGeneratorService.ConvertWordModelToPdfAsync(model, outputPath);

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The selected Word file could not be found.\nPlease choose a valid file.",
                    "File Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "The file is currently open or used by another application.\nPlease close it and try again.",
                    "File In Use",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            catch(Exception)
            {
                MessageBox.Show(
                   "Something went wrong while converting the file.\nPlease contact support if the problem persists.",
                   "Unexpected Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                );
            }

            lblConverting.Text = "  Convert Completed.";
            frmConvertCompleted convertCompleted = new frmConvertCompleted(outputPath);
            convertCompleted.ShowDialog();

            RefreshMain();
        }

        private void btnChooseFiles_Click(object sender, EventArgs e)
        {
            HandelConvertWordToPdf();
        }

    }
}
