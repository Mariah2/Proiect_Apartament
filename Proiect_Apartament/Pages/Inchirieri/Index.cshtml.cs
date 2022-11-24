using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Inchirieri
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;

        public IndexModel(Proiect_Apartament.Data.Proiect_ApartamentContext context)
        {
            _context = context;
        }

        public IList<Inchiriere> Inchiriere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inchiriere != null)
            {
                Inchiriere = await _context.Inchiriere
                .Include(i => i.Apartament)
                .ThenInclude(b => b.Proprietar)
                .Include(i => i.Member).ToListAsync();
            }
        }
    }
}
