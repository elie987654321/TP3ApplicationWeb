
namespace TP3.Models
{
    public class ListeUtilisateurs
    {
        public int IdListeUtilisateur;

        private  List<Utilisateur> liste;

        //Retourne false si l'utilisateur ne peut pas etre creer
        public bool CreerUtilisateur(string identifiantUnique,string pseudo, string motDePasse, string nom, string prenom, string emplacementFichier = "")
        {
            if (identifiantUnique == null || identifiantUnique == "")
            {
                return false;
            }

            //Verifie qu'un pseudo valide a été entrer
            if (pseudo == null || pseudo == "")
            {
                return false;
            }


            //Verifie qu'un mot de passe valide a été entrée
            if (motDePasse == null || motDePasse == "")
            {
                return false;
            }


            if (prenom == null || prenom == "")
            {
                return false;
            }

            if (nom == null || nom == "")
            {
                return false;
            }



            //Verifie si le nom d'utilisateur existe deja
            bool trouve = false;
            int i = 0;
            Utilisateur utilisateurATester;
            do
            {
                utilisateurATester = this.liste[i];
                trouve = utilisateurATester.IDUtilisateur == identifiantUnique;
                i++;
            }
            while (!trouve && i < liste.Count - 1);
            if (trouve)
            {
                return false;
            }

            //Ajout de l'utilisateur
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.IDUtilisateur = identifiantUnique;
            utilisateur.Pseudo = pseudo;
            utilisateur.MotDePasse = motDePasse;
            utilisateur.Prenom = prenom;
            utilisateur.Nom = nom;
            
            //TODO gerer ça avec entity
            //this.AjouterUtilisateur(utilisateur);
            //this.Sauvegarder(emplacementFichier == "" ? Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json" : emplacementFichier);

            return true;
        }

        public Utilisateur GetUtilisateurByPseudo(string pseudo)
        {
            Utilisateur u = null;

            int i = 0;
            do
            {
                if (liste[i].Pseudo == pseudo)
                {
                    u = liste[i];
                }
                i++;
            }
            while (i < liste.Count && u == null);

            return u;
        }
    }
}
