using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Apartamente
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public IndexModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        public IList<Apartament> Apartament { get; set; } = default!;

        public ApartamentData ApartamentData { get; set; }
        public int ApartamentID { get; set; }
        public int CategorieID { get; set; }

        public string NumeSort { get; set; }
        public string ProprietarSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID, string sortOrder, string searchString)
        {

            ApartamentData = new ApartamentData();

            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            ProprietarSort = String.IsNullOrEmpty(sortOrder) ? "proprietar_desc" : "";

            CurrentFilter = searchString;

            ApartamentData.Apartamente = await _context.Apartament
            .Include(b => b.Proprietar)
            .Include(b => b.CategoriiApartament)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ApartamentData.Apartamente = ApartamentData.Apartamente.Where(s => s.Proprietar.NumeProprietar.Contains(searchString)

               || s.Proprietar.NumeProprietar.Contains(searchString)
               || s.Nume.Contains(searchString));

            }

                if (id != null)
            {
                ApartamentID = id.Value;
                Apartament apartament = ApartamentData.Apartamente
                .Where(i => i.ID == id.Value).Single();
                ApartamentData.Categorii = apartament.CategoriiApartament.Select(s => s.Categorie);
            }

            switch (sortOrder)
            {
                case "nume_desc":
                    ApartamentData.Apartamente = ApartamentData.Apartamente.OrderByDescending(s =>
                   s.Nume);
                    break;
                case "proprietar_desc":
                    ApartamentData.Apartamente = ApartamentData.Apartamente.OrderByDescending(s =>
                   s.Proprietar.NumeProprietar);
                    break;
            }
        }
    }
}

