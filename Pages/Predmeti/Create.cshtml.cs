using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBContext; 

namespace eUcionica.Pages.Predmeti
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;

        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public klase1.Predmeti Predmeti { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Predmeti.Add(Predmeti);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Predmeti");
        }
    }
}
