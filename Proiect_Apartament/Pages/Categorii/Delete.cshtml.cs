using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Categorii
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public DeleteModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Categorie Categorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorie.FirstOrDefaultAsync(m => m.ID == id);

            if (categorie == null)
            {
                return NotFound();
            }
            else 
            {
                Categorie = categorie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }
            var categorie = await _context.Categorie.FindAsync(id);

            if (categorie != null)
            {
                Categorie = categorie;
                _context.Categorie.Remove(Categorie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
