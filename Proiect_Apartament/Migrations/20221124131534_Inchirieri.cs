using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Apartament.Migrations
{
    public partial class Inchirieri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartament_Proprietar_ProprietarID",
                table: "Apartament");

            migrationBuilder.AlterColumn<int>(
                name: "ProprietarID",
                table: "Apartament",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartament_Proprietar_ProprietarID",
                table: "Apartament",
                column: "ProprietarID",
                principalTable: "Proprietar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartament_Proprietar_ProprietarID",
                table: "Apartament");

            migrationBuilder.AlterColumn<int>(
                name: "ProprietarID",
                table: "Apartament",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartament_Proprietar_ProprietarID",
                table: "Apartament",
                column: "ProprietarID",
                principalTable: "Proprietar",
                principalColumn: "ID");
        }
    }
}
