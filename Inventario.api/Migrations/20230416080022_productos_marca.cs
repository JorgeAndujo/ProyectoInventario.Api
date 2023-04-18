using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventario.api.Migrations
{
    /// <inheritdoc />
    public partial class productos_marca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bimbo",
                table: "Productos",
                newName: "Marca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Productos",
                newName: "Bimbo");
        }
    }
}
