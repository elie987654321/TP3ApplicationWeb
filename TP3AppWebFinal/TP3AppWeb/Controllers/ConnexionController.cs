
using Microsoft.AspNetCore.Mvc;
using TP3AppWeb.Models;


namespace TP3AppWeb.Controllers
{
    public class ConnexionController : Controller
    {

        private readonly TP3Context _context = new TP3Context();

        public ActionResult Accueil(string message = "")
        {
            ViewBag.message = message;
            return View();

        }

        public ActionResult CreerCompte(string message = "")
        {
            ViewBag.message = message;
            return View();
        }

        [HttpPost]
        public ActionResult Connexion(string identifiantUnique, string motDePasse)
        {
            Utilisateur utilisateurTrouve = null;
            string pseudo = "";
            string role = "";

            Utilisateur utilisateur = _context.Utilisateurs.SingleOrDefault(u => u.IdentifiantUnique.Equals(identifiantUnique.ToLower()));

            if (utilisateur != null) { 
                if (identifiantUnique.ToLower().Equals(utilisateur.IdentifiantUnique) && motDePasse.Equals(utilisateur.MotDePasse))
                {
                    utilisateurTrouve = utilisateur;
                    pseudo = utilisateur.Pseudo;
                    role = utilisateur.Role.ToString();

                }
            }

            if (utilisateurTrouve != null)
            {
                this.HttpContext.Session.SetString("IdentifiantUnique", identifiantUnique.ToLower());
                this.HttpContext.Session.SetString("Pseudo", pseudo);
                this.HttpContext.Session.SetString("Role", role);

                return RedirectToAction("Accueil", "Home");
            }
            else
            {
                return RedirectToAction("Accueil", "Connexion", new { @message = "Veuillez entrer un nom d'utilisateur et un mot de passe valide" });
            }

        }

        [HttpPost]
        public ActionResult CreerCompte(string identifiantUnique, string pseudo, string prenom, string nom, string password)
        {

            bool compteExistant = false;

            Utilisateur utilisateur = _context.Utilisateurs.SingleOrDefault(u => u.IdentifiantUnique.Equals(identifiantUnique.ToLower()));

            if (utilisateur != null)
            {
                if (identifiantUnique.ToLower().Equals(utilisateur.IdentifiantUnique))
                {
                    compteExistant = true;
                }
            }

            if (!compteExistant)
            {
                Utilisateur utilisateurCree = new Utilisateur();

                utilisateurCree.UtilisateurID = _context.Utilisateurs.Count() + 1;
                utilisateurCree.IdentifiantUnique = identifiantUnique.ToLower();
                utilisateurCree.Pseudo = pseudo;
                utilisateurCree.MotDePasse = password;
                utilisateurCree.Nom = nom;
                utilisateurCree.Prenom = prenom;
  
                _context.Utilisateurs.Add(utilisateurCree);
                _context.SaveChanges();

                this.HttpContext.Session.SetString("IdentifiantUnique", identifiantUnique.ToLower());
                this.HttpContext.Session.SetString("Pseudo", pseudo);

                return RedirectToAction("Accueil", "Home");
            }
            else
            {
                return RedirectToAction("CreerCompte", "Connexion", new { @message = "Le nom d'utilisateur est déja pris" });
            }

        }
    }
}