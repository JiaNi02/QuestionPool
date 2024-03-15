using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.answer
{
    public class DeleteModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public DeleteModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public QuestionAnswer QuestionAnswer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.QuestionAnswer == null)
            {
                return NotFound();
            }

            var questionanswer = await _context.QuestionAnswer.FirstOrDefaultAsync(m => m.Id == id);

            if (questionanswer == null)
            {
                return NotFound();
            }
            else 
            {
                QuestionAnswer = questionanswer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.QuestionAnswer == null)
            {
                return NotFound();
            }
            var questionanswer = await _context.QuestionAnswer.FindAsync(id);

            if (questionanswer != null)
            {
                QuestionAnswer = questionanswer;
                _context.QuestionAnswer.Remove(QuestionAnswer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
