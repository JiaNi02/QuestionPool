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
using iText.Layout;

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

        private byte[] GeneratePdf(List<Question> questions)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(ms);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document document = new Document(pdfDoc, PageSize.A4, false);
                writer.SetCloseStream(false);

                // Add header
                document.Add(new Paragraph("Northwind Products")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

                // Add subheader
                document.Add(new Paragraph(DateTime.Now.ToShortDateString())
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(15));

                // Add empty line and line separator
                document.Add(new Paragraph(""));
                document.Add(new LineSeparator(new SolidLine()));
                document.Add(new Paragraph(""));

                // Add questions to the document
                foreach (var question in questions)
                {
                    // Add question text
                    document.Add(new Paragraph(question.Name));

                    // Add question choices
                    foreach (var choice in question.Choice)
                    {
                        document.Add(new Paragraph(choice.ToString()));
                    }

                    // Add an empty line between questions
                    document.Add(new Paragraph(""));
                }

                // Add page numbers
                int n = pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= n; i++)
                {
                    document.ShowTextAligned(new Paragraph(String.Format("Page " + i + " of " + n)),
                        559, 806, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
                }

                // Close the document
                document.Close();

                // Return the PDF as byte array
                return ms.ToArray();
            }

        }

    }
}
