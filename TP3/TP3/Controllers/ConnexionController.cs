using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TP2.Models;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace TP2.Controllers
{
    public class ConnexionController : Controller
    {

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
            ListeUtilisateurs listeDesUtilisateurs = new ListeUtilisateurs();
            listeDesUtilisateurs.Charger(Environment.CurrentDirectory + "/wwwroot/json/utilisateurs.json");

            Utilisateur utilisateurTrouve = listeDesUtilisateurs.Connexion(nomUtilisateur, motDePasse);

            if (utilisateurTrouve != null)
            {
                this.HttpContext.Session.SetString("Utilisateur", JsonConvert.SerializeObject(utilisateurTrouve));
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
            
            ListeUtilisateurs listeDesUtilisateurs = new ListeUtilisateurs();
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
