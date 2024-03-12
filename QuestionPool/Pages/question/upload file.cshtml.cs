using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestionPool.Models;
using System.Diagnostics.Tracing;
using System.Reflection.PortableExecutable;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas.Parser.Data;
namespace QuestionPool.Pages.question
{
    public class upload_fileModel : PageModel
    {
        public List<Question>? Questions { get; set; }
        public List<string> Image { get; set; }

        public void OnGet()
        {
        }
        //public IActionResult OnPost(IFormFile pdfFile)
        //{
        //    if (pdfFile != null && pdfFile.Length > 0)
        //    {
        //        var tempFilePath = "C:\\Users\\User\\Documents\\Visual Studio 2022\\QuestionPool\\QuestionPool\\temp\\account.pdf";
        //        using (var stream = System.IO.File.Create(tempFilePath))
        //        {
        //            pdfFile.CopyTo(stream);
        //        }

        //        // Extract questions from the PDF
        //        Questions = ExtractQuestions(tempFilePath);
        //    }

        //    // Return the page, displaying the extracted questions in current page
        //    //You can change to your own page
        //    return Page();
        //}
        //private List<Question> ExtractQuestions(string pdfFilePath)
        //{
        //    // The extraction logic (itext extract text from pdf)
        //    // 
        //    List<Question> questions = new List<Question>();

        //    using (PdfReader pdfReader = new PdfReader(pdfFilePath))
        //    {
        //        using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
        //        {
        //            for (int pageNum = 1; pageNum <= pdfDocument.GetNumberOfPages(); pageNum++)
        //            {
        //                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        //                string pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum), strategy);

        //                CustomImageRenderListener imageListener = new CustomImageRenderListener();
        //                PdfCanvasProcessor canvasProcessor = new PdfCanvasProcessor(imageListener);
        //                canvasProcessor.ProcessPageContent(pdfDocument.GetPage(pageNum));

        //                Image = imageListener.ExtractedImages;
        //                // Extract questions and choices based on the assumption that each question
        //                // starts with a number followed by the question text and choices on the next lines.
        //                List<string> lines = pageText.Split('\n').Select(line => line.Trim()).ToList();
        //                ExtractQuestionsFromLines(lines, questions);
        //            }
        //        }
        //    }


        //    return questions;
        //}
        //public class CustomImageRenderListener : IEventListener
        //{
        //    public List<string> ExtractedImages { get; set; } = new List<string>();

        //    public void EventOccurred(IEventData data, EventType type)
        //    {
        //        if (type == EventType.RENDER_IMAGE)
        //        {
        //            ImageRenderInfo renderInfo = (ImageRenderInfo)data;
        //            byte[] imageBytes = renderInfo.GetImage().GetImageBytes();

        //            // Store the image data as a Base64 string
        //            string base64Image = Convert.ToBase64String(imageBytes);
        //            ExtractedImages.Add(base64Image);
        //        }
        //    }

        //    public ICollection<EventType> GetSupportedEvents()
        //    {
        //        return null; // All event types are supported
        //    }
        //}
        ////The condition of how itext should be process
        ////We need to rethink about this condition
        //private void ExtractQuestionsFromLines(List<string> lines, List<Question> questions)
        //{
        //    int currentQuestionId = 0;
        //    string currentQuestionText = "";
        //    List<string> currentChoice = new List<string>();

        //    foreach (string line in lines)
        //    {
        //        // Check if the line starts with a number (indicating a new question)
        //        if (int.TryParse(line.Split(' ')[0], out int questionId))
        //        {
        //            // If we were processing a previous question, add it to the list
        //            if (currentQuestionId != 0)
        //            {
        //                Question question = new Question
        //                {
        //                    Id = currentQuestionId,
        //                    Questions = currentQuestionText,
        //                    Choice = currentChoice
        //                };
        //                questions.Add(question);

        //                // Reset for the new question
        //                currentChoice = new List<string>();
        //            }

        //            // Update the current question ID
        //            currentQuestionId = questionId;

        //            // Extract the question text (assuming it's the rest of the line after the number)
        //            currentQuestionText = line.Substring(line.IndexOf(' ') + 1).Trim();
        //        }
        //        else if (!string.IsNullOrEmpty(line))
        //        {
        //            // Non-empty lines after the question number are assumed to be choices
        //            currentChoice.Add(line.Trim());
        //        }
        //    }

        //    // Add the last question to the list
        //    if (currentQuestionId != 0)
        //    {
        //        Question question = new Question
        //        {
        //            Id = currentQuestionId,
        //            Questions = currentQuestionText,
        //            Choice = currentChoice,
        //        };
        //        questions.Add(question);
        //    }

        //}
    }
}
