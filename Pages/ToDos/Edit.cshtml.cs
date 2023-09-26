using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using auth.studies.Models;
using auth.studies.Data;

namespace auth.studies.Pages.ToDos
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDo ToDo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var todo =  await _context.ToDos.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            ToDo = todo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(ToDo.CreatedAt.ToString());
            ToDo.LastUpdatedAt = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(ToDo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDoExists(int id)
        {
          return (_context.ToDos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
