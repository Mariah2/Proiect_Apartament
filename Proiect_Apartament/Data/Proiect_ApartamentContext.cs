using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Apartament.Models;

namespace Proiect_Apartament.Data
{
    public class Proiect_ApartamentContext : DbContext
    {
        public Proiect_ApartamentContext (DbContextOptions<Proiect_ApartamentContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Apartament.Models.Apartament> Apartament { get; set; } = default!;

        public DbSet<Proiect_Apartament.Models.Proprietar> Proprietar { get; set; }

        public DbSet<Proiect_Apartament.Models.Categorie> Categorie { get; set; }

        public DbSet<Proiect_Apartament.Models.Member> Member { get; set; }

        public DbSet<Proiect_Apartament.Models.Inchiriere> Inchiriere { get; set; }
    }
}
