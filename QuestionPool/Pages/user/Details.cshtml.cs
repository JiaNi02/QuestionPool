using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.user
{
    public class DetailsModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public DetailsModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

      public UserDetails UserDetails { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userdetails = await _context.UserDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (userdetails == null)
            {
                return NotFound();
            }
            else 
            {
                UserDetails = userdetails;
            }
            return Page();
        }
    }
}
