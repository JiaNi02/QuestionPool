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
        public IList<QuestionAnswer> QuestionAnswer { get; set; } = default!;
        public string selectedSubjectId { get; set; }

        public async Task<IActionResult> OnGetAsync(string selectedSubjectId)
        {
            if (string.IsNullOrEmpty(selectedSubjectId))
            {
                // 如果没有提供选定科目的ID，则返回所有问题列表
                Question = await _context.Question
                    .Include(q => q.CreatedByUserDetails)
                    .Include(q => q.ExamType)
                    .Include(q => q.Subject)
                    .Include(q => q.Term)
                    .Include(q => q.QuestionAnswer)
                    .ToListAsync();
            }
            else
            {
                // 如果提供了选定科目的ID，则根据该ID过滤问题列表
                Question = await _context.Question
                    .Where(q => q.SubjectId.GetValueOrDefault().ToString() == selectedSubjectId)
                    .Include(q => q.CreatedByUserDetails)
                    .Include(q => q.ExamType)
                    .Include(q => q.Subject)
                    .Include(q => q.Term)
                    .Include(q => q.QuestionAnswer)
                    .ToListAsync();
            }

            foreach (var question in Question)
            {
                question.QuestionAnswer = await _context.QuestionAnswer
                    .Where(a => a.QuestionId == question.Id)
                    .ToListAsync();
            }

            // 返回问题列表视图
            return Page();
        }
    }
}
