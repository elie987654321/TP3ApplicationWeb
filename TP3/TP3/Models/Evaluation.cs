namespace TP2.Models
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
        private CoteDeJeu cote;
        private string description;

        public CoteDeJeu Cote { get => cote; set => cote = value; }
        public string Description { get => description; set => description = value; }

        // Constructeur par defaut
        public Evaluation()
        {
            this.Cote = new CoteDeJeu();
            this.Description = "";
        }


        // Constructeur complet
        public Evaluation(CoteDeJeu cote, string description)
        {
            this.Cote = cote;
            this.Description = description;
        }



        // ToString
        public override string ToString()
        {
            return this.Cote + ", " + this.Description;
        }
    }
}
