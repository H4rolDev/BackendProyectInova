using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Innova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clienteDireccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    departamento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    provincia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    distrito = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clienteDireccion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longitudDocumento = table.Column<int>(type: "int", nullable: false),
                    nroDocumento = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreContacto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RUC = table.Column<int>(type: "int", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefonoContacto = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recojoAlmacen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recojoAlmacen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipoPago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Trabajador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidoPaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidoMaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaInicioContrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinContrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    puesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    marca = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    precioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    garantia = table.Column<int>(type: "int", nullable: true),
                    PorcUtilidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_productos_categorias_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RSocial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_documento = table.Column<int>(type: "int", nullable: false),
                    id_clienteDireccion = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_clientes_clienteDireccion_id_clienteDireccion",
                        column: x => x.id_clienteDireccion,
                        principalTable: "clienteDireccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clientes_documentos_id_documento",
                        column: x => x.id_documento,
                        principalTable: "documentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<long>(type: "bigint", nullable: false),
                    id_direccion = table.Column<int>(type: "int", nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.id);
                    table.ForeignKey(
                        name: "FK_delivery_clienteDireccion_id_direccion",
                        column: x => x.id_direccion,
                        principalTable: "clienteDireccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_delivery_estados_id_estado",
                        column: x => x.id_estado,
                        principalTable: "estados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    metodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idTipoDocEntrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nroDocEntrada = table.Column<int>(type: "int", nullable: false),
                    id_proveedor = table.Column<int>(type: "int", nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.id);
                    table.ForeignKey(
                        name: "FK_Compra_estados_id_estado",
                        column: x => x.id_estado,
                        principalTable: "estados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_proveedores_id_proveedor",
                        column: x => x.id_proveedor,
                        principalTable: "proveedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordenServicioTecnico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trabajador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    descripcionServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_Trabajador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenServicioTecnico", x => x.id);
                    table.ForeignKey(
                        name: "FK_ordenServicioTecnico_Trabajador_id_Trabajador",
                        column: x => x.id_Trabajador,
                        principalTable: "Trabajador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordenServicioTecnico_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    clave = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    estado = table.Column<bool>(type: "bit", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_Rol_id_rol",
                        column: x => x.id_rol,
                        principalTable: "Rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalVenta = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    id_trabajador = table.Column<int>(type: "int", nullable: false),
                    id_delivery = table.Column<int>(type: "int", nullable: false),
                    id_tipoPago = table.Column<int>(type: "int", nullable: false),
                    id_recojoAlmacen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_ventas_Trabajador_id_trabajador",
                        column: x => x.id_trabajador,
                        principalTable: "Trabajador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_delivery_id_delivery",
                        column: x => x.id_delivery,
                        principalTable: "delivery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_recojoAlmacen_id_recojoAlmacen",
                        column: x => x.id_recojoAlmacen,
                        principalTable: "recojoAlmacen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_tipoPago_id_tipoPago",
                        column: x => x.id_tipoPago,
                        principalTable: "tipoPago",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalleCompra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidadComprada = table.Column<int>(type: "int", nullable: false),
                    precioCosto = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    precioVenta = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    porcentajeUtilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_compra = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleCompra", x => x.id);
                    table.ForeignKey(
                        name: "FK_detalleCompra_Compra_id_compra",
                        column: x => x.id_compra,
                        principalTable: "Compra",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleCompra_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalleVenta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    preioUnitario = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    impuestos = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_venta = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleVenta", x => x.id);
                    table.ForeignKey(
                        name: "FK_detalleVenta_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleVenta_ventas_id_venta",
                        column: x => x.id_venta,
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Compra_id_estado",
                table: "Compra",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_id_proveedor",
                table: "Compra",
                column: "id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_id_direccion",
                table: "delivery",
                column: "id_direccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_delivery_id_estado",
                table: "delivery",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_detalleCompra_id_compra",
                table: "detalleCompra",
                column: "id_compra");

            migrationBuilder.CreateIndex(
                name: "IX_detalleCompra_id_producto",
                table: "detalleCompra",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_id_producto",
                table: "detalleVenta",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_id_venta",
                table: "detalleVenta",
                column: "id_venta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ordenServicioTecnico_id_cliente",
                table: "ordenServicioTecnico",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ordenServicioTecnico_id_Trabajador",
                table: "ordenServicioTecnico",
                column: "id_Trabajador");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_categoria",
                table: "productos",
                column: "id_categoria");

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
                name: "IX_ventas_id_cliente",
                table: "ventas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_delivery",
                table: "ventas",
                column: "id_delivery",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_recojoAlmacen",
                table: "ventas",
                column: "id_recojoAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_tipoPago",
                table: "ventas",
                column: "id_tipoPago",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_trabajador",
                table: "ventas",
                column: "id_trabajador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleCompra");

            migrationBuilder.DropTable(
                name: "detalleVenta");

            migrationBuilder.DropTable(
                name: "ordenServicioTecnico");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "Trabajador");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropTable(
                name: "recojoAlmacen");

            migrationBuilder.DropTable(
                name: "tipoPago");

            migrationBuilder.DropTable(
                name: "documentos");

            migrationBuilder.DropTable(
                name: "clienteDireccion");

            migrationBuilder.DropTable(
                name: "estados");
        }
    }
}
