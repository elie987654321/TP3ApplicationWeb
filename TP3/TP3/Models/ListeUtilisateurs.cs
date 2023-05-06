using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TP3.Models
{
    public class ListeUtilisateurs
    {
        private  List<Utilisateur> liste;

        

        public ListeUtilisateurs()
        {
            liste = new List<Utilisateur>();
        }

        public List<Utilisateur> Liste { get => liste; set => liste = value; }

        public void Sauvegarder(string fichier)
        {
            string invalide = "Votre fichier n'est pas valide, veuillez entrez un fichier valide";

            if (System.IO.Path.HasExtension(fichier))
            {
                if (File.Exists(fichier))
                {
                    string json = JsonConvert.SerializeObject(this.liste, Formatting.Indented, new StringEnumConverter());
                    File.WriteAllText(@fichier, json);
                    Console.WriteLine("La sauvegarde a bien ete effectue");
                }
                else
                {
                    Console.WriteLine(invalide);
                }
            }
            else
            {
                Console.WriteLine(invalide);
            }
        }



        public void Charger(string fichier)
        {
            string invalide = "Votre fichier n'est pas valide, veuillez entrez un fichier valide";

            if (System.IO.Path.HasExtension(fichier))
            {
                if (File.Exists(fichier))
                {

                    this.liste = JsonConvert.DeserializeObject<List<Utilisateur>>(File.ReadAllText(@fichier));
                    Console.WriteLine("La liste a bien ete chargée");
                }
                else
                {
                    Console.WriteLine(invalide);
                }
            }
            else
            {
                Console.WriteLine(invalide);
            }
        }

        public void AjouterUtilisateur(Utilisateur utilisateur)
        {
            this.liste.Add(utilisateur);
        }
        /*
        public void SupprimerUtilisateur(string identifiantUnique)
        {
            this.liste = (List<Utilisateur>)
                        ( from x in this.liste
                         where x.IdentifiantUnique != identifiantUnique
                         select x);
        }*/


        //Retourne null si la combinaison pseudo/mot de passe ne correspond a aucun utilisateur
        public Utilisateur Connexion(string identifiant, string motDePasse)
        {
            bool trouve = false;
            int i = 0;
            Utilisateur u ;

            do {
                u = this.liste[i];
                trouve = u.IdentifiantUnique == identifiant && u.MotDePasse == motDePasse; 
                i++;
            } 
            while (!trouve && i < liste.Count);

            if (trouve)
            {
                return u;
            }
            else
            {
                return null;
            }
        }

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
                trouve = utilisateurATester.IdentifiantUnique == identifiantUnique;
                i++;
            }
            while (!trouve && i < liste.Count - 1);
            if (trouve)
            {
                return false;
            }

            //Ajout de l'utilisateur
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.IdentifiantUnique = identifiantUnique;
            utilisateur.Pseudo = pseudo;
            utilisateur.MotDePasse = motDePasse;
            utilisateur.Prenom = prenom;
            utilisateur.Nom = nom;
            this.AjouterUtilisateur(utilisateur);
            this.Sauvegarder(emplacementFichier == "" ? Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json" : emplacementFichier);

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
