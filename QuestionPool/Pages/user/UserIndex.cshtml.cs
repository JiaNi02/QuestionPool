using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.user
{
    public class UserIndexModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public UserIndexModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        public IList<UserDetails> UserDetails { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserDetails != null)
            {
                UserDetails = await _context.UserDetails
                .Include(u => u.Department).ToListAsync();
            }
        }
    }
}
