using System.Collections.Generic;

namespace Word2Pdf_BusinessLayer.Models
{
    public class clsWordDocumentModel
    {
        public string FileName { get; set; }
        public List<clsWordParagraphModel> Paragraphs { get; set; }

    }
}
