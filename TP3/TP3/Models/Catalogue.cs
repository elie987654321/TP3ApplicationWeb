using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TP2.Models
{
    public class Catalogue
    {
        // Attribut
        private List<Jeu> listeDeJeux;

        // Constructeur par defaut
        public Catalogue()
        {
            this.listeDeJeux = new List<Jeu>();
        }

        // Accesseur et mutateur
        public List<Jeu> ListeDeJeux { get => listeDeJeux; set => listeDeJeux = value; }

        // Methodes
        // Ajoute un jeu ou des jeux a partir d'un fichier JSON dans listeDeJeux
        public void Ajouter(int decision, Jeu jeu, string fichier)
        {

            // Ajoute un jeu envoye en argument
            if (decision == 1)
            {

                if (this.listeDeJeux.Contains(jeu))
                {
                    Console.WriteLine("Le jeu existe déjà dans la liste");
                }
                else
                {
                    this.listeDeJeux.Add(jeu);
                }

            }
            // Ajoute une liste de jeux à partir d'un fichier json
            else if (decision == 2)
            {
                try
                {
                    List<Jeu> jeuxJson;
                    jeuxJson = JsonConvert.DeserializeObject<List<Jeu>>(File.ReadAllText(@fichier));

                    foreach (Jeu objet in jeuxJson)
                    {
                        if (!this.listeDeJeux.Contains(objet))
                        {
                            this.listeDeJeux.Add(objet);
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Votre fichier n'est pas valide, veuillez entrez un fichier valide");
                    System.Environment.Exit(1);
                }
            }
        }

        // Modifie un jeu par un autre
        public void Modifier(string nomDuJeuARemplacer, Jeu jeu)
        {

            for (int i = 0; i < this.listeDeJeux.Count; i++)
            {
                try
                {
                    if (this.listeDeJeux[i].NomDuJeu.ToString() == nomDuJeuARemplacer)
                    {
                        if (this.listeDeJeux[i] == jeu)
                        {
                            Console.WriteLine("Vous essayez de modifier un jeu par le même jeu");
                        }
                        else
                        {
                            this.listeDeJeux[i] = jeu;
                        }

                    }
                }
                catch (Exception e)
                {

                }

            }

        }

        // Supprime un jeu ou tous les jeux dans listeDejeux
        public void Supprimer(int decision, string nomDuJeuASupprimer)
        {

            if (decision == 1)
            {
                try
                {
                    foreach (Jeu objet in this.listeDeJeux)
                    {
                        if (objet.NomDuJeu == nomDuJeuASupprimer)
                        {
                            this.listeDeJeux.Remove(objet);
                        }

                    }
                }
                catch (Exception e)
                {

                }

            }
            else if (decision == 2)
            {
                this.listeDeJeux.Clear();
                Console.WriteLine("Tous les jeux ont ete supprimes");

            }

        }

        // Sauvegarde les jeux dans un fichier JSON
        public void Sauvegarder(string fichier)
        {
            string invalide = "Votre fichier n'est pas valide, veuillez entrez un fichier valide";

            if (System.IO.Path.HasExtension(fichier))
            {
                if (File.Exists(fichier))
                {
                    string jsonListe = JsonConvert.SerializeObject(this.listeDeJeux, Formatting.Indented, new StringEnumConverter());
                    File.WriteAllText(@fichier, jsonListe);
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

    }
}
