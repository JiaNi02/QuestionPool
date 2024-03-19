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
                // ????????????
                Questions = await _context.Question
                    .Include(q => q.QuestionAnswer)
                    .Where(q => q.SubjectId.GetValueOrDefault().ToString() == selectedSubjectId)
                    .ToListAsync();
            }
        }
        [BindProperty]
        public List<string> SelectedData { get; set; } = new List<string>();

        public IActionResult OnPost()
        {
            if (SelectedData.Count > 0)
            {
                // ????
                var documentContent = GenerateDocument(SelectedData);

                // ??????
                return File(Encoding.UTF8.GetBytes(documentContent), "text/plain", "selected_data.txt");
            }
            else
            {
               
                return RedirectToPage("/question/Questionbank"); 
            }
        }

        private string GenerateDocument(List<string> selectedData)
        {
            // ??????
            var documentContent = new StringBuilder();
            documentContent.AppendLine("Selected Data:");
            foreach (var data in selectedData)
            {
                documentContent.AppendLine(data);
            }
            return documentContent.ToString();
        }
    }
}

