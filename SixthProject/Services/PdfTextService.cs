using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace SixthProject.Services.OcrService
{
    public class PdfTextDetector
    {
        // checks for text
        public bool HasTextLayer(string pdfPath)
        {
            using var doc = PdfDocument.Open(pdfPath);

            foreach (var page in doc.GetPages())
            {
                string text = page.Text;
                if (!string.IsNullOrEmpty(text) && text.Length > 20)
                {
                    return true;
                }
            }
            return false;
        }

        //extract text
        public string ExtractText(string pdfPath)
        {
            using (var doc = PdfDocument.Open(pdfPath))
            {
                string result = "";

                foreach (var page in doc.GetPages())
                {
                    result += page.Text + "\n";
                }
                return result.Trim();
            }


        }
    }
}
