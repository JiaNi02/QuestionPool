using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages
{
    //[Authorize(Roles = "Admin")]
    public class ManageRoleModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly QuestionPoolDatabaseContext _dbContext;

        public ManageRoleModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, QuestionPoolDatabaseContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }
        public IList<IdentityUser> Users { get; set; } = default!;
        public IList<IdentityRole> Roles { get; set; } = default!;
        public IList<UserDetails> UserDetails { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
            Roles = await _roleManager.Roles.ToListAsync();

            // Retrieve user details
            UserDetails = await _dbContext.UserDetails.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string userId, List<string> roles, bool delete)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }


            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles.ToArray());
            await _userManager.AddToRolesAsync(user, roles);

            return RedirectToPage();
        }
    }
}

