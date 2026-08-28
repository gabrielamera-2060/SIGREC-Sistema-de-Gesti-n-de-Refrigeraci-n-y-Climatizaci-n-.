using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Migrations
{
    public partial class AgregarHistorialCorreos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialCorreos",
                columns: table => new
                {
                    Id = table.Column<int>(
                        type: "int",
                        nullable: false)
                        .Annotation(
                            "SqlServer:Identity",
                            "1, 1"),

                    ClienteId = table.Column<int>(
                        type: "int",
                        nullable: false),

                    CorreoDestino = table.Column<string>(
                        type: "nvarchar(150)",
                        maxLength: 150,
                        nullable: false),

                    Asunto = table.Column<string>(
                        type: "nvarchar(250)",
                        maxLength: 250,
                        nullable: false),

                    Mensaje = table.Column<string>(
                        type: "nvarchar(2000)",
                        maxLength: 2000,
                        nullable: false),

                    Fecha = table.Column<DateTime>(
                        type: "datetime2",
                        nullable: false),

                    Estado = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_HistorialCorreos",
                        x => x.Id);

                    table.ForeignKey(
                        name: "FK_HistorialCorreos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCorreos_ClienteId",
                table: "HistorialCorreos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialCorreos");
        }
    }
}