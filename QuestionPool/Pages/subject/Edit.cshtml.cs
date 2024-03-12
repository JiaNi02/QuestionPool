using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.subject
{
    public class EditModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public EditModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subjects Subjects { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subjects =  await _context.Subjects.FirstOrDefaultAsync(m => m.Id == id);
            if (subjects == null)
            {
                return NotFound();
            }
            Subjects = subjects;
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

            _context.Attach(Subjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsExists(Subjects.Id))
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

        private bool SubjectsExists(int id)
        {
          return (_context.Subjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
