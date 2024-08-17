using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DBContext;
using klase1;

namespace eUcionica.Pages.PitanjaPage
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;
        
        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IDPredmet"] = new SelectList(_context.Predmeti, "ID", "Name");
            ViewData["IDOblast"] = new SelectList(_context.Oblasti, "ID", "Name");

            var nivoOptions = new[]
            {
                new SelectListItem { Value = "Pocetni", Text = "Pocetni" },
                new SelectListItem { Value = "Srednji", Text = "Srednji" },
                new SelectListItem { Value = "Visok", Text = "Visok" }
            };

            ViewData["Nivo"] = new SelectList(nivoOptions, "Value", "Text");

            return Page();
        }

        [BindProperty]
        public klase1.Pitanja Pitanja { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Pitanja == null || Pitanja == null)
            {
                return Page();
            }

            _context.Pitanja.Add(Pitanja);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Pitanja");
        }
    }
}
