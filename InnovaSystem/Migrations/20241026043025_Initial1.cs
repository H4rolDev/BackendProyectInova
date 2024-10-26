using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "correo",
                table: "persona",
                newName: "tipo_documento");

            migrationBuilder.RenameColumn(
                name: "apellidoPaterno",
                table: "persona",
                newName: "numero_documento");

            migrationBuilder.RenameColumn(
                name: "apellidoMaterno",
                table: "persona",
                newName: "apellidos");

            migrationBuilder.UpdateData(
                table: "persona",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "apellidos", "numero_documento", "telefono", "tipo_documento" },
                values: new object[] { "Pérez", "12345678", "987654321", "DNI" });

            migrationBuilder.UpdateData(
                table: "persona",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "apellidos", "nombres", "numero_documento", "telefono", "tipo_documento" },
                values: new object[] { "González", "María", "87654321", "912345678", "DNI" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipo_documento",
                table: "persona",
                newName: "correo");

            migrationBuilder.RenameColumn(
                name: "numero_documento",
                table: "persona",
                newName: "apellidoPaterno");

            migrationBuilder.RenameColumn(
                name: "apellidos",
                table: "persona",
                newName: "apellidoMaterno");

            migrationBuilder.UpdateData(
                table: "persona",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "apellidoMaterno", "apellidoPaterno", "correo", "telefono" },
                values: new object[] { "Lopez", "Perez", "juan.perez@example.com", "123456789" });

            migrationBuilder.UpdateData(
                table: "persona",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "apellidoMaterno", "apellidoPaterno", "correo", "nombres", "telefono" },
                values: new object[] { "Diaz", "Gomez", "maria.gomez@example.com", "Maria", "987654321" });
        }
    }
}
