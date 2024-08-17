using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext; 
using klase1; 

namespace eUcionica.Pages.Predmeti
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext _context;

        public DeleteModel(ApplicationContext context)
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

            Predmeti = await _context.Predmeti.FirstOrDefaultAsync(m => m.ID == id);

            if (Predmeti == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Predmeti = await _context.Predmeti.FindAsync(id);

            if (Predmeti != null)
            {
                _context.Predmeti.Remove(Predmeti);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Predmeti");
        }
    }
}
