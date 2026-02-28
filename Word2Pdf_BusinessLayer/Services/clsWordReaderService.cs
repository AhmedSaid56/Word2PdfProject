using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Word2Pdf_BusinessLayer.Models;
using WParagraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;

namespace Word2Pdf_BusinessLayer
{
    public static class clsWordReaderService
    {

        #region Helper Methods
        private static bool IsFileLocked(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(
                    filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.None))
                {

                }
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        private static void ValidateWordFile(string filePath)
        {

            // File exists
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Word file not found", filePath);

            FileInfo fileInfo = new FileInfo(filePath);
            // File size = 0 (empty file)
            if (fileInfo.Length == 0)
                throw new InvalidOperationException("Word file is empty");

            // File is locked / in use
            if (IsFileLocked(filePath))
                throw new IOException("Word file is currently open or in use by another process");
        }

        private static clsWordDocumentModel ReadWordFile(string filePath)
        {
            clsWordDocumentModel model = new clsWordDocumentModel
            {
                FileName = Path.GetFileName(filePath),
                Paragraphs = new List<clsWordParagraphModel>()
            };

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;

                foreach (var paragraph in body.Elements<WParagraph>())
                {
                    if (string.IsNullOrWhiteSpace(paragraph.InnerText))
                        continue;

                    // Default values
                    bool isBold = false;
                    bool isItalic = false;
                    double fontSize = 12; // default
                    bool isNumbered = false;
                    int number = 0;
                    ParagraphAlignment alignment = ParagraphAlignment.Left; // default alignment

                    if (paragraph.ParagraphProperties?.Justification?.Val != null)
                    {
                        JustificationValues justVal = paragraph.ParagraphProperties.Justification.Val.Value;
                        if (justVal == JustificationValues.Center)
                            alignment = ParagraphAlignment.Center;
                        else if (justVal == JustificationValues.Right)
                            alignment = ParagraphAlignment.Right;
                        else if (justVal == JustificationValues.Both)
                            alignment = ParagraphAlignment.Justify;
                        else
                            alignment = ParagraphAlignment.Left;
                    }

                    foreach (var run in paragraph.Elements<Run>())
                    {
                        RunProperties runProps = run.RunProperties;
                        if (runProps != null)
                        {
                            // Bold
                            if (runProps.Bold != null && (runProps.Bold.Val == null || runProps.Bold.Val.Value))
                                isBold = true;

                            // Italic
                            if (runProps.Italic != null && (runProps.Italic.Val == null || runProps.Italic.Val.Value))
                                isItalic = true;

                            // FontSize (Word stores in half-points)
                            if (runProps.FontSize != null && double.TryParse(runProps.FontSize.Val, out double sz))
                                fontSize = sz / 2.0;
                        }

                        var numProps = paragraph.ParagraphProperties?.NumberingProperties;
                        if (numProps != null && numProps.NumberingId != null)
                        {
                            isNumbered = true;
                            number = model.Paragraphs.Count(p => p.IsNumbered) + 1;
                        }

                    }

                    model.Paragraphs.Add(new clsWordParagraphModel
                    {
                        Text = paragraph.InnerText,
                        IsBold = isBold,
                        IsItalic = isItalic,
                        FontSize = fontSize,
                        Alignment = alignment,
                        IsNumbered = isNumbered,
                        Number = number
                    });
                }
            }

            return model;
        }
        #endregion

        public static Task<clsWordDocumentModel> ReadWordFileAsync(string filePath)
        {
            ValidateWordFile(filePath);

            return Task.Run(() =>
            {
                return ReadWordFile(filePath);
            });
        }

    }

}
