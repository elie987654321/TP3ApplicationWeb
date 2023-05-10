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
    }
}
