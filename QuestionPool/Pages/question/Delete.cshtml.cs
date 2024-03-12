using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.question
{
    public class DeleteModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public DeleteModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Question Question { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FirstOrDefaultAsync(m => m.Id == id);

            if (question == null)
            {
                return NotFound();
            }
            else 
            {
                Question = question;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }
            var question = await _context.Question.FindAsync(id);

            if (question != null)
            {
                Question = question;
                _context.Question.Remove(Question);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
