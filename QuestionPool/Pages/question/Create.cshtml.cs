using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionPool.Models;
using QuestionPool;

namespace QuestionPool.Pages.question
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

        public IActionResult OnGet()
        {
        ViewData["CreatedByUserDetailsId"] = new SelectList(_context.UserDetails, "Id", "Name");
        ViewData["ExamTypeId"] = new SelectList(_context.ExamType, "Id", "Name");
        ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
        ViewData["TermId"] = new SelectList(_context.Terms, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; } = default!;

        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

          //if (!ModelState.IsValid || _context.Question == null || Question == null)
          //  {
          //      return Page();
          //  }
            if (Image != null && Image.Length > 0)
            {
                var imagePath = await _fileStorageHelper.SaveFileAsync(Image, "uploads");
                Question.Image = imagePath;
            }

            _context.Question.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
