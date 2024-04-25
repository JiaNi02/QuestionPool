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

        [BindProperty]
        public IFormFile Image { get; set; }
        public IActionResult OnGet()
        {
            ViewData["QuestionId"] = new SelectList(_context.Question, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public QuestionAnswer QuestionAnswer { get; set; } = new QuestionAnswer();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(QuestionAnswer questionAnswer)
        {
            if (Image != null)
            {
                if (questionAnswer.Image != null)
                {
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", questionAnswer.Image);
                    System.IO.File.Delete(filePath);
                }
                questionAnswer.Image = ProcessUploadFile();
            }
            if (!ModelState.IsValid || QuestionAnswer == null)
            {
                return Page();
            }
            _context.QuestionAnswer.Add(QuestionAnswer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }
        private string ProcessUploadFile()
        {
            string uniqueFileName = null;

            if (Image != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

    }
}
