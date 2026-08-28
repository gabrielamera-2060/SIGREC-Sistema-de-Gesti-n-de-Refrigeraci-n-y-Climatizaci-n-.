using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCorreoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Clientes");
        }
    }
}
