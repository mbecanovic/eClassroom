using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<klase1.Predmeti> Predmeti { get; set; }
        public DbSet<klase1.Pitanja> Pitanja { get; set; }
        public DbSet<klase1.Oblasti> Oblasti { get; set; }
    }

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NQ2UHDB;Database=comtradeDB;Trusted_Connection=True;TrustServerCertificate=True;");
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}

namespace klase1
{
    public class Predmeti
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Pitanja> Pitanje { get; set; } = new List<Pitanja>();
    }

    public class Pitanja
    {
        [Key]
        public int ID { get; set; }
        public int IDPredmet { get; set; }
        [ForeignKey("IDPredmet")]

        public Predmeti Predmet { get; set; }
        public int IDOblast { get; set; }
        [ForeignKey("IDOblast")]

        public Oblasti Oblast { get; set; }

        public string Nivo { get; set; }

        public string Pitanje { get; set; }

        public string Odgovor { get; set; }

    }

    public class Oblasti
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IDPredmeta { get; set; }
        public ICollection<Pitanja> Pitanje { get; set; } = new List<Pitanja>();
    }
}
