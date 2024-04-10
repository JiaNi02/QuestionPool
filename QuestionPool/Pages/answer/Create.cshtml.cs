using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using QuestionPool.Models;


namespace QuestionPool.Pages.answer
{
    public class CreateModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CreateModel(QuestionPool.Models.QuestionPoolDatabaseContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
        ViewData["QuestionId"] = new SelectList(_context.Question, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public QuestionAnswer QuestionAnswer { get; set; } = new QuestionAnswer();

        public async Task<IActionResult> OnPostUploadImageAsync(IFormFile image)
        {
            // 检查是否上传了文件
            if (image != null)
            {
                // 生成文件名
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                // 文件保存路径
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", fileName);

                // 保存文件到指定路径
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                // 将文件名保存到 QuestionAnswer 对象中
                QuestionAnswer.Image = fileName;

                // 调用 OnPostAsync 方法保存 QuestionAnswer 对象到数据库
                return await OnPostAsync();
            }

            // 如果没有上传文件，返回错误消息
            return new JsonResult(new { success = false, message = "No file uploaded" });
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || QuestionAnswer == null)
            {
                return Page();
            }

            _context.QuestionAnswer.Add(QuestionAnswer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
