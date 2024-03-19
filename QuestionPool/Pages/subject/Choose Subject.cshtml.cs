using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.subject
{
    public class Choose_SubjectModel : PageModel
    {
        private readonly QuestionPoolDatabaseContext _context;

        public Choose_SubjectModel(QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        public IList<Subjects> Subjects { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Subjects = await _context.Subjects.ToListAsync();
        }

        public IActionResult OnPost(string selectedSubjectId)
        {
            if (string.IsNullOrEmpty(selectedSubjectId))
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/question/Questionbank", new { selectedSubjectId });
        }
    }
}

