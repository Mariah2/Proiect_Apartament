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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public DetailsModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

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
    }
}
