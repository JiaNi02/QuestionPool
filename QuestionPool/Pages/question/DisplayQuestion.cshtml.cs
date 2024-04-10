using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuestionPool.Models;
using iText.Bouncycastle;
using iText.Layout;
using System.Drawing;
using System.Xml.Linq;
using System.Text;
using iText.Html2pdf;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;


namespace QuestionPool.Pages.question
{

    public class DisplayQuestionModel : PageModel
    {
        private readonly QuestionPoolDatabaseContext _context;

        public DisplayQuestionModel(QuestionPoolDatabaseContext context)
        {
            _context = context;
            Questions = new List<Question>();
        }
        public List<Question> Questions { get; set; }


        public async Task<IActionResult> OnGetAsync(string selectedQuestions)
    {
        if (!string.IsNullOrEmpty(selectedQuestions))
        {
            var questionIds = selectedQuestions.Split(',').Select(int.Parse).ToList();
            // Fetch only the questions displayed on the page
            Questions = await _context.Question
                .Include(q => q.QuestionAnswer)
                .Where(q => questionIds.Contains(q.Id))
                .ToListAsync();

            return Page();

        }
        else
        {

                return RedirectToPage("/Questionbank");
            }

    }

        public void ConvertHtmlToPdf(string htmlContent, string pdfFilePath)
        {
            using (var writer = new PdfWriter(pdfFilePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    ConverterProperties props = new ConverterProperties();
                    HtmlConverter.ConvertToPdf(htmlContent, pdf, props);
                }
            }
        }


        //export function
        public FileStreamResult OnPostExportToPdfAsync(string html)
        {

            var stream = new MemoryStream();

            using (var writer = new PdfWriter(stream))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    writer.SetCloseStream(false); // Prevent the writer from closing the stream
                    ConverterProperties props = new ConverterProperties();
                    HtmlConverter.ConvertToPdf(html, pdf, props);
                }
            }

            stream.Position = 0; // Reset the stream position for reading

            return new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = "ExamPaper.pdf"
            };
        }

    }

}









