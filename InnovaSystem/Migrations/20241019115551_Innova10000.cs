using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Innova10000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "categorias");

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "id", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, false, "Computadoras" },
                    { 2, false, "Laptops" },
                    { 3, false, "Auriculares" },
                    { 4, false, "Teclado" },
                    { 5, false, "Componentes" },
                    { 6, false, "Monitores" }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "id", "PorcUtilidad", "descripcion", "estado", "garantia", "id_categoria", "imagen", "marca", "modelo", "precioVenta", "stock" },
                values: new object[,]
                {
                    { 1, null, "B550M, SSD M.2 1TB, RAM 16GB", false, 2, 1, "https://www.impacto.com.pe/storage/pc/sm/171570984947559.jpg", "AMD", "Ryzen 7 5700G", 3298.80m, 10 },
                    { 2, null, "Tarjeta de Video RTX 3050, SSD M.2 1TB, RAM 16GB", false, 2, 1, "https://www.impacto.com.pe/storage/pc/md/171589130599320.jpg", "Intel", "Core I5 13400F", 2170.50m, 30 },
                    { 3, null, "Tarjeta de Video RTX 3060TI, SSD M.2 1TB, RAM 32GB", false, 2, 1, "https://www.impacto.com.pe/storage/pc/sm/171570984947559.jpg", "AMD", "Ryzen 9 5900X", 4239.99m, 10 },
                    { 4, null, "Tarjeta de Video RTX 4060, SSD M.2 1TB, RAM 32GB", false, 2, 1, "https://www.impacto.com.pe/storage/pc/sm/171570984947559.jpg", "AMD", "Ryzen 7 5700X", 4198.50m, 10 },
                    { 5, null, "Con Microfono, Control De Volumen, Almohadillas Suaves", false, 1, 3, "https://www.impacto.com.pe/storage/pc/md/171572299747960.jpg", "Logitech", "Lightspeed Rgb G733 Gaming", 538.99m, 3 },
                    { 6, null, "Inalambrico, Con Microfono, Control De Volumen, Almohadillas Suaves", false, 1, 3, "https://www.impacto.com.pe/storage/products/sm/169099476727139.jpg", "Logitech", "G Pro X Gaming", 638.99m, 3 },
                    { 7, null, "Inalambrico, Necro C/gris, Gaming Surrow 7.1, C/microfono, Entrada Jack", false, 1, 3, "https://www.impacto.com.pe/storage/products/sm/168867107289840.jpg", "Gambyte ", "Dark Templar", 128.99m, 3 },
                    { 8, null, "Inalambrico, Necro C/gris, Gaming Surrow 7.1, C/microfono, Entrada Jack", false, 1, 3, "https://www.impacto.com.pe/storage/products/sm/168867107289840.jpg", "Gambyte ", "Dark Templar", 128.99m, 3 },
                    { 9, null, "Color Negro, Gaming 5.1, Bluetooth 5.0, Con Microfono, Control De Volumen, Almohadillas Suaves", false, null, 6, "https://www.impacto.com.pe/storage/products/sm/169099387290344.jpg", "Gambyte", "Soul", 120.99m, 23 }
                });
        }
    }
}
