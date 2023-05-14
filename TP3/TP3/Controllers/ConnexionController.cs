using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TP3.Models;
using Newtonsoft.Json;

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
                trouve = u.UtilisateurID == nomUtilisateur && u.MotDePasse == motDePasse;
                i++;
            }
            while (!trouve && i < listeUtilisateurs.Count);
            
           

            if (trouve != null)
            {
                this.HttpContext.Session.SetString("Utilisateur", u.UtilisateurID);
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

           
            if (identifiantUnique == null || identifiantUnique == "")
            {
                return RedirectToAction("Accueil", "CreerCompte");
            }

            //Verifie qu'un pseudo valide a été entrer
            if (pseudo == null || pseudo == "")
            {
                return RedirectToAction("Accueil", "CreerCompte");
            }


            //Verifie qu'un mot de passe valide a été entrée
            if (password == null || password == "")
            {
                return RedirectToAction("Accueil", "CreerCompte");
            }


            if (prenom == null || prenom == "")
            {
                return RedirectToAction("Accueil", "CreerCompte");
            }

            if (nom == null || nom == "")
            {
                return RedirectToAction("Accueil", "CreerCompte");
            }



            if (_context.utilisateurs.Count() > 0)
            {

                List<Utilisateur> listeUtilisateurs = _context.utilisateurs.ToList() ;


                //Verifie si le nom d'utilisateur existe deja
                bool trouve = false;
                int i = 0;
                Utilisateur utilisateurATester;


                do
                {
                    utilisateurATester = listeUtilisateurs[i];
                    trouve = utilisateurATester.UtilisateurID == identifiantUnique;
                    i++;
                }
                while (!trouve && i < listeUtilisateurs.Count - 1);
                if (trouve)
                {
                    return RedirectToAction("Accueil", "CreerCompte");
                }
            }


            //Ajout de l'utilisateur
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.UtilisateurID = identifiantUnique;
            utilisateur.Pseudo = pseudo;
            utilisateur.MotDePasse = password;
            utilisateur.Prenom = prenom;
            utilisateur.Nom = nom;

            _context.utilisateurs.Add(utilisateur);
            _context.SaveChanges();

            this.HttpContext.Session.SetString("Utilisateur", JsonConvert.SerializeObject(utilisateur));

            return RedirectToAction("Accueil", "Home");
        }
    }
}
