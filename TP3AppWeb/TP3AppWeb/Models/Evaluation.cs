
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3AppWeb.Models
{
    public class Evaluation
    {
        // Enumeration
        public enum CoteDeJeu
        {
            EXCELLENT = 5,
            TRES_BON = 4,
            BON = 3,
            MOYEN = 2,
            MAUVAIS = 1
        }

        // Attributs
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EvaluationID { get; set; }

        public CoteDeJeu Cote { get; set; }
        public string Description { get; set; }

    }
}
