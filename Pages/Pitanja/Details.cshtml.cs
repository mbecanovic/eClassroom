using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext; 
using klase1; 

namespace eUcionica.Pages.PitanjaPage
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationContext _context;

        public DetailsModel(ApplicationContext context)
        {
            _context = context;
        }

        public klase1.Pitanja Pitanja { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pitanja == null)
            {
                return NotFound();
            }

            Pitanja = await _context.Pitanja.FirstOrDefaultAsync(m => m.ID == id);

            if (Pitanja == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
