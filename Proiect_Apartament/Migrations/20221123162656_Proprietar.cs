using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Apartament.Migrations
{
    public partial class Proprietar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proprietar",
                table: "Apartament");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Apartament",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ProprietarID",
                table: "Apartament",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Proprietar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProprietar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietar", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartament_ProprietarID",
                table: "Apartament",
                column: "ProprietarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartament_Proprietar_ProprietarID",
                table: "Apartament",
                column: "ProprietarID",
                principalTable: "Proprietar",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartament_Proprietar_ProprietarID",
                table: "Apartament");

            migrationBuilder.DropTable(
                name: "Proprietar");

            migrationBuilder.DropIndex(
                name: "IX_Apartament_ProprietarID",
                table: "Apartament");

            migrationBuilder.DropColumn(
                name: "ProprietarID",
                table: "Apartament");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Apartament",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<string>(
                name: "Proprietar",
                table: "Apartament",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
