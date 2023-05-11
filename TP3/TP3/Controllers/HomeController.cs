using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP3.Models;
using Newtonsoft.Json;

namespace TP3.Controllers
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
            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            Utilisateur utilisateurModel = _context.utilisateurs.Where(u => u.IDUtilisateur == JsonConvert.DeserializeObject<Utilisateur>(userString).IDUtilisateur).FirstOrDefault();

            List<Jeu> listJeux = _context.jeux.ToList();

            List<Jeu> favoris = utilisateurModel.Favoris;

            Tuple<List<Jeu>, List<Jeu>> model = new Tuple<List<Jeu>, List<Jeu>>(favoris, listJeux);

            ViewBag.Pseudo = utilisateurModel.Pseudo;

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


            List<Jeu> listJeu = _context.jeux.ToList();

            Jeu jeu = _context.jeux.Where(j => j.IDJeu == id).FirstOrDefault(); 

            

            ViewBag.NomDuJeu = jeu.NomDuJeu;
            ViewBag.TypeDeJeu = jeu.TypeDeJeu;
            ViewBag.EvaluationCote = jeu.Evaluation.Cote;
            ViewBag.EvaluationDescription = jeu.Evaluation.Description;
            ViewBag.DateProduction = jeu.DateProduction;
            ViewBag.Duree = jeu.Duree;
            ViewBag.Auteur = jeu.Auteur;
            ViewBag.Producteur = jeu.Producteur;
            ViewBag.Extrait = jeu.Extrait;
            ViewBag.Complet = jeu.Complet;
            ViewBag.Image = id+1 + ".jpg";
            ViewBag.Id = id;
       
            
            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);
            ViewBag.Pseudo = user.Pseudo;

            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult FicheDeJeuFavori(int id)
        {
            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            Jeu jeu = _context.jeux.Where(j => j.IDJeu == id).FirstOrDefault();

            { 
                ViewBag.NomDuJeu = jeu.NomDuJeu;
                ViewBag.TypeDeJeu = jeu.TypeDeJeu;
                ViewBag.EvaluationCote = jeu.Evaluation.Cote;
                ViewBag.EvaluationDescription = jeu.Evaluation.Description;
                ViewBag.DateProduction = jeu.DateProduction;
                ViewBag.Duree = jeu.Duree;
                ViewBag.Auteur = jeu.Auteur;
                ViewBag.Producteur = jeu.Producteur;
                ViewBag.Extrait = jeu.Extrait;
                ViewBag.Complet = jeu.Complet;
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
            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }
            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);

            bool contientJeu = false;
            

            Utilisateur utilisateur = _context.utilisateurs.Where(u => u.IDUtilisateur == user.IDUtilisateur).FirstOrDefault();

            if (utilisateur.Favoris.Where(f => f.IDJeu == id).FirstOrDefault() != null)
            {
                utilisateur.Favoris.Add(_context.jeux.Where(j => j.IDJeu == id).First());
            }

            _context.SaveChanges();


        

            return RedirectToAction("FicheDeJeu", "Home", new {id=id});
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult SupprimerDesFavoris(int id, string nomDuJeu)
        {
          
            string userString = HttpContext.Session.GetString("Utilisateur");
            if (userString == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            List<Utilisateur> listUtilisateur = _context.utilisateurs.ToList();


            Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(userString);
            
            Utilisateur utilisateurModel = _context.utilisateurs.Where(u => u.IDUtilisateur == user.IDUtilisateur).FirstOrDefault();
            Jeu jeu = _context.jeux.Where(j => j.NomDuJeu == nomDuJeu).FirstOrDefault();

            utilisateurModel.Favoris.Remove(jeu);

            _context.SaveChanges();
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