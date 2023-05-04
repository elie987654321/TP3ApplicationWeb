using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TP2.Models
{
    [Serializable]
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
        private string identifiantUnique;
        private string pseudo;
        private string motDePasse;
        private string nom;
        private string prenom;
        private RoleDUtilisateur role;
        private List<Jeu> favoris;
        private List<Evaluation> evaluations;

        public string IdentifiantUnique { get => identifiantUnique; set => identifiantUnique = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public RoleDUtilisateur Role { get => role; set => role = value; }
        public List<Jeu> Favoris { get => favoris; }
        public List<Evaluation> Evaluations { get => evaluations; }

        // Constructeur par defaut
        public Utilisateur()
        {
            this.identifiantUnique = "";
            this.pseudo = "";
            this.motDePasse = "";
            this.nom = "";
            this.prenom = "";
            this.role = RoleDUtilisateur.Utilisateur;
            this.favoris = new List<Jeu>();
            this.evaluations = new List<Evaluation>();
        }

        // Constructeur complet sans les favoris et évaluations
        public Utilisateur(string identifiantUnique, string pseudo, string motDePasse, string nom, string prenom, RoleDUtilisateur role)
        {
            this.identifiantUnique = identifiantUnique;
            this.pseudo = pseudo;
            this.motDePasse = motDePasse;
            this.nom = nom;
            this.prenom = prenom;
            this.role = role;
            this.favoris = new List<Jeu>();
            this.evaluations = new List<Evaluation>();
        }

        // Methodes
        public void AjouterFavori(Jeu favori)
        {
            this.favoris.Add(favori);
        }

        public void AjouterEvaluation(Evaluation evaluation)
        {
            this.evaluations.Add(evaluation);
        }

    }
}
