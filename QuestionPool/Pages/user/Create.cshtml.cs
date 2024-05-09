using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using iText.Commons.Actions.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.user
{
    public class CreateModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(QuestionPool.Models.QuestionPoolDatabaseContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public IList<IdentityUser> Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");

            Users = await _userManager.Users.ToListAsync();

            // Map AspNetUsers details to SelectListItem for dropdown
            ViewData["AspNetUserId"] = new SelectList(Users, "Id", "Email");

            return Page();
        }

        [BindProperty]
        public UserDetails UserDetails { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UserDetails == null || UserDetails == null)
            {
                return Page();
            }

            _context.UserDetails.Add(UserDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
