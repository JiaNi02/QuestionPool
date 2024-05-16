using iText.Kernel.Pdf;
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
using Microsoft.AspNetCore.Hosting;
using iText.Layout.Element;
using iText.Layout.Properties;


namespace QuestionPool.Pages.question
{

    public class DisplayQuestionModel : PageModel
    {
        private readonly QuestionPoolDatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DisplayQuestionModel(QuestionPoolDatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            Questions = new List<Question>();
            _webHostEnvironment = webHostEnvironment;
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
                .Include(q => q.ExamType)
                .Where(q => questionIds.Contains(q.Id))
                .ToListAsync();

                Questions.Select(q => { q.Image = GetAbsoluteImageUrl(q.Image); return q; }).ToList();
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
        public FileStreamResult OnPostExportToPdfAsync(string questionsHtml)
        {

            var stream = new MemoryStream();

            using (var writer = new PdfWriter(stream))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    writer.SetCloseStream(false); // Prevent the writer from closing the stream
                    ConverterProperties props = new ConverterProperties();
                    HtmlConverter.ConvertToPdf(questionsHtml, pdf, props);

                }
            }

            stream.Position = 0; // Reset the stream position for reading

            return new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = "ExamPaper.pdf"
            };
        }
        public FileStreamResult OnPostExportAnswersToPdfAsync(string answersHtml)
        {
            var stream = new MemoryStream();

            using (var writer = new PdfWriter(stream))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    writer.SetCloseStream(false); // Prevent the writer from closing the stream
                    ConverterProperties props = new ConverterProperties();
                    HtmlConverter.ConvertToPdf(answersHtml, pdf, props);
                }
            }

            stream.Position = 0; // Reset the stream position for reading

            return new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = "ExamAnswers.pdf"
            };
        }
        private string GetAbsoluteImageUrl(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                return string.Empty; // ??????????????? URL
            }

            string webRootPath = _webHostEnvironment.WebRootPath;
            string absolutePath = Path.Combine(webRootPath, "uploads", relativePath);
            string baseUrl = $"{Request.Scheme}://{Request.Host}";

            // Construct the absolute URL
            string absoluteUrl = $"{baseUrl}/{relativePath}";

            return absoluteUrl;
        }

    }

}









