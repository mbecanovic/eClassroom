using Microsoft.AspNetCore.Mvc.RazorPages;
using DBContext;
using klase1;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Test
{
    public class TestModel : PageModel
    {
        private readonly ApplicationContext _context;
        public TestModel(ApplicationContext context)
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
