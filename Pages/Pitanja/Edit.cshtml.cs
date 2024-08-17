using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext;
using klase1;

namespace eUcionica.Pages.PitanjaPage
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;

        

        public EditModel(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
        }

        [BindProperty]
        public klase1.Pitanja Pitanja { get; set; } = default!;
        
        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pitanja == null)
            {
                return NotFound();
            }

            var pitanja =  await _context.Pitanja.FirstOrDefaultAsync(m => m.ID == id);
            if (pitanja == null)
            {
                return NotFound();
            }
            Pitanja = pitanja;
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (_context.Pitanja == null || Pitanja  == null)
                {
                    return Page();
                }

               
                _context.Update(Pitanja);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Pitanja");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
