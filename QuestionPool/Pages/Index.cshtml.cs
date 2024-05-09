using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly QuestionPoolDatabaseContext _databaseContext;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, QuestionPoolDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _logger = logger;
        }
        public int TotalSubject { get; set; }
        public int TotalQuestion{ get; set; }
        public int TotalUser { get; set; }
        public int TotalDepartment { get; set; }

        public async Task OnGetAsync()
        {
            TotalSubject = await _databaseContext.Subjects.CountAsync();
            TotalQuestion = await _databaseContext.Question.CountAsync();
            TotalUser = await _databaseContext.UserDetails.CountAsync();
            TotalDepartment = await _databaseContext.Departments.CountAsync();
        }
    }
}
