using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMorfar_MVC.Migrations
{
    /// <inheritdoc />
    public partial class secambialanomenclaturadelosatributosid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Personas",
                newName: "PersonaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pedidos",
                newName: "PedidoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comandas",
                newName: "ComandaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Personas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "Pedidos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ComandaId",
                table: "Comandas",
                newName: "Id");
        }
    }
}
