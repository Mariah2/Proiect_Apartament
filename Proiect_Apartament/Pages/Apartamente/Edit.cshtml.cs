using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Apartamente
{
    public class EditModel : CategoriiApartamentPaginaModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public EditModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Apartament Apartament { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Apartament == null)
            {
                return NotFound();
            }

            Apartament =  await _context.Apartament
                .Include(b => b.Proprietar)
                .Include(b => b.CategoriiApartament)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);



            if (Apartament == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Apartament);

            Apartament = Apartament;
            ViewData["ProprietarID"] = new SelectList(_context.Set<Proprietar>(), "ID", "NumeProprietar");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] categorieSelectata)
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Apartament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentExists(Apartament.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ApartamentExists(int id)
        {
          return _context.Apartament.Any(e => e.ID == id);*/



            if (id == null)
            {
                return NotFound();
            }
            var apartamentUpdatat = await _context.Apartament
            .Include(i => i.Proprietar)
            .Include(i => i.CategoriiApartament)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (apartamentUpdatat == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Apartament>(
            apartamentUpdatat,
            "Apartament",
            i => i.Nume, i => i.Proprietar,
            i => i.Pret))
            {
                UpdateCategoriiApartamente(_context, categorieSelectata, apartamentUpdatat);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateCategoriiApartamente(_context, categorieSelectata, apartamentUpdatat);
            PopulateAssignedCategoryData(_context, apartamentUpdatat);
            return Page();
        }
    }


}
    
