using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.question
{
    public class EditModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public EditModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
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

            var question =  await _context.Question.FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            Question = question;
           ViewData["CreatedByUserDetailsId"] = new SelectList(_context.UserDetails, "Id", "Id");
           ViewData["ExamTypeId"] = new SelectList(_context.ExamType, "Id", "Id");
           ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
           ViewData["TermId"] = new SelectList(_context.Terms, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(Question.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuestionExists(int id)
        {
          return (_context.Question?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
