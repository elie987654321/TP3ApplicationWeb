

namespace TP3.Models
{
    public class Utilisateur
    {
        // Enumeration
        public enum RoleDUtilisateur
        {
            Utilisateur,
            Admin,
            Technicien
        }


        // Attributs
        public string IdentifiantUnique { get; set ; }
        public string Pseudo { get ; set ; }
        public string MotDePasse { get ; set ; }
        public string Nom { get ; set ; }
        public string Prenom { get ; set ; }
        public RoleDUtilisateur Role { get; set ; }
        public List<Jeu> Favoris { get; set; }
        public List<Evaluation> Evaluations { get; set; }

    }
}
