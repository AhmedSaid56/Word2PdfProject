using MigraDoc.DocumentObjectModel;

namespace Word2Pdf_BusinessLayer.Models
{
    public class clsWordParagraphModel
    {
        public string Text { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public double FontSize { get; set; }
        public ParagraphAlignment Alignment { get; set; } = ParagraphAlignment.Left;
    }
}
