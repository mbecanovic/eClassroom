using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext;

namespace eUcionica.Pages.Predmeti
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;

        public EditModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public klase1.Predmeti Predmeti { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Predmeti = await _context.Predmeti.FindAsync(id);

            if (Predmeti == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Predmeti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredmetiExists(Predmeti.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Predmeti");
        }

        private bool PredmetiExists(int id)
        {
            return _context.Predmeti.Any(e => e.ID == id);
        }
    }
}
