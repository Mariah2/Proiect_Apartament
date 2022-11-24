using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Proprietari
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public DetailsModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

      public Proprietar Proprietar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Proprietar == null)
            {
                return NotFound();
            }

            var proprietar = await _context.Proprietar.FirstOrDefaultAsync(m => m.ID == id);
            if (proprietar == null)
            {
                return NotFound();
            }
            else 
            {
                Proprietar = proprietar;
            }
            return Page();
        }
    }
}
