using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext;
using klase1;

namespace eUcionica.Pages.PitanjaPage
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext _context;

        public DeleteModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public klase1.Pitanja Pitanja { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pitanja == null)
            {
                return NotFound();
            }

            var pitanja = await _context.Pitanja.FirstOrDefaultAsync(m => m.ID == id);

            if (pitanja == null)
            {
                return NotFound();
            }
            else
            {
                Pitanja = pitanja;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pitanja == null)
            {
                return NotFound();
            }

            var pitanja = await _context.Pitanja.FindAsync(id);

            if (pitanja != null)
            {
                Pitanja = pitanja;
                _context.Pitanja.Remove(Pitanja);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Pitanja");
        }
    }
}
