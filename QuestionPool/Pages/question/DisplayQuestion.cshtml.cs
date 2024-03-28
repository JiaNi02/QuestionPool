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
                Questions = await _context.Question
                    .Include(q => q.QuestionAnswer)
                    .Where(q => questionIds.Contains(q.Id))
                    .ToListAsync();

                return Page();

            }
            else
            {
                // Handle case where no questions are selected
                return RedirectToPage("/Questionbank"); // Redirect back to Questionbank page
            }

        }

        public async Task<IActionResult> OnPostGeneratePdfAsync()
        {
            MemoryStream ms = new MemoryStream();

            PdfWriter writer = new PdfWriter(ms);
            PdfDocument pdfDoc = new PdfDocument(writer);
            Document document = new Document(pdfDoc, PageSize.A4, false);
            writer.SetCloseStream(false);

            foreach (var question in Questions)
            {
                Paragraph questionParagraph = new Paragraph()
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(12)
                    .Add(new Text($"{question.QuestionNumber}. {question.Name}\n"))
                    .Add(new Text($"{question.Questions}\n"));

                // Add choices
                var choices = question.Choice.Trim('[', ']').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var choice in choices)
                {
                    var formattedChoice = choice.Replace("\"", "").Trim();
                    questionParagraph.Add(new Text($"- {formattedChoice}\n"));
                }

                questionParagraph.Add(new Text("\n"));

                document.Add(questionParagraph);
            }

            // Page Numbers
            int n = pdfDoc.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                    .Format("Page " + i + " of " + n)),
                    559, 806, i, TextAlignment.RIGHT,
                    VerticalAlignment.TOP, 0);
            }

            document.Close();
            byte[] byteInfo = ms.ToArray();
            ms.Write(byteInfo, 0, byteInfo.Length);
            ms.Position = 0;

            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");

            // Uncomment this to return the file as a download
            // fileStreamResult.FileDownloadName = "GeneratedQuestions.pdf";

            return fileStreamResult;
        }
    }
 }






