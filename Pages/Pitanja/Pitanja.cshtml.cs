using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext; 
using klase1; 

namespace eUcionica.Pages.Pitanja
{
    public class PitanjaModel : PageModel
    {
        private readonly ApplicationContext _context;

        public PitanjaModel(ApplicationContext context)
        {
            _context = context;
        }

        public IList<klase1.Pitanja> Pitanja { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public void OnPost()
        {
            if (SearchText == null)
            {
                Pitanja = _context.Pitanja
                    .Include(z => z.Predmet)
                    .Include(z => z.Oblast)
                    .ToList();
            }
            else
            {
                Pitanja = _context.Pitanja
                    .Where(z => z.Pitanje.Contains(SearchText) ||
                                z.Predmet.Name.Contains(SearchText) ||
                                z.Oblast.Name.Contains(SearchText))
                    .Include(z => z.Predmet)
                    .Include(z => z.Oblast)
                    .ToList();
            }
        }

        public void OnGet()
        {
            Pitanja  = _context.Pitanja
                .Include(z => z.Predmet)
                .Include(z => z.Oblast)
                .ToList();
        }
    }
}
