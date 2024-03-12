using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.question
{
    public class IndexModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public IndexModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Question != null)
            {
                Question = await _context.Question
                .Include(q => q.CreatedByUserDetails)
                .Include(q => q.ExamType)
                .Include(q => q.Subject)
                .Include(q => q.Term).ToListAsync();
            }
        }
    }
}
