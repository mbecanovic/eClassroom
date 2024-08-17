using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext; 
using klase1; 

namespace eUcionica.Pages.Oblasti
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext _context;

        public DeleteModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public klase1.Oblasti Oblasti { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oblasti = await _context.Oblasti.FirstOrDefaultAsync(m => m.ID == id);

            if (Oblasti == null)
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

            var oblasti = await _context.Oblasti.FindAsync(id);

            if (oblasti != null)
            {
                _context.Oblasti.Remove(oblasti);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Oblasti");
        }
    }
}
