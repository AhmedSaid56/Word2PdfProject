using MigraDoc.DocumentObjectModel;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Word2Pdf_BusinessLayer.Models;

namespace Word2Pdf_BusinessLayer.Services
{
    public static class clsPDFGeneratorService
    {

        #region Helper Methods

        private static void OpenPdfFile(string pdfPath)
        {
            if (!File.Exists(pdfPath))
                throw new FileNotFoundException("PDF file not found.", pdfPath);

            var psi = new ProcessStartInfo
            {
                FileName = pdfPath,
                UseShellExecute = true
            };

            Process.Start(psi);
        }

        private static void OpenFileLocation(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            Process.Start("explorer.exe", $"/select,\"{filePath}\"");
        }

        private static string GetUniqueFilePath(string originalPath)
        {
            string directory = Path.GetDirectoryName(originalPath);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(originalPath);
            string extension = Path.GetExtension(originalPath);

            string newPath = originalPath;
            int count = 1;

            while (File.Exists(newPath))
            {
                newPath = Path.Combine(directory, $"{fileNameWithoutExt} ({count}){extension}");
                count++;
            }

            return newPath;
        }
        #endregion

        public static Task OpenPdfFileAsync(string pdfPath)
        {
            return Task.Run(() =>
            {
                OpenPdfFile(pdfPath);
            });
        }

        public static Task OpenFileLocationAsync(string filePath)
        {
            return Task.Run(() =>
            {
                OpenFileLocation(filePath);
            });
        }

        public static Task ConvertWordModelToPdfAsync(clsWordDocumentModel model, string outputPath)
        {
            return Task.Run(() =>
            {
                QuestPDF.Settings.License = LicenseType.Community;

                var fontPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Fonts",
                    "Cairo-Regular.ttf.ttf"
                );

                if (!File.Exists(fontPath))
                    throw new FileNotFoundException("Font not found: " + fontPath);

                outputPath = GetUniqueFilePath(outputPath);

                using (var fontStream = File.OpenRead(fontPath))
                {
                    FontManager.RegisterFont(fontStream);

                    QuestPDF.Fluent.Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);

                            page.DefaultTextStyle(x =>
                                x.FontFamily("Cairo").FontSize(12)
                            );

                            page.Content().Column(col =>
                            {
                                foreach (var paragraph in model.Paragraphs)
                                {
                                    col.Item().Element(e =>
                                    {

                                        bool hasArabic = paragraph.Text.Any(c => c >= 0x0600 && c <= 0x06FF);
                                        bool hasNumber = paragraph.IsNumbered; 

                                        string finalText;

                                        if (hasArabic)
                                        {
                                            if (paragraph.Number > 0)
                                            {
                                                finalText = "\u202B" + $"{paragraph.Number}. {paragraph.Text.TrimStart()}";
                                            }
                                            else
                                            {
                                                finalText = "\u202B" + paragraph.Text.TrimStart(); // نص عربي فقط RTL
                                            }
                                        }
                                        else if (hasNumber)
                                        {
                                            if (paragraph.Number > 0)
                                                finalText = $"{paragraph.Number}. {paragraph.Text}";
                                            else
                                                finalText = paragraph.Text;
                                        }
                                        else
                                        {
                                            finalText = paragraph.Text;
                                        }

                                        e.Text(text =>
                                        {
                                            var span = text.Span(finalText)
                                                           .FontFamily("Cairo")
                                                           .FontSize((float)paragraph.FontSize);

                                            if (paragraph.IsBold) span.Bold();
                                            if (paragraph.IsItalic) span.Italic();

                                            if (hasArabic)
                                                text.AlignRight();
                                            else
                                            {
                                                switch (paragraph.Alignment)
                                                {
                                                    case ParagraphAlignment.Center: text.AlignCenter(); break;
                                                    case ParagraphAlignment.Right: text.AlignRight(); break;
                                                    case ParagraphAlignment.Justify: text.Justify(); break;
                                                    default: text.AlignLeft(); break;
                                                }
                                            }
                                        });
                                    });

                                }
                            });

                            page.Footer()
                                .AlignCenter()
                                .Text(x =>
                                {
                                    x.Span("Page ");
                                    x.CurrentPageNumber();
                                    x.Span(" / ");
                                    x.TotalPages();
                                });
                        });
                    })
                    .GeneratePdf(outputPath);
                }
            });
        }

    }
}
