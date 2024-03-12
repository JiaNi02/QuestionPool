using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.subject
{
    public class DetailsModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public DetailsModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

      public Subjects Subjects { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects.FirstOrDefaultAsync(m => m.Id == id);
            if (subjects == null)
            {
                return NotFound();
            }
            else 
            {
                Subjects = subjects;
            }
            return Page();
        }
    }
}
