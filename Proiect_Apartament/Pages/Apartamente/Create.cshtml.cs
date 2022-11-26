using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Apartamente
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : CategoriiApartamentPaginaModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public CreateModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProprietarID"] = new SelectList(_context.Set<Proprietar>(), "ID", "NumeProprietar");

            var apartament = new Apartament();
            apartament.CategoriiApartament = new List<CategorieApartament>();

            PopulateAssignedCategoryData(_context, apartament);

            return Page();
        }

        [BindProperty]
        public Apartament Apartament { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] categorieSelectata)
        {
            var nouApartament = Apartament;
            if (categorieSelectata != null)
            {
                nouApartament.CategoriiApartament = new List<CategorieApartament>();
                foreach (var cat in categorieSelectata)
                {
                    var catToAdd = new CategorieApartament
                    {
                        CategorieID = int.Parse(cat)
                    };
                    nouApartament.CategoriiApartament.Add(catToAdd);
                }
            }
            _context.Apartament.Add(nouApartament);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, nouApartament);
            return Page();
        }
    }
}

