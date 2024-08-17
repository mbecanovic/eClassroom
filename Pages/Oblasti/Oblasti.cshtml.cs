using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext; 
using klase1;

namespace eUcionica.Pages.Oblasti
{
    public class OblastiModel : PageModel
    {
        private readonly ApplicationContext _context;

        public OblastiModel(ApplicationContext context)
        {
            _context = context;
        }

        public IList<klase1.Oblasti> Oblasti { get; set; }

        public async Task OnGetAsync()
        {
            Oblasti = await _context.Oblasti.ToListAsync();
        }
    }
}
