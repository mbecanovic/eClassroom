using Microsoft.AspNetCore.Mvc.RazorPages;
using DBContext;
using klase1;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eUcionica.Pages.Test
{
    public class RezultatModel : PageModel
    {
        private readonly ApplicationContext _context;

        public RezultatModel(ApplicationContext context)
        {
            _context = context;
        }

        public List<klase1.Pitanja> TacnaPitanja { get; set; }
        public List<klase1.Pitanja> NetacnaPitanja { get; set; }
        public int? TacniOdgovori { get; set; }
        public string TacnaPitanjaJson { get; set; }
        public string NetacnaPitanjaJson { get; set; }
        public int BrojPitanja { get; set; }
        
        //get metoda nakon sto posaljemo rezultate sa Generisanje stranice
        public void OnGet(int tacniOdgovori, int br_pitanja, string tacnaPitanjaJson, string netacnaPitanjaJson)
        {
            TacniOdgovori = tacniOdgovori;
            BrojPitanja = br_pitanja;
            TacnaPitanja = JsonConvert.DeserializeObject<List<klase1.Pitanja>>(tacnaPitanjaJson);
            NetacnaPitanja = JsonConvert.DeserializeObject<List<klase1.Pitanja>>(netacnaPitanjaJson);
        }
    }
}
