using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 2,
                column: "utilidadPorcentaje",
                value: 13m);

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 3,
                column: "utilidadPorcentaje",
                value: 13m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 2,
                column: "utilidadPorcentaje",
                value: 13.33m);

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 3,
                column: "utilidadPorcentaje",
                value: 13.33m);
        }
    }
}
