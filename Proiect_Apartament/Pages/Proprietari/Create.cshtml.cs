using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Proprietari
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public CreateModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Proprietar Proprietar { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Proprietar.Add(Proprietar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
