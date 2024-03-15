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

        public IActionResult OnPost(int choosedSubject)
        {
            // Redirect to the next step with the selected subject
            return RedirectToPage("/NextStepPage", new { choosedSubjectId = choosedSubject });
        }
    }
}

