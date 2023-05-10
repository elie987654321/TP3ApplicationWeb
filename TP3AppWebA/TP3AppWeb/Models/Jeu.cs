
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3AppWeb.Models
{
    public class Jeu
    {
        // Enumeration
        public enum TypeJeu
        {
            Monde_Ouvert,
            FPS,
            Simulation_De_Ferme,
            Survie,
            Horreur,
            Roguelike,
            Strategie,
            Sport,
            Crime
        }

        // Attributs
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JeuID { get; set; }
        [ForeignKey("Evaluation")]
        public int EvaluationID { get; set; }

        public string NomDuJeu { get; set; }
        public TypeJeu TypeDeJeu { get; set; }
        public DateTime DateProduction { get; set; }
        public string Duree { get; set; }
        public string Auteur { get; set; }
        public string Producteur { get; set; }
        public string Extrait { get; set; }
        public string Complet { get; set; }
        public string Image { get; set; }

        public virtual Evaluation Evaluation { get; set; }

    }
}
