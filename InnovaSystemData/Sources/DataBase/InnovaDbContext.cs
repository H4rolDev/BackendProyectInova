using InnovaSystemData.Sources.DataBase.Seeds;
using InnovaSystemData.Sources.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSystemData.Sources.DataBase
{
    public class InnovaDbContext : DbContext
    {

        public InnovaDbContext(
            DbContextOptions<InnovaDbContext> opts
        ) : base(opts)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            // Rol -> Usuario | uno a muchos
            /* modelBuilder.Entity<RolTable>()
                .HasMany<UsuarioTable>()
                .WithOne()
                .HasForeignKey(u => u.id_rol)
                .IsRequired(); */

            // EmpleadoTecnico -> OrdenServicioTecnico | uno a muchos
           /*  modelBuilder.Entity<TrabajadorTable>()
                .HasMany<OrdenServicioTecnicoTable>()
                .WithOne()
                .HasForeignKey(u => u.id_Trabajador)
                .IsRequired();  */

            // Cliente - Usuario | uno a uno
            /* modelBuilder.Entity<ClienteTable>()
                .HasOne<UsuarioTable>()
                .WithOne()
                .HasForeignKey<UsuarioTable>(u => u.id_cliente)
                .IsRequired(); */

            // Cliente -> OrdenServicioTecnico | uno a muchos
            /* modelBuilder.Entity<ClienteTable>()
                .HasMany<OrdenServicioTecnicoTable>()
                .WithOne()
                .HasForeignKey(u => u.id_cliente)
                .IsRequired(); */

            // CLiente - Documento | uno a uno
            /* modelBuilder.Entity<DocumentoTable>()
                .HasOne<ClienteTable>()
                .WithOne()
                .HasForeignKey<ClienteTable>(u => u.id_documento)
                .IsRequired(); */
            
            // Cliente -> ClienteDireccion | uno a uno
            /* modelBuilder.Entity<ClienteDireccionTable>()
                .HasOne<ClienteTable>()
                .WithOne()
                .HasForeignKey<ClienteTable>(u => u.id_clienteDireccion)
                .IsRequired(); */

            // Cliente -> Venta | uno a muchos
            modelBuilder.Entity<ClienteTable>()
                .HasMany<VentaTable>()
                .WithOne()
                .HasForeignKey(u => u.id_cliente)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Vendedor -> Venta | uno a muchos
            modelBuilder.Entity<TrabajadorTable>()
                .HasMany<VentaTable>()
                .WithOne()
                .HasForeignKey(u => u.id_trabajador)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // TipoPago -> Venta | uno a uno
            modelBuilder.Entity<TipoPagoTable>()
                .HasOne<VentaTable>()
                .WithOne()
                .HasForeignKey<VentaTable>(u => u.id_tipoPago)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // ClienteDireccion -> Delivery | uno a uno
            modelBuilder.Entity<ClienteDireccionTable>()
                .HasOne<DeliveryTable>()
                .WithOne()
                .HasForeignKey<DeliveryTable>(u => u.id_direccion)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Venta -> DetalleVenta | uno a uno
            modelBuilder.Entity<VentaTable>()
                .HasOne<DetalleVentaTable>()
                .WithOne()
                .HasForeignKey<DetalleVentaTable>(u => u.id_venta)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            // Cliente -> OrdenServicioTecnico | uno a muchos
            /* modelBuilder.Entity<ClienteTable>()
                .HasMany<OrdenServicioTecnicoTable>()
                .WithOne()
                .HasForeignKey(u => u.id_cliente)
                .IsRequired(); */
            
            // Delivery -> Venta | uno a uno
            modelBuilder.Entity<DeliveryTable>()
                .HasOne<VentaTable>()
                .WithOne()
                .HasForeignKey<VentaTable>(u => u.id_delivery)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // RecojoAlmacen -> Venta | uno a muchos
            modelBuilder.Entity<RecojoAlmacenTable>()
                .HasMany<VentaTable>()
                .WithOne()
                .HasForeignKey(u => u.id_recojoAlmacen)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Estado -> Delivery | uno a muchos
            modelBuilder.Entity<EstadoTable>()
                .HasMany<DeliveryTable>()
                .WithOne()
                .HasForeignKey(u => u.id_estado)
                .IsRequired();
            
            // Productos -> DetalleVenta | uno a muchos
            modelBuilder.Entity<ProductoTable>()
                .HasMany<DetalleVentaTable>()
                .WithOne()
                .HasForeignKey(u => u.id_producto)
                .IsRequired();

            // Estado -> Compra | uno a muchos
            modelBuilder.Entity<EstadoTable>()
                .HasMany<CompraTable>()
                .WithOne()
                .HasForeignKey(u => u.id_estado)
                .IsRequired();

            // Proveedor -> Compra | uno a muchos
            modelBuilder.Entity<ProveedorTable>()
                .HasMany<CompraTable>()
                .WithOne()
                .HasForeignKey(u => u.id_proveedor)
                .IsRequired();

            // Producto -> DetalleCompra | uno a muchos
            modelBuilder.Entity<ProductoTable>()
                .HasMany<DetalleCompraTable>()
                .WithOne()
                .HasForeignKey(u => u.id_producto)
                .IsRequired();
            
            // TipoProducto -> Producto | uno a muchos

            // Compra -> DetalleCOmpra | uno a muchos
            modelBuilder.Entity<CompraTable>()
                .HasMany<DetalleCompraTable>()
                .WithOne()
                .HasForeignKey(u => u.id_compra)
                .IsRequired();

            // TipoProducto -> Categoria | uno a muchos
            /* modelBuilder.Entity<CategoriaTable>()
                .HasMany<ProductoTable>()
                .WithOne()
                .HasForeignKey(u => u.id_categoria)
                .IsRequired(); */
        }
        public DbSet<CategoriaTable> categorias { get; set; }
        public DbSet<ClienteTable> clientes { get; set; }
        public DbSet<ClienteDireccionTable> clienteDirecciones { get; set; }
        public DbSet<CompraTable> compras { get; set; }
        public DbSet<DeliveryTable> deliverys { get; set; }
        public DbSet<DetalleCompraTable> detalleCompras { get; set; }
        public DbSet<DetalleVentaTable> detalleVentas { get; set; }
        public DbSet<DocumentoTable> documentos { get; set; }
        public DbSet<EstadoTable> estados { get; set; }
        public DbSet<OrdenServicioTecnicoTable> ordenServicioTecnicos { get; set; }
        public DbSet<ProductoTable> productos { get; set; }
        public DbSet<ProveedorTable> proveedores { get; set; }
        public DbSet<RecojoAlmacenTable> recojoAlmacen { get; set; }
        public DbSet<RolTable> roles { get; set; }
        public DbSet<TipoPagoTable> tipoPagos { get; set; }
        public DbSet<UsuarioTable> usuarios { get; set; }
        public DbSet<TrabajadorTable> trabajadores { get; set; }
        public DbSet<VentaTable> ventas { get; set; }
        public DbSet<MarcaTable> marcas { get; set; }
    }
}
