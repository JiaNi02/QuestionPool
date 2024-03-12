﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;

namespace QuestionPool.Pages.subject
{
    public class IndexModel : PageModel
    {
        private readonly QuestionPool.Models.QuestionPoolDatabaseContext _context;

        public IndexModel(QuestionPool.Models.QuestionPoolDatabaseContext context)
        {
            _context = context;
        }

        public IList<Subjects> Subjects { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subjects != null)
            {
                Subjects = await _context.Subjects.ToListAsync();
            }
        }
    }
}
