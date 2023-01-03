using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Pages.Inchirieri
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Apartament.Data.Proiect_ApartamentContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(Proiect_Apartament.Data.Proiect_ApartamentContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            var userName = _userManager.GetUserName(User);

            var apartamentLista = _context.Apartament
                .Include(b => b.Proprietar)
                .Select(x => new
                    {
                        x.ID,
                        ApartamentNume = x.Nume + " - " + x.Proprietar.NumeProprietar
                    });
            
            var membruDetalii = _context.Member
               .Where(m => m.Email == userName)
               .Select(x => new
               {
                   x.ID,
                   DetaliiMembru = x.Nume + " " + x.Prenume
               });

            ViewData["ApartamentID"] = new SelectList(apartamentLista, "ID", "ApartamentNume");
            ViewData["MemberID"] = new SelectList(membruDetalii, "ID", "DetaliiMembru");
            return Page();
        }

        [BindProperty]
        public Inchiriere Inchiriere { get; set; } = new Inchiriere();


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (Inchiriere.CheckoutDate <= Inchiriere.CheckinDate)
            {
                return RedirectToPage("./Create");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Inchiriere.Add(Inchiriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
