using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext;
using klase1; 

namespace eUcionica.Pages.Oblasti
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;

        public EditModel(ApplicationContext context)
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Oblasti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OblastiExists(Oblasti.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Oblasti");
        }

        private bool OblastiExists(int id)
        {
            return _context.Oblasti.Any(e => e.ID == id);
        }
    }
}
