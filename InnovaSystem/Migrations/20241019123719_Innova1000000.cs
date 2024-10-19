using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Innova1000000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_categorias_id_categoria",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_productos_id_categoria",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "PorcUtilidad",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "id_categoria",
                table: "productos");

            migrationBuilder.AlterColumn<int>(
                name: "garantia",
                table: "productos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "categoria",
                table: "productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "utilidadPorcentaje",
                table: "productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "utilidadPrecioVenta",
                table: "productos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoria",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "utilidadPorcentaje",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "utilidadPrecioVenta",
                table: "productos");

            migrationBuilder.AlterColumn<int>(
                name: "garantia",
                table: "productos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PorcUtilidad",
                table: "productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_categoria",
                table: "productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_categoria",
                table: "productos",
                column: "id_categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_categorias_id_categoria",
                table: "productos",
                column: "id_categoria",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
