using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Apartamente
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public DeleteModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Apartament Apartament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Apartament == null)
            {
                return NotFound();
            }

            var apartament = await _context.Apartament
                .Include(b => b.Proprietar)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (apartament == null)
            {
                return NotFound();
            }
            else 
            {
                Apartament = apartament;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Apartament == null)
            {
                return NotFound();
            }
            var apartament = await _context.Apartament.FindAsync(id);

            if (apartament != null)
            {
                Apartament = apartament;
                _context.Apartament.Remove(Apartament);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
