using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP3.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TP2.Controllers
{
    public class HomeController : Controller
    {
        private readonly BD _context = new BD();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Accueil()
        {


            string userString = HttpContext.Session.GetString("Utilisateur");

            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }
            
            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);

            ViewBag.Pseudo = user.Pseudo;
            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ListeDeJeux()
        {

            string userString = HttpContext.Session.GetString("Utilisateur");
            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);

            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }


            List<Jeu> listJeu = _context.jeux.ToList();
            
            ViewBag.Pseudo = user.Pseudo;

            return View(listJeu);
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Favoris()
        {
            Catalogue catalogue = new Catalogue();
            catalogue.Ajouter(2, null, Environment.CurrentDirectory + "/wwwroot/json/fichierDeJeux.json");

            ListeUtilisateurs listeDesUtilisateurs = new ListeUtilisateurs();
            listeDesUtilisateurs.Charger(Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json");

            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);

            List<Jeu> mesFavoris = new List<Jeu>();

            foreach (Utilisateur uti in listeDesUtilisateurs.Liste)
            {
                if (uti.IdentifiantUnique == user.IdentifiantUnique)
                {
                    mesFavoris = uti.Favoris;
                }
            }

            Tuple<List<Jeu>, List<Jeu>> model = new Tuple<List<Jeu>, List<Jeu>>(mesFavoris, catalogue.ListeDeJeux);

            ViewBag.Pseudo = user.Pseudo;

            return View(model);
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult FicheDeJeu(int id)
        {
            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            Catalogue catalogue = new Catalogue();
            catalogue.Ajouter(2, null, Environment.CurrentDirectory + "/wwwroot/json/fichierDeJeux.json");

            if (id >= 0 || id <= catalogue.ListeDeJeux.Count - 1)
            {

                ViewBag.NomDuJeu = catalogue.ListeDeJeux[id].NomDuJeu;
                ViewBag.TypeDeJeu = catalogue.ListeDeJeux[id].TypeDeJeu;
                ViewBag.EvaluationCote = catalogue.ListeDeJeux[id].Evaluation.Cote;
                ViewBag.EvaluationDescription = catalogue.ListeDeJeux[id].Evaluation.Description;
                ViewBag.DateProduction = catalogue.ListeDeJeux[id].DateProduction;
                ViewBag.Duree = catalogue.ListeDeJeux[id].Duree;
                ViewBag.Auteur = catalogue.ListeDeJeux[id].Auteur;
                ViewBag.Producteur = catalogue.ListeDeJeux[id].Producteur;
                ViewBag.Extrait = catalogue.ListeDeJeux[id].Extrait;
                ViewBag.Complet = catalogue.ListeDeJeux[id].Complet;
                ViewBag.Image = id+1 + ".jpg";
                ViewBag.Id = id;
            }
            
            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);
            ViewBag.Pseudo = user.Pseudo;

            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult FicheDeJeuFavori(int id)
        {
            Catalogue catalogue = new Catalogue();
            catalogue.Ajouter(2, null, Environment.CurrentDirectory + "/wwwroot/json/fichierDeJeux.json");

            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            if (id >= 0 || id <= catalogue.ListeDeJeux.Count - 1)
            {

                ViewBag.NomDuJeu = catalogue.ListeDeJeux[id].NomDuJeu;
                ViewBag.TypeDeJeu = catalogue.ListeDeJeux[id].TypeDeJeu;
                ViewBag.EvaluationCote = catalogue.ListeDeJeux[id].Evaluation.Cote;
                ViewBag.EvaluationDescription = catalogue.ListeDeJeux[id].Evaluation.Description;
                ViewBag.DateProduction = catalogue.ListeDeJeux[id].DateProduction;
                ViewBag.Duree = catalogue.ListeDeJeux[id].Duree;
                ViewBag.Auteur = catalogue.ListeDeJeux[id].Auteur;
                ViewBag.Producteur = catalogue.ListeDeJeux[id].Producteur;
                ViewBag.Extrait = catalogue.ListeDeJeux[id].Extrait;
                ViewBag.Complet = catalogue.ListeDeJeux[id].Complet;
                ViewBag.Image = id + 1 + ".jpg";
                ViewBag.Id = id;
            }

            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);

            ViewBag.Pseudo = user.Pseudo;

            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult AjouterAuFavori(int id)
        {
            Catalogue catalogue = new Catalogue();
            catalogue.Ajouter(2, null, Environment.CurrentDirectory + "/wwwroot/json/fichierDeJeux.json");

            ListeUtilisateurs listeDesUtilisateurs = new ListeUtilisateurs();
            listeDesUtilisateurs.Charger(Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json");

            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }
            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);

            bool contientJeu = false;

            if (id >= 0 || id <= catalogue.ListeDeJeux.Count - 1)
            {
                foreach (Utilisateur uti in listeDesUtilisateurs.Liste)
                {
                    if (uti.IdentifiantUnique == user.IdentifiantUnique)
                    {
                        foreach (var jeu in uti.Favoris)
                        {
                            if (catalogue.ListeDeJeux[id].NomDuJeu.Equals(jeu.NomDuJeu))
                            {
                                contientJeu = true;
                            }
                        }
                        
                        if (!contientJeu)
                        {
                            uti.Favoris.Add(catalogue.ListeDeJeux[id]);
                            listeDesUtilisateurs.Sauvegarder(Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json");
                        }
                    }
                }  
            }

            return RedirectToAction("FicheDeJeu", "Home", new {id=id});
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult SupprimerDesFavoris(int id, string nomDuJeu)
        {
            ListeUtilisateurs listeDesUtilisateurs = new ListeUtilisateurs();
            listeDesUtilisateurs.Charger(Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json");

            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);

            foreach (Utilisateur uti in listeDesUtilisateurs.Liste)
            {
                if (uti.IdentifiantUnique == user.IdentifiantUnique)
                {
                    foreach (var favori in uti.Favoris)
                    {
                        if (favori.NomDuJeu.Equals(nomDuJeu))
                        {
                            uti.Favoris.Remove(favori);
                            listeDesUtilisateurs.Sauvegarder(Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json");
                            break;
                        }
                    }

                }
            }
            
            return RedirectToAction("Favoris", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Deconnexion()
        {
            this.HttpContext.Session.Remove("Utilisateur");
            return RedirectToAction("Accueil", "Connexion");
        }
    }

}