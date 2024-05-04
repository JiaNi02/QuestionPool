using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;


namespace QuestionPool.Pages.user
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public IndexModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        public IList<UserDetails> UserDetails { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserDetails != null)
            {
                UserDetails = await _context.UserDetails
                .Include(u => u.Department).ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostAsync(string userId, string status)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(status))
            {
                // 如果用户 ID 或状态为空，返回错误响应
                return BadRequest("User ID or status is missing.");
            }

            // 将 userId 参数转换为整数类型
            if (!int.TryParse(userId, out int userIdInt))
            {
                // 如果无法将 userId 参数转换为整数类型，返回错误响应
                return BadRequest("Invalid user ID format.");
            }

            // 查询数据库以找到相应的用户
            var user = await _context.UserDetails.FindAsync(userIdInt);
            if (user == null)
            {
                // 如果找不到用户，返回错误响应
                return NotFound("User not found.");
            }

            // 更新用户的状态并保存到数据库
            user.Status = status;
            _context.UserDetails.Update(user);
            await _context.SaveChangesAsync();

            // 返回成功响应
            return RedirectToPage();

        }

    }
}
