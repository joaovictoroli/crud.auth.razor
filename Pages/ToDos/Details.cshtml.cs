using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using auth.studies.Models;
using auth.studies.Data;

namespace auth.studies.Pages.ToDos
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public ToDo ToDo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var todo = await _context.ToDos.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            else 
            {
                ToDo = todo;
            }
            return Page();
        }
    }
}
