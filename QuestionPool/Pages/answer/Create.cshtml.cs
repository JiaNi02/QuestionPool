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
        private readonly IFileStorageHelper _fileStorageHelper;

        public CreateModel(QuestionPool.Models.QuestionPoolDatabaseContext context, IFileStorageHelper fileStorageHelper)
        {
            _context = context;
            _fileStorageHelper = fileStorageHelper;
        }

        [BindProperty]
        public IFormFile Image { get; set; }
        public IActionResult OnGet()
        {
            ViewData["QuestionId"] = _context.Question.Select(q => new SelectListItem
            {
                Value = q.Id.ToString(),
                Text = $"{q.Name} - {q.Questions}" // 将问题的名称和内容合并成一个字符串
            }).ToList();

            return Page();
        }
        //ViewData["QuestionId"] = new SelectList(_context.Question, "Id", "Name");
        [BindProperty]
        public QuestionAnswer QuestionAnswer { get; set; } = new QuestionAnswer();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Image != null && Image.Length > 0)
            {
                var imagePath = await _fileStorageHelper.SaveFileAsync(Image, "answer image");
                QuestionAnswer.Image = imagePath;
            }
            //if (!ModelState.IsValid || QuestionAnswer == null)
            //{
            //    return Page();
            //}
            _context.QuestionAnswer.Add(QuestionAnswer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }

    }
}
