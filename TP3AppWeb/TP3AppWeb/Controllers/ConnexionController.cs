
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

        public ActionResult CreerCompte()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Connexion(string identifiantUnique, string motDePasse)
        {
            Utilisateur utilisateurTrouve = null;
            string pseudo = "";
            string role = "";

            foreach (Utilisateur utilisateur in _context.Utilisateurs)
            {
                if (identifiantUnique == utilisateur.IdentifiantUnique && motDePasse == utilisateur.MotDePasse)
                {
                    utilisateurTrouve = utilisateur;
                    pseudo = utilisateur.Pseudo;
                    role = utilisateur.Role.ToString();
                    break;
                }
            }

            if (utilisateurTrouve != null)
            {
                this.HttpContext.Session.SetString("IdentifiantUnique", identifiantUnique);
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

            foreach (Utilisateur utilisateur in _context.Utilisateurs)
            {
                if (identifiantUnique == utilisateur.IdentifiantUnique)
                {
                    compteExistant = true;
                    break;
                }
            }


            if (!compteExistant)
            {
                Utilisateur utilisateur = new Utilisateur();

                utilisateur.IdentifiantUnique = identifiantUnique;
                utilisateur.Pseudo = pseudo;
                utilisateur.MotDePasse = password;
                utilisateur.Nom = nom;
                utilisateur.Prenom = prenom;

                using (var db = new TP3Context())
                {
                    db.Utilisateurs.Add(utilisateur);
                    db.SaveChanges();
                }

                this.HttpContext.Session.SetString("IdentifiantUnique", identifiantUnique);
                this.HttpContext.Session.SetString("Pseudo", pseudo);

                return RedirectToAction("Accueil", "Home");
            }
            else
            {
                return RedirectToAction("Accueil", "Connexion");
            }

           
        }
    }
}
