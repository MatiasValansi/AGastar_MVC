using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMorfar_MVC.Migrations
{
    /// <inheritdoc />
    public partial class manytomanycomandasPersonas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComandasPersonas",
                columns: table => new
                {
                    IdComanda = table.Column<int>(type: "int", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandasPersonas", x => new { x.IdPersona, x.IdComanda });
                    table.ForeignKey(
                        name: "FK_ComandasPersonas_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandasPersonas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComandasPersonas_ComandaId",
                table: "ComandasPersonas",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandasPersonas_PersonaId",
                table: "ComandasPersonas",
                column: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandasPersonas");
        }
    }
}
