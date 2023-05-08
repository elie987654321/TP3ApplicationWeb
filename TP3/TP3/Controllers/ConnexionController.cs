using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TP3.Models;


namespace TP2.Controllers
{
    public class ConnexionController : Controller
    {
        private readonly BD _context = new BD();

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
        public ActionResult Connexion(string nomUtilisateur, string motDePasse)
        {
            List<Utilisateur> listeUtilisateurs = _context.utilisateurs.ToList();
            
            bool trouve = false;
            int i = 0;
            Utilisateur u;

            do
            {
                u = listeUtilisateurs[i];
                trouve = u.IDUtilisateur == nomUtilisateur && u.MotDePasse == motDePasse;
                i++;
            }
            while (!trouve && i < listeUtilisateurs.Count);
            
           

            if (trouve != null)
            {
                this.HttpContext.Session.SetString("Utilisateur", u.IDUtilisateur);
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

            List<Utilisateur> listeUtilisateurs = _context.utilisateurs.ToList();
            listeDesUtilisateurs.Charger(Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json");
            bool succes = listeDesUtilisateurs.CreerUtilisateur(identifiantUnique,pseudo, password, nom, prenom);


            if (succes)
            {
                this.HttpContext.Session.SetString("Utilisateur", JsonConvert.SerializeObject(listeDesUtilisateurs.GetUtilisateurByPseudo(pseudo)));
                return RedirectToAction("Accueil", "Home" );
            }
            
            return RedirectToAction("Accueil", "Connexion");
        }
    }
}
