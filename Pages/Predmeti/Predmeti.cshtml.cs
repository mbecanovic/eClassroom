using DBContext;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace eUcionica.Pages.Predmeti
{
    public class PredmetiModel : PageModel
    {
        private readonly ApplicationContext _context;

        public PredmetiModel(ApplicationContext context)
        {
            _context = context;
        }

        public IList<klase1.Predmeti> Predmeti { get; set; }

        public async Task OnGetAsync()
        {
            Predmeti = await _context.Predmeti.ToListAsync();
        }
    }
}
