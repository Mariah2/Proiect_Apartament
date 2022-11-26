using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Data;
using System.Net;

namespace Proiect_Apartament.Models
{
    public class CategoriiApartamentPaginaModel : PageModel
    {
        public List<DataCategorieiAsignate> DataCategorieiAsignateLista;
        public void PopulateAssignedCategoryData(Proiect_ApartamentContext context, Apartament apartament)
        {
            var toateCategoriile = context.Categorie;
            var apartamentCategorii = new HashSet<int>(
                apartament.CategoriiApartament.Select(c => c.CategorieID)); //
            DataCategorieiAsignateLista = new List<DataCategorieiAsignate>();
            foreach (var cat in toateCategoriile)
            {
                DataCategorieiAsignateLista.Add(new DataCategorieiAsignate
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Asignat = apartamentCategorii.Contains(cat.ID)
                });
            }
        }
        public async Task UpdateCategoriiApartamente(Proiect_ApartamentContext context, string[] categoriiSelectate, int apartamentId)
        {
            var categoriiApartament = await context.Set<CategorieApartament>().Where(ca => ca.ApartamentID == apartamentId).ToListAsync();

            if (categoriiSelectate is null)
            {
                foreach (var categorieApartament in categoriiApartament)
                {
                    context.Set<CategorieApartament>().Remove(categorieApartament).State = EntityState.Deleted;
                }

                return;
            }

            var categoriiDeSters = categoriiApartament.Where(ca => !categoriiSelectate.Contains(ca.CategorieID.ToString()));

            foreach (var categorieApartament in categoriiDeSters)
            {
                context.Set<CategorieApartament>().Remove(categorieApartament).State = EntityState.Deleted;
            }

            foreach (var categorieId in categoriiSelectate)
            {
                int parsatCategorieId = int.Parse(categorieId);

                if (categoriiApartament.Find(ca => ca.CategorieID == parsatCategorieId) is null)
                {
                    context.Set<CategorieApartament>().Add(new CategorieApartament
                    {
                        ApartamentID = apartamentId,
                        CategorieID = parsatCategorieId
                    }).State = EntityState.Added;
                }
            }
        }
    }
}
