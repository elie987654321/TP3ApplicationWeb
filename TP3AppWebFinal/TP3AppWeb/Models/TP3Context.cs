
using Microsoft.EntityFrameworkCore;
using static TP3AppWeb.Models.Evaluation;
using static TP3AppWeb.Models.Jeu;
using static TP3AppWeb.Models.Utilisateur;


namespace TP3AppWeb.Models
{
    public class TP3Context : DbContext
    {
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Jeu> Jeux { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TP3;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluation>().ToTable("Evaluation");
            modelBuilder.Entity<Jeu>().ToTable("Jeu");
            modelBuilder.Entity<Jeu>().HasKey(j => new { j.EvaluationID });
            modelBuilder.Entity<Utilisateur>().ToTable("Utilisateur");

            modelBuilder.Entity<Evaluation>().HasData(
                new Evaluation { EvaluationID = 1, Cote = CoteDeJeu.EXCELLENT, Description = "Hogwarts Legacy : L'Héritage de Poudlard est un RPG d'action-aventure immersif en monde ouvert. Vous pouvez prendre le contrôle et vous retrouver au centre de votre propre aventure dans le Monde des sorciers." },
                new Evaluation { EvaluationID = 2, Cote = CoteDeJeu.TRES_BON, Description = "Le shooter-looter est de retour avec ses trilliards de flingues pour une aventure complètement folle ! Affrontez de nouveaux mondes et ennemis dans la peau de l'un des quatre Chasseurs de l'Arche proposés, avec chacun ses propres compétences et options de personnalisation." },
                new Evaluation { EvaluationID = 3, Cote = CoteDeJeu.EXCELLENT, Description = "Vous avez hérité de l’ancienne parcelle de ferme de votre grand-père à Stardew Valley. Armé d’outils à la main et de quelques pièces de monnaie, vous avez entrepris de commencer votre nouvelle vie. Pouvez-vous apprendre à vivre de la terre et à transformer ces champs envahis par la végétation en une habitation prospère?" },
                new Evaluation { EvaluationID = 4, Cote = CoteDeJeu.EXCELLENT, Description = "Un jeu multijoueur brutal d'exploration et de survie pour 1 à 10 joueurs, prenant place dans un purgatoire en génération procédurale inspiré par la culture viking. Combattez, bâtissez et accomplissez des exploits à la gloire d'Odin!" },
                new Evaluation { EvaluationID = 5, Cote = CoteDeJeu.TRES_BON, Description = "Dans un monde dystopique aussi déjanté que sublime, armez-vous de votre gant de pouvoirs, de votre arsenal d’armes blanches et de votre artillerie à la pointe de la technologie, et lancez-vous dans des affrontements explosifs et mortellement nerveux." },
                new Evaluation { EvaluationID = 6, Cote = CoteDeJeu.TRES_BON, Description = "BRISEZ LE CYCLE Combattez pour votre survie dans ce jeu de tir à la troisième personne récompensé qui apporte l'histoire de Selene. Affrontez les défis du genre roguelike. Faites face à vos ennemis dans un déluge de balles. Voyagez dans Returnal™ avec un autre joueur." },
                new Evaluation { EvaluationID = 7, Cote = CoteDeJeu.TRES_BON, Description = "Civilization VI est le dernier épisode de la franchise éponyme, récompensée de nombreuses fois. Repoussez les frontières de votre empire, développez votre patrimoine culturel et affrontez les plus grands seigneurs de l'histoire. Votre civilisation tiendra-t-elle face aux ravages du temps ?" },
                new Evaluation { EvaluationID = 8, Cote = CoteDeJeu.MOYEN, Description = "Soyez à la hauteur de ce qu’on attend de vous dans NBA 2K23. Le mode scénario permet de suivre votre joueur, qui sera surnommé MP, tout au long de sa carrière de basketball." },
                new Evaluation { EvaluationID = 9, Cote = CoteDeJeu.TRES_BON, Description = "Grand Theft Auto V offre aux joueurs la possibilité d'explorer le monde de Los Santos et Blaine County et ses crimes." },
                new Evaluation { EvaluationID = 10, Cote = CoteDeJeu.EXCELLENT, Description = "Survie et épouvante atteignent des sommets dans le 8e titre de la franchise Resident Evil : Resident Evil Village. Graphismes ultra-détaillés, action intense en vue subjective et récit palpitant : la peur n'a jamais été aussi palpable." }
                );

            modelBuilder.Entity<Jeu>().HasData(
                new Jeu { JeuID = 1, EvaluationID = 1, NomDuJeu = "Hogwarts Legacy : L'Héritage de Poudlard", TypeDeJeu = TypeJeu.Monde_Ouvert, DateProduction = new DateTime(2023, 02, 10), Duree = "Environ 35 heures", Auteur = "Warner Bros. Games", Producteur = "Avalanche Software", Extrait = "https://www.youtube.com/embed/M8ApyJqnME0", Complet = "https://store.steampowered.com/app/990080/Hogwarts_Legacy_LHritage_de_Poudlard/?l=french", Image = "https://w0.peakpx.com/wallpaper/461/931/HD-wallpaper-hogwarts-legacy-poster.jpg" },
                new Jeu { JeuID = 2, EvaluationID = 2, NomDuJeu = "Borderlands 3", TypeDeJeu = TypeJeu.FPS, DateProduction = new DateTime(2020, 03, 13), Duree = "Environ 35 heures", Auteur = "2K", Producteur = "Gearbox Software", Extrait = "https://www.youtube.com/embed/zW8rXQnKirE", Complet = "https://store.steampowered.com/app/397540/Borderlands_3/", Image = "https://images5.alphacoders.com/100/thumb-1920-1004495.jpg" },
                new Jeu { JeuID = 3, EvaluationID = 3, NomDuJeu = "Stardew Valley", TypeDeJeu = TypeJeu.Simulation_De_Ferme, DateProduction = new DateTime(2016, 02, 21), Duree = "Environ 52 heures", Auteur = "ConcernedApe", Producteur = "ConcernedApe", Extrait = "https://www.youtube.com/embed/ot7uXNQskhs", Complet = "https://store.steampowered.com/app/413150/Stardew_Valley/", Image = "https://www.researchgate.net/publication/342704239/figure/fig1/AS:960471637192707@1606005691630/Stardew-Valley-promotional-image-Sourcewwwstardewvalleynet-Image-copyright-Eric-Barone.jpg" },
                new Jeu { JeuID = 4, EvaluationID = 4, NomDuJeu = "Valheim", TypeDeJeu = TypeJeu.Survie, DateProduction = new DateTime(2021, 02, 02), Duree = "Environ 75 heures", Auteur = "Coffee Stain Publishing", Producteur = "Iron Gate AB", Extrait = "https://www.youtube.com/embed/liQLtCLq3tc", Complet = "https://store.steampowered.com/app/892970/Valheim/", Image = "https://preview.redd.it/cb6vhjj30ap61.gif?format=png8&s=7fede5f0fb30bd3aa14dfdb16eb56e8e8412dedc" },
                new Jeu { JeuID = 5, EvaluationID = 5, NomDuJeu = "Atomic Heart", TypeDeJeu = TypeJeu.Horreur, DateProduction = new DateTime(2023, 02, 20), Duree = "Environ 25 heures", Auteur = "Focus Entertainment", Producteur = "Mundfish", Extrait = "https://www.youtube.com/embed/h8F4hnR1FoE", Complet = "https://store.steampowered.com/app/668580/Atomic_Heart/", Image = "https://news.xbox.com/en-us/wp-content/uploads/sites/2/2022/12/ATOMIC-_HEART_Store_Featured_JPG-af8c6994d37e4bfb590d.jpg" },
                new Jeu { JeuID = 6, EvaluationID = 6, NomDuJeu = "Returnal", TypeDeJeu = TypeJeu.Roguelike, DateProduction = new DateTime(2023, 02, 15), Duree = "Environ 19 heures", Auteur = "PlayStation PC LLC", Producteur = "Housemarque", Extrait = "https://www.youtube.com/embed/BcnRCjHViLw", Complet = "https://store.steampowered.com/app/1649240/Returnal/", Image = "https://images.alphacoders.com/113/thumb-1920-1137684.jpg" },
                new Jeu { JeuID = 7, EvaluationID = 7, NomDuJeu = "Sid Meier’s Civilization VI", TypeDeJeu = TypeJeu.Strategie, DateProduction = new DateTime(2016, 10, 21), Duree = "Environ 22 heures", Auteur = "2K", Producteur = "Firaxis Games", Extrait = "https://www.youtube.com/embed/5KdE0p2joJw", Complet = "https://store.steampowered.com/app/289070/Sid_Meiers_Civilization_VI/", Image = "https://i0.wp.com/mynintendonews.com/wp-content/uploads/2018/09/civilization_vi.jpg?fit=1500%2C1000&ssl=1" },
                new Jeu { JeuID = 8, EvaluationID = 8, NomDuJeu = "NBA 2K23", TypeDeJeu = TypeJeu.Sport, DateProduction = new DateTime(2022, 09, 08), Duree = "Environ 12 heures", Auteur = "2K", Producteur = "Visual Concepts", Extrait = "https://www.youtube.com/embed/vE_oLyx25IU", Complet = "https://store.steampowered.com/app/1919590/NBA_2K23/", Image = "https://nba2kw.com/wp-content/uploads/2022/06/nba-2k23-cover-athlete-devin-booker-standard-edition.jpg" },
                new Jeu { JeuID = 9, EvaluationID = 9, NomDuJeu = "Grand Theft Auto V", TypeDeJeu = TypeJeu.Crime, DateProduction = new DateTime(2015, 04, 14), Duree = "Environ 31 heures", Auteur = "Rockstar Games", Producteur = "Rockstar North", Extrait = "https://www.youtube.com/embed/0hNYgYXhWkM", Complet = "https://store.steampowered.com/app/271590/Grand_Theft_Auto_V/", Image = "https://media.rockstargames.com/rockstargames/img/global/news/upload/actual_1364906194.jpg" },
                new Jeu { JeuID = 10, EvaluationID = 10, NomDuJeu = "Resident Evil Village", TypeDeJeu = TypeJeu.Horreur, DateProduction = new DateTime(2021, 05, 07), Duree = "Environ 9 heures", Auteur = "CAPCOM Co., Ltd.", Producteur = "CAPCOM Co., Ltd.", Extrait = "https://www.youtube.com/embed/tjfTxFzGh3Q", Complet = "https://store.steampowered.com/app/1196590/Resident_Evil_Village/", Image = "https://www.residentevil.com/village/assets/images/common/share.png" }
                );

            modelBuilder.Entity<Utilisateur>().HasData(
                new Utilisateur { UtilisateurID = 1, IdentifiantUnique = "bob123", Pseudo = "Bobby", MotDePasse = "secret", Nom = "Bobob", Prenom = "Bob", Role = RoleDUtilisateur.Admin },
                new Utilisateur { UtilisateurID = 2, IdentifiantUnique = "gerry321", Pseudo = "Muffin", MotDePasse = "mdp123", Nom = "Tremblay", Prenom = "George" },
                new Utilisateur { UtilisateurID = 3, IdentifiantUnique = "joejoe546", Pseudo = "Joejoe", MotDePasse = "Soleil01", Nom = "Jean", Prenom = "Joe" }
                );

            // Favoris de Bob
            modelBuilder.Entity<Jeu>()
                .HasMany(jeu => jeu.Utilisateurs)
                .WithMany(jeu => jeu.Favoris)
                .UsingEntity(jeu => jeu.HasData(
                    new
                    {
                        JeuID = 10,
                        UtilisateursUtilisateurID = 1,
                        FavorisEvaluationID = 10
                    },
                    new
                    {
                        JeuID = 2,
                        UtilisateursUtilisateurID = 1,
                        FavorisEvaluationID = 2
                    },
                    new
                    {
                        JeuID = 8,
                        UtilisateursUtilisateurID = 1,
                        FavorisEvaluationID = 8
                    }
                )
            );

            // Favoris de George
            modelBuilder.Entity<Jeu>()
                .HasMany(jeu => jeu.Utilisateurs)
                .WithMany(jeu => jeu.Favoris)
                .UsingEntity(jeu => jeu.HasData(
                    new
                    {
                        JeuID = 10,
                        UtilisateursUtilisateurID = 2,
                        FavorisEvaluationID = 10
                    },
                    new
                    {
                        JeuID = 3,
                        UtilisateursUtilisateurID = 2,
                        FavorisEvaluationID = 3
                    },
                    new
                    {
                        JeuID = 1,
                        UtilisateursUtilisateurID = 2,
                        FavorisEvaluationID = 1
                    }
                )
            );

            // Favoris de Joe
            modelBuilder.Entity<Jeu>()
                .HasMany(jeu => jeu.Utilisateurs)
                .WithMany(jeu => jeu.Favoris)
                .UsingEntity(jeu => jeu.HasData(
                    new
                    {
                        JeuID = 4,
                        UtilisateursUtilisateurID = 3,
                        FavorisEvaluationID = 4
                    },
                    new
                    {
                        JeuID = 1,
                        UtilisateursUtilisateurID = 3,
                        FavorisEvaluationID = 1
                    },
                    new
                    {
                        JeuID = 6,
                        UtilisateursUtilisateurID = 3,
                        FavorisEvaluationID = 6
                    }
                )
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
