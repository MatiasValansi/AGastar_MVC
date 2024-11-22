using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMorfar_MVC.Migrations
{
    /// <inheritdoc />
    public partial class noseeliminanpedidossedesactivan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activo",
                table: "Pedidos");
        }
    }
}
