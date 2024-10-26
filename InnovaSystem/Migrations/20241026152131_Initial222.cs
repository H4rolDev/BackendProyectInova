using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "utilidadPorcentaje",
                table: "productos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 1,
                column: "utilidadPorcentaje",
                value: 14);

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 2,
                column: "utilidadPorcentaje",
                value: 13);

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 3,
                column: "utilidadPorcentaje",
                value: 13);

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 4,
                column: "utilidadPorcentaje",
                value: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "utilidadPorcentaje",
                table: "productos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 1,
                column: "utilidadPorcentaje",
                value: 14.29m);

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

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 4,
                column: "utilidadPorcentaje",
                value: 15m);
        }
    }
}
