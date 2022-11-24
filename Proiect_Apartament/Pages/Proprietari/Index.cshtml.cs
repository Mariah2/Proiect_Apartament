using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;
using Proiect_Apartament.Models.ViewModels;

namespace Proiect_Apartament.Pages.Proprietari
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public IndexModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        public IList<Proprietar> Proprietar { get;set; } = default!;

        public ProprietarIndexData ProprietarData { get; set; }
        public int ProprietarID { get; set; }
        public int ApartamentID { get; set; }
        public async Task OnGetAsync(int? id, int? apartamentID)
        {
            ProprietarData = new ProprietarIndexData();
            ProprietarData.Proprietari = await _context.Proprietar
            .Include(i => i.Apartamente)
           // .ThenInclude(c => c.Proprietar)
            .OrderBy(i => i.NumeProprietar)
            .ToListAsync();
            if (id != null)
            {
                ProprietarID = id.Value;
                Proprietar proprietar = ProprietarData.Proprietari
                .Where(i => i.ID == id.Value).Single();
                ProprietarData.Apartamente = proprietar.Apartamente;
            }
        }
           /* public async Task OnGetAsync()
        {
            if (_context.Proprietar != null)
            {
                Proprietar = await _context.Proprietar.ToListAsync();
            }
        }*/
    }
}
