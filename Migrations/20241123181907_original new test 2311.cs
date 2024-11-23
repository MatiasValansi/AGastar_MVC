using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMorfar_MVC.Migrations
{
    /// <inheritdoc />
    public partial class originalnewtest2311 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComandasPersonas_Comandas_ComandaId",
                table: "ComandasPersonas");

            migrationBuilder.DropForeignKey(
                name: "FK_ComandasPersonas_Personas_PersonaId",
                table: "ComandasPersonas");

            migrationBuilder.DropIndex(
                name: "IX_ComandasPersonas_ComandaId",
                table: "ComandasPersonas");

            migrationBuilder.DropIndex(
                name: "IX_ComandasPersonas_PersonaId",
                table: "ComandasPersonas");

            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "ComandasPersonas");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "ComandasPersonas");

            migrationBuilder.CreateIndex(
                name: "IX_ComandasPersonas_IdComanda",
                table: "ComandasPersonas",
                column: "IdComanda");

            migrationBuilder.AddForeignKey(
                name: "FK_ComandasPersonas_Comandas_IdComanda",
                table: "ComandasPersonas",
                column: "IdComanda",
                principalTable: "Comandas",
                principalColumn: "ComandaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComandasPersonas_Personas_IdPersona",
                table: "ComandasPersonas",
                column: "IdPersona",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComandasPersonas_Comandas_IdComanda",
                table: "ComandasPersonas");

            migrationBuilder.DropForeignKey(
                name: "FK_ComandasPersonas_Personas_IdPersona",
                table: "ComandasPersonas");

            migrationBuilder.DropIndex(
                name: "IX_ComandasPersonas_IdComanda",
                table: "ComandasPersonas");

            migrationBuilder.AddColumn<int>(
                name: "ComandaId",
                table: "ComandasPersonas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "ComandasPersonas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComandasPersonas_ComandaId",
                table: "ComandasPersonas",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandasPersonas_PersonaId",
                table: "ComandasPersonas",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComandasPersonas_Comandas_ComandaId",
                table: "ComandasPersonas",
                column: "ComandaId",
                principalTable: "Comandas",
                principalColumn: "ComandaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComandasPersonas_Personas_PersonaId",
                table: "ComandasPersonas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
