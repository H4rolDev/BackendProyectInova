using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Innova10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ordenServicioTecnico_Trabajador_id_Trabajador",
                table: "ordenServicioTecnico");

            migrationBuilder.DropForeignKey(
                name: "FK_ordenServicioTecnico_clientes_id_cliente",
                table: "ordenServicioTecnico");

            migrationBuilder.DropIndex(
                name: "IX_ordenServicioTecnico_id_cliente",
                table: "ordenServicioTecnico");

            migrationBuilder.DropIndex(
                name: "IX_ordenServicioTecnico_id_Trabajador",
                table: "ordenServicioTecnico");

            migrationBuilder.DropColumn(
                name: "id_Trabajador",
                table: "ordenServicioTecnico");

            migrationBuilder.DropColumn(
                name: "id_cliente",
                table: "ordenServicioTecnico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_Trabajador",
                table: "ordenServicioTecnico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_cliente",
                table: "ordenServicioTecnico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ordenServicioTecnico_id_cliente",
                table: "ordenServicioTecnico",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ordenServicioTecnico_id_Trabajador",
                table: "ordenServicioTecnico",
                column: "id_Trabajador");

            migrationBuilder.AddForeignKey(
                name: "FK_ordenServicioTecnico_Trabajador_id_Trabajador",
                table: "ordenServicioTecnico",
                column: "id_Trabajador",
                principalTable: "Trabajador",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ordenServicioTecnico_clientes_id_cliente",
                table: "ordenServicioTecnico",
                column: "id_cliente",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
