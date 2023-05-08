using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Evaluation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDEvaluation;

        // Enumeration
        public enum CoteDeJeu
        {
            EXCELLENT = 5,
            TRES_BON = 4,
            BON = 3,
            MOYEN = 2,
            MAUVAIS = 1
        }


        public int Cote { get; set; }


        public string Description { get; set ; }

    
        public CoteDeJeu CoteAsEnum()
        {
            return (CoteDeJeu)this.Cote;
        }

        // ToString
        public override string ToString()
        {
            return this.Cote + ", " + this.Description;
        }
    }
}
