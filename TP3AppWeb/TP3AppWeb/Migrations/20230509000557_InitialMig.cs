using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3AppWeb.Migrations
{
    public partial class InitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false),
                    Cote = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.EvaluationID);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    UtilisateurID = table.Column<int>(type: "int", nullable: false),
                    IdentifiantUnique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.UtilisateurID);
                });

            migrationBuilder.CreateTable(
                name: "Jeu",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false),
                    JeuID = table.Column<int>(type: "int", nullable: false),
                    NomDuJeu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDeJeu = table.Column<int>(type: "int", nullable: false),
                    DateProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extrait = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilisateurID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeu", x => x.EvaluationID);
                    table.ForeignKey(
                        name: "FK_Jeu_Evaluation_EvaluationID",
                        column: x => x.EvaluationID,
                        principalTable: "Evaluation",
                        principalColumn: "EvaluationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jeu_Utilisateur_UtilisateurID",
                        column: x => x.UtilisateurID,
                        principalTable: "Utilisateur",
                        principalColumn: "UtilisateurID");
                });

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationID", "Cote", "Description" },
                values: new object[,]
                {
                    { 1, 5, "Hogwarts Legacy : L'Héritage de Poudlard est un RPG d'action-aventure immersif en monde ouvert. Vous pouvez prendre le contrôle et vous retrouver au centre de votre propre aventure dans le Monde des sorciers." },
                    { 2, 4, "Le shooter-looter est de retour avec ses trilliards de flingues pour une aventure complètement folle ! Affrontez de nouveaux mondes et ennemis dans la peau de l'un des quatre Chasseurs de l'Arche proposés, avec chacun ses propres compétences et options de personnalisation." },
                    { 3, 5, "Vous avez hérité de l’ancienne parcelle de ferme de votre grand-père à Stardew Valley. Armé d’outils à la main et de quelques pièces de monnaie, vous avez entrepris de commencer votre nouvelle vie. Pouvez-vous apprendre à vivre de la terre et à transformer ces champs envahis par la végétation en une habitation prospère?" },
                    { 4, 5, "Un jeu multijoueur brutal d'exploration et de survie pour 1 à 10 joueurs, prenant place dans un purgatoire en génération procédurale inspiré par la culture viking. Combattez, bâtissez et accomplissez des exploits à la gloire d'Odin!" },
                    { 5, 4, "Dans un monde dystopique aussi déjanté que sublime, armez-vous de votre gant de pouvoirs, de votre arsenal d’armes blanches et de votre artillerie à la pointe de la technologie, et lancez-vous dans des affrontements explosifs et mortellement nerveux." },
                    { 6, 4, "BRISEZ LE CYCLE Combattez pour votre survie dans ce jeu de tir à la troisième personne récompensé qui apporte l'histoire de Selene. Affrontez les défis du genre roguelike. Faites face à vos ennemis dans un déluge de balles. Voyagez dans Returnal™ avec un autre joueur." },
                    { 7, 4, "Civilization VI est le dernier épisode de la franchise éponyme, récompensée de nombreuses fois. Repoussez les frontières de votre empire, développez votre patrimoine culturel et affrontez les plus grands seigneurs de l'histoire. Votre civilisation tiendra-t-elle face aux ravages du temps ?" },
                    { 8, 2, "Soyez à la hauteur de ce qu’on attend de vous dans NBA 2K23. Le mode scénario permet de suivre votre joueur, qui sera surnommé MP, tout au long de sa carrière de basketball." },
                    { 9, 4, "Grand Theft Auto V offre aux joueurs la possibilité d'explorer le monde de Los Santos et Blaine County et ses crimes." },
                    { 10, 5, "Survie et épouvante atteignent des sommets dans le 8e titre de la franchise Resident Evil : Resident Evil Village. Graphismes ultra-détaillés, action intense en vue subjective et récit palpitant : la peur n'a jamais été aussi palpable." }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "UtilisateurID", "IdentifiantUnique", "MotDePasse", "Nom", "Prenom", "Pseudo", "Role" },
                values: new object[,]
                {
                    { 1, "bob123", "secret", "Bobob", "Bob", "Bobby", 2 },
                    { 2, "gerry321", "mdp123", "Tremblay", "George", "Muffin", 1 },
                    { 3, "Joejoe546", "Soleil01", "Jean", "Joe", "Joejoe", 1 }
                });

            migrationBuilder.InsertData(
                table: "Jeu",
                columns: new[] { "EvaluationID", "Auteur", "Complet", "DateProduction", "Duree", "Extrait", "Image", "JeuID", "NomDuJeu", "Producteur", "TypeDeJeu", "UtilisateurID" },
                values: new object[,]
                {
                    { 1, "Warner Bros. Games", "https://store.steampowered.com/app/990080/Hogwarts_Legacy_LHritage_de_Poudlard/?l=french", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 35 heures", "https://www.youtube.com/embed/M8ApyJqnME0", "https://w0.peakpx.com/wallpaper/461/931/HD-wallpaper-hogwarts-legacy-poster.jpg", 1, "Hogwarts Legacy : L'Héritage de Poudlard", "Avalanche Software", 0, null },
                    { 2, "2K", "https://store.steampowered.com/app/397540/Borderlands_3/", new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 35 heures", "https://www.youtube.com/embed/zW8rXQnKirE", "https://images5.alphacoders.com/100/thumb-1920-1004495.jpg", 2, "Borderlands 3", "Gearbox Software", 1, null },
                    { 3, "ConcernedApe", "https://store.steampowered.com/app/413150/Stardew_Valley/", new DateTime(2016, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 52 heures", "https://www.youtube.com/embed/ot7uXNQskhs", "https://www.researchgate.net/publication/342704239/figure/fig1/AS:960471637192707@1606005691630/Stardew-Valley-promotional-image-Sourcewwwstardewvalleynet-Image-copyright-Eric-Barone.jpg", 3, "Stardew Valley", "ConcernedApe", 2, null },
                    { 4, "Coffee Stain Publishing", "https://store.steampowered.com/app/892970/Valheim/", new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 75 heures", "https://www.youtube.com/embed/liQLtCLq3tc", "https://preview.redd.it/cb6vhjj30ap61.gif?format=png8&s=7fede5f0fb30bd3aa14dfdb16eb56e8e8412dedc", 4, "Valheim", "Iron Gate AB", 3, null },
                    { 5, "Focus Entertainment", "https://store.steampowered.com/app/668580/Atomic_Heart/", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 25 heures", "https://www.youtube.com/embed/h8F4hnR1FoE", "https://news.xbox.com/en-us/wp-content/uploads/sites/2/2022/12/ATOMIC-_HEART_Store_Featured_JPG-af8c6994d37e4bfb590d.jpg", 5, "Atomic Heart", "Mundfish", 4, null },
                    { 6, "PlayStation PC LLC", "https://store.steampowered.com/app/1649240/Returnal/", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 19 heures", "https://www.youtube.com/embed/BcnRCjHViLw", "https://images.alphacoders.com/113/thumb-1920-1137684.jpg", 6, "Returnal", "Housemarque", 5, null },
                    { 7, "2K", "https://store.steampowered.com/app/289070/Sid_Meiers_Civilization_VI/", new DateTime(2016, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 22 heures", "https://www.youtube.com/embed/5KdE0p2joJw", "https://i0.wp.com/mynintendonews.com/wp-content/uploads/2018/09/civilization_vi.jpg?fit=1500%2C1000&ssl=1", 7, "Sid Meier’s Civilization VI", "Firaxis Games", 6, null },
                    { 8, "2K", "https://store.steampowered.com/app/1919590/NBA_2K23/", new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 12 heures", "https://www.youtube.com/embed/vE_oLyx25IU", "https://nba2kw.com/wp-content/uploads/2022/06/nba-2k23-cover-athlete-devin-booker-standard-edition.jpg", 8, "NBA 2K23", "Visual Concepts", 7, null },
                    { 9, "Rockstar Games", "https://store.steampowered.com/app/271590/Grand_Theft_Auto_V/", new DateTime(2015, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 31 heures", "https://www.youtube.com/embed/0hNYgYXhWkM", "https://media.rockstargames.com/rockstargames/img/global/news/upload/actual_1364906194.jpg", 9, "Grand Theft Auto V", "Rockstar North", 8, null },
                    { 10, "CAPCOM Co., Ltd.", "https://store.steampowered.com/app/1196590/Resident_Evil_Village/", new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environ 9 heures", "https://www.youtube.com/embed/tjfTxFzGh3Q", "https://www.residentevil.com/village/assets/images/common/share.png", 10, "Resident Evil Village", "CAPCOM Co., Ltd.", 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_UtilisateurID",
                table: "Jeu",
                column: "UtilisateurID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jeu");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
