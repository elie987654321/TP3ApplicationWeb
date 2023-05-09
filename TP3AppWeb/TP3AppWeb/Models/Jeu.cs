
using System.ComponentModel.DataAnnotations;
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


        /*//Methode
        public bool Nouveaute()
        {
            bool estNouveau = false;

            if((DateTime.Now - this.DateProduction).TotalDays < 30)
            {
                estNouveau = true;
            }

            return estNouveau;
        }

        public void AjouterEvaluationCote(List<Evaluation> listeEvaluation)
        {
            
            foreach (Evaluation evaluation in listeEvaluation) {
                if (this.Evaluation.Description == evaluation.Description)
                {
                    this.EvaluationMoyenne.Add( evaluation.Cote);
                }
                    
            }
        }

        public int MoyenneEvaluations()
        {
            int total = 0;

            foreach (int cote in EvaluationMoyenne)
            {
                total += Convert.ToInt32(((int)cote));
            }

            double moyenne = total / EvaluationMoyenne.Count;

            return Convert.ToInt32(Math.Floor(moyenne));
        }

        // Comparaison
        public static bool operator ==(Jeu jeu1, Jeu jeu2)
        {
            return jeu1.NomDuJeu == jeu2.NomDuJeu;
        }

        public static bool operator !=(Jeu jeu1, Jeu jeu2)
        {
            return jeu1.NomDuJeu != jeu2.NomDuJeu;
        }


        // ToString
        public override string ToString()
        {
            return $"{NomDuJeu} :\n" +
                $"   Type de jeu - {TypeDeJeu}\n" +
                $"   Evaluation - {Evaluation}\n" +
                $"   Date de production - {DateProduction}\n" +
                $"   Duree - {Duree}\n" +
                $"   Auteur - {Auteur}\n" +
                $"   Producteur - {Producteur}\n" +
                $"   Lien de l'extrait - {Extrait}\n" +
                $"   Lien vers le jeu complet - {Complet}\n" +
                $"   Lien vers l'image - {Image}\n";
        }*/
    }
}
