using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class BD : DbContext
    {
        public DbSet<Catalogue> catalogues;
        public DbSet<Evaluation> evaluations;
        public DbSet<Jeu> jeux;
        public DbSet<ListeUtilisateurs> listeUtilisateurs;
        public DbSet<Utilisateur> utilisateurs;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(
            @"Server=(localdb)\MSSQLLocalDB;Database=Ecole;Trusted_Connection=True;"
            );
            base.OnConfiguring(optionsBuilder);
        }

    }
}
