using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class BD : DbContext
    {
       public DbSet<Evaluation> evaluations { get; set; }
        public DbSet<Jeu> jeux { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(
            @"Server=(localdb)\MSSQLLocalDB;Database=TP3;Trusted_Connection=True;"
            );
            base.OnConfiguring(optionsBuilder);
        }

    }
}
