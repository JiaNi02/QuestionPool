using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionPoolDatabaseContext _context;

        public QuestionController(QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        // GET: /Question/GetQuestionsBySubjectId?subjectId={subjectId}
        [HttpGet]
        public IActionResult GetQuestionsBySubjectId(int subjectId)
        {
            var questions = _context.Question
                .Include(q => q.ExamType)
                .Include(q => q.Subject)
                .Include(q => q.Term)
                .Where(q => q.SubjectId == subjectId)
                .ToList();

            return Json(questions);
        }
    }
}
