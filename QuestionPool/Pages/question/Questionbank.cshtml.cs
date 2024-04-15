using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuestionPool.Models;
using System.Text;

namespace QuestionPool.Pages.question
{
    public class QuestionbankModel : PageModel
    {
        private readonly QuestionPoolDatabaseContext _context;

        public QuestionbankModel(QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        public IList<Question> Questions { get; set; } = new List<Question>();

        public async Task OnGetAsync(string selectedSubjectId)
        {
            if (!string.IsNullOrEmpty(selectedSubjectId))
            {

                Questions = await _context.Question
                    .Include(q => q.QuestionAnswer)
                    .Include(q => q.ExamType)
                    .Where(q => q.SubjectId.GetValueOrDefault().ToString() == selectedSubjectId)
                    .ToListAsync();
            }
        }
        public IActionResult OnPost(string selectedQuestions)
        {
            if (!string.IsNullOrEmpty(selectedQuestions))
            {
                return RedirectToPage("/question/DisplayQuestion", new { selectedQuestions });
            }
            else
            {
                // Handle case where no questions are selected
                return RedirectToPage("/Questionbank"); // Redirect back to Questionbank page
            }
        }

    }
}

//if (SelectedData.Count > 0)
//{

//    var documentContent = GenerateDocument(SelectedData);


//    return File(Encoding.UTF8.GetBytes(documentContent), "text/plain", "selected_data.txt");
//}