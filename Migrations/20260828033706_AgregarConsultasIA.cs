using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Migrations
{
    /// <inheritdoc />
    public partial class AgregarConsultasIA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultasIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Respuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasIA", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasIA_Pregunta",
                table: "ConsultasIA",
                column: "Pregunta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasIA");
        }
    }
}
