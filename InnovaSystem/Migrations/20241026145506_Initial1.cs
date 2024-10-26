using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnovaSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
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
                name: "marca",
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
                    table.PrimaryKey("PK_marca", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero_documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.id);
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
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_direccion = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    id_marca = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    precioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    utilidadPrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    utilidadPorcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    garantia = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_productos_marca_id_marca",
                        column: x => x.id_marca,
                        principalTable: "marca",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Direccion = table.Column<int>(type: "int", nullable: false),
                    id_Persona = table.Column<int>(type: "int", nullable: false),
                    RSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_clientes_clienteDireccion_id_Direccion",
                        column: x => x.id_Direccion,
                        principalTable: "clienteDireccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clientes_persona_id_Persona",
                        column: x => x.id_Persona,
                        principalTable: "persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trabajador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Persona = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Trabajador_persona_id_Persona",
                        column: x => x.id_Persona,
                        principalTable: "persona",
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
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Persona = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
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
                        name: "FK_users_persona_id_Persona",
                        column: x => x.id_Persona,
                        principalTable: "persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordenServicioTecnico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_Trabajador = table.Column<int>(type: "int", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    descripcionServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
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
                name: "ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_trabajador = table.Column<int>(type: "int", nullable: false),
                    id_delivery = table.Column<int>(type: "int", nullable: false),
                    id_tipoPago = table.Column<int>(type: "int", nullable: false),
                    id_recojoAlmacen = table.Column<int>(type: "int", nullable: false),
                    fechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalVenta = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
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
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_venta = table.Column<int>(type: "int", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    impuestos = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
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
                table: "Cargo",
                columns: new[] { "id", "Estado", "descripcion", "nombre", "salarioBase" },
                values: new object[,]
                {
                    { 1, true, "Encargado de la empresa.", "Gerente", 4000m },
                    { 2, true, "Vende en tienda.", "Vendedor", 2000m },
                    { 3, true, "Tecnico en computacion.", "Servicio Tecnico", 2000m }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "id", "descripcion", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, "Acceso total a todas las funcionalidades.", true, "Administrador" },
                    { 2, "Acceso limitado a funcionalidades básicas.", true, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "id", "descripcion", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, "Todo tipo de computadoras, desde portátiles hasta de escritorio.", true, "Computadoras" },
                    { 2, "Accesorios y dispositivos periféricos para computadoras.", true, "Periféricos" },
                    { 3, "Componentes internos como tarjetas madre, procesadores, etc.", true, "Componentes" }
                });

            migrationBuilder.InsertData(
                table: "clienteDireccion",
                columns: new[] { "id", "departamento", "direccion", "distrito", "estado", "provincia", "referencia" },
                values: new object[,]
                {
                    { 1, "Lima", "Av. José Larco 123", "Miraflores", true, "Lima", "Frente al parque central" },
                    { 2, "Arequipa", "Jr. Tacna 456", "Arequipa", true, "Arequipa", "Cerca a la plaza de armas" },
                    { 3, "Cusco", "Av. Los Incas 789", "Cusco", true, "Cusco", "Cerca del colegio nacional" }
                });

            migrationBuilder.InsertData(
                table: "marca",
                columns: new[] { "id", "descripcion", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, "Líder en computadoras portátiles y de escritorio.", true, "HP" },
                    { 2, "Famosa por sus periféricos como teclados y mouses.", true, "Logitech" },
                    { 3, "Reconocida por sus laptops y soluciones empresariales.", true, "Dell" },
                    { 4, "Conocida por sus computadoras y componentes de alto rendimiento.", true, "Asus" },
                    { 5, "Fabricante de computadoras y tecnología innovadora.", true, "Acer" },
                    { 6, "Marca premium en periféricos para gamers.", true, "Razer" },
                    { 7, "Conocida por sus productos de software y hardware, incluyendo teclados.", true, "Microsoft" },
                    { 8, "Reconocida por su tecnología innovadora y productos de alta gama.", true, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "id", "apellidos", "estado", "nombres", "numero_documento", "tipo_documento" },
                values: new object[,]
                {
                    { 1, "Pérez", true, "Juan", "12345678", "DNI" },
                    { 2, "González", true, "María", "87654321", "DNI" }
                });

            migrationBuilder.InsertData(
                table: "Trabajador",
                columns: new[] { "id", "FechaFinContrato", "FechaInicioContrato", "apellidoMaterno", "apellidoPaterno", "estado", "id_Persona", "nombres", "puesto", "salario", "telefono" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pérez", "García", true, 1, "Juan", "Desarrollador de Software", 3000.00m, "987654321" },
                    { 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "López", "Rodríguez", true, 2, "María", "Gerente de Marketing", 5000.00m, "912345678" }
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "id", "Apellidos", "Nombres", "NumeroDocumento", "RSocial", "TipoDocumento", "correo", "estado", "id_Direccion", "id_Persona", "telefono" },
                values: new object[,]
                {
                    { 1, "Perez", "Juan", 12345678, "Cliente 1", "DNI", "juan.cliente@example.com", true, 1, 1, 123456789 },
                    { 2, "Gomez", "Maria", 87654321, null, "DNI", "maria.cliente@example.com", true, 2, 2, 987654321 }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "id", "descripcion", "estado", "garantia", "id_categoria", "id_marca", "imagen", "modelo", "nombre", "precioVenta", "stock", "utilidadPorcentaje", "utilidadPrecioVenta" },
                values: new object[,]
                {
                    { 1, "Laptop HP Pavilion con procesador Intel Core i5 y 8GB de RAM.", true, 12, 1, 1, "hp_pavilion_15.jpg", "15-eh2021nr", "HP Pavilion 15", 3500.00m, 20, 14.29m, 500.00m },
                    { 2, "Laptop Dell XPS 13 con pantalla InfinityEdge y procesador Intel Core i7.", true, 12, 1, 3, "dell_xps_13.jpg", "XPS 13 9310", "Dell XPS 13", 4500.00m, 15, 13.33m, 600.00m },
                    { 3, "Mouse inalámbrico Logitech MX Master 3 con control preciso.", true, 24, 2, 2, "logitech_mx_master_3.jpg", "MX Master 3", "Logitech MX Master 3", 150.00m, 50, 13.33m, 20.00m },
                    { 4, "Teclado mecánico Razer BlackWidow V3 con retroiluminación RGB.", true, 12, 3, 6, "razer_blackwidow_v3.jpg", "BlackWidow V3", "Razer BlackWidow V3", 200.00m, 25, 15.00m, 30.00m }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "Correo", "clave", "estado", "id_Persona", "id_rol", "salt" },
                values: new object[,]
                {
                    { 1, "juan.usuario@example.com", "123456", true, 1, 1, "randomsalt1" },
                    { 2, "maria.usuario@example.com", "123456", true, 2, 2, "randomsalt2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientes_id_Direccion",
                table: "clientes",
                column: "id_Direccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_id_Persona",
                table: "clientes",
                column: "id_Persona",
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
                name: "IX_productos_id_marca",
                table: "productos",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_id_Persona",
                table: "Trabajador",
                column: "id_Persona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_id_Persona",
                table: "users",
                column: "id_Persona",
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
                name: "Cargo");

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
                name: "estados");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "marca");

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
                name: "persona");

            migrationBuilder.DropTable(
                name: "clienteDireccion");
        }
    }
}
