using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Apartament.Migrations
{
    public partial class Categorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieApartament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartamentID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieApartament", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieApartament_Apartament_ApartamentID",
                        column: x => x.ApartamentID,
                        principalTable: "Apartament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieApartament_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieApartament_ApartamentID",
                table: "CategorieApartament",
                column: "ApartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieApartament_CategorieID",
                table: "CategorieApartament",
                column: "CategorieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieApartament");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
