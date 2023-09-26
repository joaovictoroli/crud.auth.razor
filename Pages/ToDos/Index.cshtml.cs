using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using auth.studies.Data;
using auth.studies.Models;

namespace auth.studies.Pages.ToDos
{
    public class IndexModel : PageModel
    {
        private readonly auth.studies.Data.ApplicationDbContext _context;

        public IndexModel(auth.studies.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDo> ToDo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ToDos != null)
            {
                ToDo = await _context.ToDos.ToListAsync();
            }
        }
    }
}
