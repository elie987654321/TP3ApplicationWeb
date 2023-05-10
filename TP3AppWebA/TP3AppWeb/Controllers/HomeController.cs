using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP3AppWeb.Models;

namespace TP3AppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly TP3Context _context = new TP3Context();

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Accueil()
        {
            string identifiantUnique = HttpContext.Session.GetString("IdentifiantUnique");

            if (identifiantUnique == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            ViewBag.Pseudo = HttpContext.Session.GetString("Pseudo");

            return View(_context.Jeux.Count());
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ListeDeJeux()
        {
            string identifiantUnique = HttpContext.Session.GetString("IdentifiantUnique");

            if (identifiantUnique == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            ViewBag.Pseudo = HttpContext.Session.GetString("Pseudo");

            return View(_context.Jeux.ToList());
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Favoris()
        {

            string identifiantUnique = HttpContext.Session.GetString("IdentifiantUnique");

            if (identifiantUnique == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            ViewBag.Pseudo = HttpContext.Session.GetString("Pseudo");


            Utilisateur utilisateurConnecte = null;

            Utilisateur utilisateur = _context.Utilisateurs.SingleOrDefault(u => u.IdentifiantUnique == identifiantUnique);

            if (utilisateur != null)
            {
                if (HttpContext.Session.GetString("IdentifiantUnique") == utilisateur.IdentifiantUnique)
                {
                    utilisateurConnecte = utilisateur;

                }
            }

            Tuple<List<Jeu>, List<Jeu>> model = new Tuple<List<Jeu>, List<Jeu>>(utilisateurConnecte.Favoris.ToList(), _context.Jeux.ToList());

            return View(model);
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult FicheDeJeu(int id)
        {
            string identifiantUnique = HttpContext.Session.GetString("IdentifiantUnique");

            if (identifiantUnique == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            if (HttpContext.Session.GetString("Role") != null)
            {
                ViewBag.Role = HttpContext.Session.GetString("Role");
            }

            ViewBag.Pseudo = HttpContext.Session.GetString("Pseudo");

            List<Jeu> catalogue = _context.Jeux.ToList();

            if (id >= 0 || id <= catalogue.Count - 1)
            {

                ViewBag.NomDuJeu = catalogue[id].NomDuJeu;
                ViewBag.TypeDeJeu = catalogue[id].TypeDeJeu;
                ViewBag.EvaluationCote = catalogue[id].Evaluation.Cote;
                ViewBag.EvaluationDescription = catalogue[id].Evaluation.Description;
                ViewBag.DateProduction = catalogue[id].DateProduction;
                ViewBag.Duree = catalogue[id].Duree;
                ViewBag.Auteur = catalogue[id].Auteur;
                ViewBag.Producteur = catalogue[id].Producteur;
                ViewBag.Extrait = catalogue[id].Extrait;
                ViewBag.Complet = catalogue[id].Complet;
                ViewBag.Image = id + 1 + ".jpg";
                ViewBag.Id = id;
            }

            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult FicheDeJeuFavori(int id)
        {
            string identifiantUnique = HttpContext.Session.GetString("IdentifiantUnique");

            if (identifiantUnique == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            if (HttpContext.Session.GetString("Role") != null)
            {
                ViewBag.Role = HttpContext.Session.GetString("Role");
            }
            
            ViewBag.Pseudo = HttpContext.Session.GetString("Pseudo");

            List<Jeu> catalogue = _context.Jeux.ToList();

            if (id >= 0 || id <= catalogue.Count - 1)
            {

                ViewBag.NomDuJeu = catalogue[id].NomDuJeu;
                ViewBag.TypeDeJeu = catalogue[id].TypeDeJeu;
                ViewBag.EvaluationCote = catalogue[id].Evaluation.Cote;
                ViewBag.EvaluationDescription = catalogue[id].Evaluation.Description;
                ViewBag.DateProduction = catalogue[id].DateProduction;
                ViewBag.Duree = catalogue[id].Duree;
                ViewBag.Auteur = catalogue[id].Auteur;
                ViewBag.Producteur = catalogue[id].Producteur;
                ViewBag.Extrait = catalogue[id].Extrait;
                ViewBag.Complet = catalogue[id].Complet;
                ViewBag.Image = id + 1 + ".jpg";
                ViewBag.Id = id;
            }

            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult AjouterAuFavori(int id)
        {
            string identifiantUnique = HttpContext.Session.GetString("IdentifiantUnique");

            if (identifiantUnique == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            Utilisateur utilisateurConnecte = null;
            List<Jeu> catalogue = _context.Jeux.ToList();
            bool contientJeu = false;
            Utilisateur utilisateur = _context.Utilisateurs.SingleOrDefault(u => u.IdentifiantUnique == identifiantUnique);
            
            if (id >= 0 || id <= catalogue.Count - 1)
            {
                if (utilisateur != null)
                {
                    if (utilisateur.IdentifiantUnique == identifiantUnique)
                    {
                        utilisateurConnecte = utilisateur;
                    }
                }

                if (utilisateurConnecte.Favoris.Count > 0)
                {
                    foreach (Jeu jeu in utilisateurConnecte.Favoris)
                    {
                        if (catalogue[id].NomDuJeu.Equals(jeu.NomDuJeu))
                        {
                            contientJeu = true;
                        }
                    }
                }

                if (!contientJeu)
                {

                    utilisateurConnecte.Favoris.Add(catalogue[id]);

                    _context.Entry(utilisateurConnecte).State = EntityState.Modified;
                    _context.SaveChanges();
                        
                }
            }
            

            return RedirectToAction("FicheDeJeu", "Home", new { id = id });
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult SupprimerDesFavoris(int id, string nomDuJeu)
        {
            string identifiantUnique = HttpContext.Session.GetString("IdentifiantUnique");

            if (identifiantUnique == null)
            {
                return RedirectToAction("Accueil", "Connexion");
            }

            Utilisateur utilisateurConnecte = null;
            Utilisateur utilisateur = _context.Utilisateurs.SingleOrDefault(u => u.IdentifiantUnique == identifiantUnique);
           
            if (utilisateur != null)
            {
                if (utilisateur.IdentifiantUnique == identifiantUnique)
                {
                    utilisateurConnecte = utilisateur;
                }
            }

            if (utilisateurConnecte.Favoris.Count > 0)
            {
                foreach (Jeu favori in utilisateurConnecte.Favoris)
                {
                    if (favori.NomDuJeu.Equals(nomDuJeu))
                    {
                        utilisateurConnecte.Favoris.Remove(favori);

                        _context.Entry(utilisateurConnecte).State = EntityState.Modified;

                        _context.SaveChanges();

                        break;
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
            this.HttpContext.Session.Remove("IdentifiantUnique");
            this.HttpContext.Session.Remove("Pseudo");
            return RedirectToAction("Accueil", "Connexion");
        }
    }
}