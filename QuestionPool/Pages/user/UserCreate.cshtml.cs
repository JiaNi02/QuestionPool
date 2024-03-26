using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionPool.Models;

namespace QuestionPool.Pages.user
{
    public class UserCreateModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public UserCreateModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Email");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
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
