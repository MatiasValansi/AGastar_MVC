using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMorfar_MVC.Migrations
{
    /// <inheritdoc />
    public partial class sintaxis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "activo",
                table: "Pedidos",
                newName: "Activo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "Pedidos",
                newName: "activo");
        }
    }
}
