using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Innova100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientes_clienteDireccion_id_clienteDireccion",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_clientes_documentos_id_documento",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Rol_id_rol",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_clientes_id_cliente",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_id_cliente",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_id_rol",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_clientes_id_clienteDireccion",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "IX_clientes_id_documento",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "id_clienteDireccion",
                table: "clientes");

            migrationBuilder.RenameColumn(
                name: "id_documento",
                table: "clientes",
                newName: "documento");

            migrationBuilder.AlterColumn<int>(
                name: "telefono",
                table: "clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "direccion",
                table: "clientes");

            migrationBuilder.RenameColumn(
                name: "documento",
                table: "clientes",
                newName: "id_documento");

            migrationBuilder.AlterColumn<string>(
                name: "telefono",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "id_clienteDireccion",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_id_cliente",
                table: "users",
                column: "id_cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_id_rol",
                table: "users",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_id_clienteDireccion",
                table: "clientes",
                column: "id_clienteDireccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_id_documento",
                table: "clientes",
                column: "id_documento",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_clienteDireccion_id_clienteDireccion",
                table: "clientes",
                column: "id_clienteDireccion",
                principalTable: "clienteDireccion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_documentos_id_documento",
                table: "clientes",
                column: "id_documento",
                principalTable: "documentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Rol_id_rol",
                table: "users",
                column: "id_rol",
                principalTable: "Rol",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_clientes_id_cliente",
                table: "users",
                column: "id_cliente",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
