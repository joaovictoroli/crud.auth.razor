using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using auth.studies.Models;
using auth.studies.Data;

namespace auth.studies.Pages.ToDos
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDo ToDo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ToDo.CreatedAt = DateTime.Now;
            ToDo.LastUpdatedAt = DateTime.Now;
            if (!ModelState.IsValid || _context.ToDos == null || ToDo == null)
            {
                return Page();
            }

            _context.ToDos.Add(ToDo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
