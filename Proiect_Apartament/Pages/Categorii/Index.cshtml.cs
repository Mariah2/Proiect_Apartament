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

namespace Proiect_Apartament.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public IndexModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get; set; } = default!;

        public CategorieIndexData CategorieData { get; set; }
        public Apartament ApartamentData { get; set; }
        public int CategorieID { get; set; }
        public int ApartamentID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategorieData = new CategorieIndexData
            {
                Categorii = await _context.Categorie
            .Include(c => c.CategoriiApartament)
            .ThenInclude(ca => ca.Apartament)
            .ThenInclude(a => a.Proprietar)
            .OrderBy(c => c.NumeCategorie)
            .ToListAsync()
            };

            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie = CategorieData.Categorii.Where(i => i.ID == id.Value).Single();
                CategorieData.CategoriiApartament = categorie.CategoriiApartament;
            }
        }
    }
}
