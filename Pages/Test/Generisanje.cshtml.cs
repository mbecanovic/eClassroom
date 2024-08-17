using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBContext;
using klase1;

namespace eUcionica.Pages.Test
{
    public class GenerisanjeModel : PageModel
    {
        private readonly ApplicationContext _context;

        public GenerisanjeModel(ApplicationContext context)
        {
            _context = context;
        }

        //definisanje javnih promenljivih
        public IList<klase1.Pitanja> Pitanja { get; set; }
        public List<klase1.Pitanja> TacnaPitanja { get; set; }

        public List<klase1.Pitanja> NetacnaPitanja { get; set; }

        public int br_pitanja { get; private set; }
        public int br_tacnih_pitanja { get; private set; }
        public bool zavrseno { get; private set; }

        //get metoda koja nam sluzi da povucemo 3 random pitanja iz baze
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pitanja = await _context.Pitanja
                .Where(p => p.IDPredmet == id)
                .OrderBy(o => Guid.NewGuid())
                .Take(3)
                .ToListAsync();

            br_pitanja = Pitanja.Count;
            zavrseno = false; // Postavljamo da nije završeno dok korisnik ne pošalje odgovore

            if (Pitanja == null || Pitanja.Count == 0)
            {
                return Page();
            }

            return Page();
        }

        //post metoda za proveravanja tacnih odgovora 
        public async Task<IActionResult> OnPostAsync(Dictionary<int, string> Odgovori, int[] PitanjaIDs)
        {
            int tacniOdgovori = 0;

            List<klase1.Pitanja> tacnaPitanja = new List<klase1.Pitanja>();

            List<klase1.Pitanja> netacnaPitanja = new List<klase1.Pitanja>();

            foreach (var id in PitanjaIDs)
            {
                var pitanje = await _context.Pitanja.FindAsync(id);
                if (pitanje != null && Odgovori.ContainsKey(id) && Odgovori[id] == pitanje.Odgovor)
                {
                    tacniOdgovori++;
                    tacnaPitanja.Add(pitanje);
                }
                else
                {
                    netacnaPitanja.Add(pitanje);
                }
            }

            br_tacnih_pitanja = tacniOdgovori;
            //parsiramo podatke u json format koje cemo kasnije prikazati
            var tacnaPitanjaJson = Newtonsoft.Json.JsonConvert.SerializeObject(tacnaPitanja);
            var netacnaPitanjaJson = Newtonsoft.Json.JsonConvert.SerializeObject(netacnaPitanja);


            // Proverimo da li su svi odgovori tacni i saljemo podatke RezultatModel-u
            if (tacniOdgovori == br_pitanja)
            {
                zavrseno = true;
                return RedirectToPage("./Rezultat", new { tacniOdgovori = br_tacnih_pitanja, br_pitanja = PitanjaIDs.Length, tacnaPitanjaJson, netacnaPitanjaJson });

            }
            else
            {
                return RedirectToPage("./Rezultat", new { tacniOdgovori = br_tacnih_pitanja, br_pitanja = PitanjaIDs.Length, tacnaPitanjaJson, netacnaPitanjaJson });
            }

        }

    }
}
