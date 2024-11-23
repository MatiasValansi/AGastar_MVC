using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMorfar_MVC.Migrations
{
    /// <inheritdoc />
    public partial class newmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Comandas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoRelacionado",
                table: "Comandas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_PedidoId",
                table: "Comandas",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Pedidos_PedidoId",
                table: "Comandas",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Pedidos_PedidoId",
                table: "Comandas");

            migrationBuilder.DropIndex(
                name: "IX_Comandas_PedidoId",
                table: "Comandas");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Comandas");

            migrationBuilder.DropColumn(
                name: "PedidoRelacionado",
                table: "Comandas");
        }
    }
}
