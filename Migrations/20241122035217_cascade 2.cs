using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMorfar_MVC.Migrations
{
    /// <inheritdoc />
    public partial class cascade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Pedidos_PedidoActual",
                table: "Comandas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Pedidos_PedidoActual",
                table: "Personas");

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Pedidos_PedidoActual",
                table: "Comandas",
                column: "PedidoActual",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Pedidos_PedidoActual",
                table: "Personas",
                column: "PedidoActual",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Pedidos_PedidoActual",
                table: "Comandas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Pedidos_PedidoActual",
                table: "Personas");

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Pedidos_PedidoActual",
                table: "Comandas",
                column: "PedidoActual",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Pedidos_PedidoActual",
                table: "Personas",
                column: "PedidoActual",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
