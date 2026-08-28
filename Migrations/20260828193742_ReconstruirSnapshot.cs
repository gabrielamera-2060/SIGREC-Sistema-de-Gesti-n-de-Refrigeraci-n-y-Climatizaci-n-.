using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Migrations
{
    /// <inheritdoc />
    public partial class ReconstruirSnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // =====================================================
            // RECONSTRUCCIÓN DEL SNAPSHOT
            //
            // Las tablas ya existen en PROYECTO_SIGREC.
            // Por eso NO se vuelven a crear.
            //
            // Únicamente actualizamos Correo para permitir NULL.
            // =====================================================

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Clientes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // =====================================================
            // REVERSIÓN
            // Devuelve Correo a NOT NULL
            // =====================================================

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Clientes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}