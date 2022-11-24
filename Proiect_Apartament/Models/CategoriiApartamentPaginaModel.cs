using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Apartament.Data;
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
        public void UpdateCategoriiApartamente(Proiect_ApartamentContext context,
        string[] categorieSelectata, Apartament apartamentUpdatat)
        {
            if (categorieSelectata == null)
            {
                apartamentUpdatat.CategoriiApartament = new List<CategorieApartament>();
                return;
            }
            var CategorieSelectataHS = new HashSet<string>(categorieSelectata);
            var apartamentCategorii = new HashSet<int>
            (apartamentUpdatat.CategoriiApartament.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (CategorieSelectataHS.Contains(cat.ID.ToString()))
                {
                    if (!apartamentCategorii.Contains(cat.ID))
                    {
                        apartamentUpdatat.CategoriiApartament.Add(
                        new CategorieApartament
                        {
                            ApartamentID = apartamentUpdatat.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (apartamentCategorii.Contains(cat.ID))
                    {
                        CategorieApartament courseToRemove
                        = apartamentUpdatat
                        .CategoriiApartament
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
