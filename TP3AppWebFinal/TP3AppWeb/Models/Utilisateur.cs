
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3AppWeb.Models
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

        // Attributs
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UtilisateurID { get; set; }

        public string IdentifiantUnique { get; set; }
        public string Pseudo { get; set; }
        public string MotDePasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public RoleDUtilisateur Role { get; set; }

        public virtual ICollection<Jeu> Favoris { get; set; }

        public Utilisateur()
        {
            Role = RoleDUtilisateur.Utilisateur;
        }
    }
}
