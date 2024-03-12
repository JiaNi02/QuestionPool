using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionPool.Models;

namespace QuestionPool.Pages.question
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
        ViewData["CreatedByUserDetailsId"] = new SelectList(_context.UserDetails, "Id", "Name");
        ViewData["ExamTypeId"] = new SelectList(_context.ExamType, "Id", "Name");
        ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
        ViewData["TermId"] = new SelectList(_context.Terms, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Question == null || Question == null)
            {
                return Page();
            }

            _context.Question.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
