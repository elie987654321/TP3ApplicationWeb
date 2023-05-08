using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class BD : DbContext
    {
        public DbSet<Catalogue> catalogues;
        public DbSet<Evaluation> evaluations;
        public DbSet<Jeu> jeu;
        public DbSet<ListeUtilisateurs> listeUtilisateurs;
        public DbSet<Utilisateur> utilisateurs;
    }
}
