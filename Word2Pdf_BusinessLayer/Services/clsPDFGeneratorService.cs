using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Word2Pdf_BusinessLayer.Models;

namespace Word2Pdf_BusinessLayer.Services
{
    public static class clsPDFGeneratorService
    {

        #region Helper Methods
        private static bool IsArabic(string text)
        {
            foreach (char c in text)
            {
                if (c >= 0x0600 && c <= 0x06FF)
                    return true;
            }
            return false;
        }

        private static string FixArabicNumbers(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            if (IsArabic(text) && char.IsDigit(text.TrimStart()[0]))
            {
                return "\u200F" + text;
            }

            return text;
        }

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

                    Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(2, Unit.Centimetre);

                            page.DefaultTextStyle(x =>
                                x.FontFamily("Cairo").FontSize(12)
                            );

                            page.Content().Column(col =>
                            {
                                foreach (var paragraph in model.Paragraphs)
                                {
                                    col.Item().Text(text =>
                                    {
                                        var fixedText = FixArabicNumbers(paragraph.Text);
                                        var span = text.Span(fixedText);

                                        if (paragraph.IsBold)
                                            span.Bold();

                                        if (paragraph.IsItalic)
                                            span.Italic();

                                        span.FontSize((float)paragraph.FontSize);

                                        if (IsArabic(paragraph.Text))
                                            text.AlignRight();
                                        else
                                            text.AlignLeft();
                                    });

                                    col.Item().PaddingBottom(5);
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
