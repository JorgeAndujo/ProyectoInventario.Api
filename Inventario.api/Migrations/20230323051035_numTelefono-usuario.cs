using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventario.api.Migrations
{
    /// <inheritdoc />
    public partial class numTelefonousuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroTelefono",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroTelefono",
                table: "Usuarios");
        }
    }
}
