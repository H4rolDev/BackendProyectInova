﻿// <auto-generated />
using System;
using InnovaSystemData.Sources.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InnovaSystem.Migrations
{
    [DbContext(typeof(InnovaDbContext))]
    [Migration("20241019115551_Innova10000")]
    partial class Innova10000
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.CategoriaTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.ClienteDireccionTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("departamento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("distrito")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("provincia")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("referencia")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("id");

                    b.ToTable("clienteDireccion");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.ClienteTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("documento")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.CompraTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("idTipoDocEntrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_estado")
                        .HasColumnType("int");

                    b.Property<int>("id_proveedor")
                        .HasColumnType("int");

                    b.Property<string>("metodoPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nroDocEntrada")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_estado");

                    b.HasIndex("id_proveedor");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.DeliveryTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("id_direccion")
                        .HasColumnType("int");

                    b.Property<int>("id_estado")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_direccion")
                        .IsUnique();

                    b.HasIndex("id_estado");

                    b.ToTable("delivery");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.DetalleCompraTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cantidadComprada")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_compra")
                        .HasColumnType("int");

                    b.Property<int>("id_producto")
                        .HasColumnType("int");

                    b.Property<string>("porcentajeUtilidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precioCosto")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal>("precioVenta")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("id");

                    b.HasIndex("id_compra");

                    b.HasIndex("id_producto");

                    b.ToTable("detalleCompra");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.DetalleVentaTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("id_producto")
                        .HasColumnType("int");

                    b.Property<int>("id_venta")
                        .HasColumnType("int");

                    b.Property<decimal>("impuestos")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal>("preioUnitario")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("id");

                    b.HasIndex("id_producto");

                    b.HasIndex("id_venta")
                        .IsUnique();

                    b.ToTable("detalleVenta");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.DocumentoTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("longitudDocumento")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nroDocumento")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("documentos");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.EstadoTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("estados");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.MarcaTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("marca");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.OrdenServicioTecnicoTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcionServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("horaFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("horaInicio")
                        .HasColumnType("time");

                    b.Property<decimal>("precioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("trabajador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ordenServicioTecnico");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.ProductoTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("PorcUtilidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int?>("garantia")
                        .HasColumnType("int");

                    b.Property<int>("id_categoria")
                        .HasColumnType("int");

                    b.Property<string>("imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marca")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("modelo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("precioVenta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.ProveedorTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("RSocial")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("RUC")
                        .HasColumnType("int");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombreContacto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.Property<int>("telefonoContacto")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("proveedores");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.RecojoAlmacenTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("recojoAlmacen");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.RolTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.TipoPagoTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("tipoPago");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.TrabajadorTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("FechaFinContrato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioContrato")
                        .HasColumnType("datetime2");

                    b.Property<string>("apellidoMaterno")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("apellidoPaterno")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("puesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Trabajador");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.UsuarioTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("estado")
                        .HasMaxLength(128)
                        .HasColumnType("bit");

                    b.Property<int>("id_cliente")
                        .HasColumnType("int");

                    b.Property<int>("id_rol")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.VentaTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_cliente")
                        .HasColumnType("int");

                    b.Property<int>("id_delivery")
                        .HasColumnType("int");

                    b.Property<int>("id_recojoAlmacen")
                        .HasColumnType("int");

                    b.Property<int>("id_tipoPago")
                        .HasColumnType("int");

                    b.Property<int>("id_trabajador")
                        .HasColumnType("int");

                    b.Property<decimal>("totalVenta")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("id");

                    b.HasIndex("id_cliente");

                    b.HasIndex("id_delivery")
                        .IsUnique();

                    b.HasIndex("id_recojoAlmacen");

                    b.HasIndex("id_tipoPago")
                        .IsUnique();

                    b.HasIndex("id_trabajador");

                    b.ToTable("ventas");
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.CompraTable", b =>
                {
                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.EstadoTable", null)
                        .WithMany()
                        .HasForeignKey("id_estado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.ProveedorTable", null)
                        .WithMany()
                        .HasForeignKey("id_proveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.DeliveryTable", b =>
                {
                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.ClienteDireccionTable", null)
                        .WithOne()
                        .HasForeignKey("InnovaSystemData.Sources.DataBase.Tables.DeliveryTable", "id_direccion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.EstadoTable", null)
                        .WithMany()
                        .HasForeignKey("id_estado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.DetalleCompraTable", b =>
                {
                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.CompraTable", null)
                        .WithMany()
                        .HasForeignKey("id_compra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.ProductoTable", null)
                        .WithMany()
                        .HasForeignKey("id_producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.DetalleVentaTable", b =>
                {
                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.ProductoTable", null)
                        .WithMany()
                        .HasForeignKey("id_producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.VentaTable", null)
                        .WithOne()
                        .HasForeignKey("InnovaSystemData.Sources.DataBase.Tables.DetalleVentaTable", "id_venta")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.ProductoTable", b =>
                {
                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.CategoriaTable", null)
                        .WithMany()
                        .HasForeignKey("id_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InnovaSystemData.Sources.DataBase.Tables.VentaTable", b =>
                {
                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.ClienteTable", null)
                        .WithMany()
                        .HasForeignKey("id_cliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.DeliveryTable", null)
                        .WithOne()
                        .HasForeignKey("InnovaSystemData.Sources.DataBase.Tables.VentaTable", "id_delivery")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.RecojoAlmacenTable", null)
                        .WithMany()
                        .HasForeignKey("id_recojoAlmacen")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.TipoPagoTable", null)
                        .WithOne()
                        .HasForeignKey("InnovaSystemData.Sources.DataBase.Tables.VentaTable", "id_tipoPago")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InnovaSystemData.Sources.DataBase.Tables.TrabajadorTable", null)
                        .WithMany()
                        .HasForeignKey("id_trabajador")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
