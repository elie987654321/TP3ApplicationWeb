

namespace TP3.Models
{
    public class Utilisateur
    {
        // Enumeration
        public enum RoleDUtilisateur
        {
            Utilisateur = 1,
            Admin = 2,
            Technicien = 3
        }


        
        public string IDUtilisateur { get; set ; }
        public string Pseudo { get ; set ; }
        public string MotDePasse { get ; set ; }
        public string Nom { get ; set ; }
        public string Prenom { get ; set ; }
        public int Role { get; set ; }
        public List<Jeu> Favoris { get; set; }
        public List<Evaluation> Evaluations { get; set; }


        public RoleDUtilisateur RoleIntToEnum()
        { 
            return (RoleDUtilisateur) Role;
        }
    }
}
