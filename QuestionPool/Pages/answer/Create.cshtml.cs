using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionPool.Models;

namespace QuestionPool.Pages.answer
{
    public class CreateModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public CreateModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["QuestionId"] = new SelectList(_context.Question, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public QuestionAnswer QuestionAnswer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.QuestionAnswer == null || QuestionAnswer == null)
            {
                return Page();
            }

            _context.QuestionAnswer.Add(QuestionAnswer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
