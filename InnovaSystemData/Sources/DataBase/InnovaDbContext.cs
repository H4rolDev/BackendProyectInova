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
            modelBuilder.Entity<RolTable>()
                .HasMany<UsuarioTable>()
                .WithOne()
                .HasForeignKey(u => u.id_rol)
                .IsRequired();

            // Persona - Usuario | uno a uno
            modelBuilder.Entity<PersonaTable>()
                .HasOne<UsuarioTable>()
                .WithOne()
                .HasForeignKey<UsuarioTable>(u => u.id_Persona)
                .IsRequired();
            
            // Persona - Trabajador | uno a uno
            modelBuilder.Entity<PersonaTable>()
                .HasOne<TrabajadorTable>()
                .WithOne()
                .HasForeignKey<TrabajadorTable>(u => u.id_Persona)
                .IsRequired();

            // Trababajador -> OrdenServicioTecnico | uno a muchos
            modelBuilder.Entity<TrabajadorTable>()
                .HasMany<OrdenServicioTecnicoTable>()
                .WithOne()
                .HasForeignKey(u => u.id_Trabajador)
                .IsRequired();

            // Cliente -> OrdenServicioTecnico | uno a muchos
            modelBuilder.Entity<ClienteTable>()
                .HasMany<OrdenServicioTecnicoTable>()
                .WithOne()
                .HasForeignKey(u => u.id_cliente)
                .IsRequired();

            // ClienteDireccion -> Cliente | uno a uno
            modelBuilder.Entity<ClienteDireccionTable>()
                .HasOne<ClienteTable>()
                .WithOne()
                .HasForeignKey<ClienteTable>(u => u.id_Direccion)
                .IsRequired();

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

            // Persona -> Cliente | uno a uno
            modelBuilder.Entity<PersonaTable>()
                .HasOne<ClienteTable>()
                .WithOne()
                .HasForeignKey<ClienteTable>(u => u.id_Persona)
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

            // Productos -> DetalleVenta | uno a muchos
            modelBuilder.Entity<ProductoTable>()
                .HasMany<DetalleVentaTable>()
                .WithOne()
                .HasForeignKey(u => u.id_producto)
                .IsRequired();

            //TipoProducto -> Categoria | uno a muchos
            modelBuilder.Entity<CategoriaTable>()
                .HasMany<ProductoTable>()
                .WithOne()
                .HasForeignKey(u => u.id_categoria)
                .IsRequired();

            // Marca -> Producto | uno a muchos
            modelBuilder.Entity<MarcaTable>()
                .HasMany<ProductoTable>()
                .WithOne()
                .HasForeignKey(u => u.id_marca)
                .IsRequired();
        }
        public DbSet<CategoriaTable> categorias { get; set; }
        public DbSet<ClienteTable> clientes { get; set; }
        public DbSet<ClienteDireccionTable> clienteDirecciones { get; set; }
        public DbSet<DeliveryTable> deliverys { get; set; }
        public DbSet<DetalleVentaTable> detalleVentas { get; set; }
        public DbSet<OrdenServicioTecnicoTable> ordenServicioTecnicos { get; set; }
        public DbSet<PersonaTable> personas { get; set; }
        public DbSet<ProductoTable> productos { get; set; }
        public DbSet<RecojoAlmacenTable> recojoAlmacen { get; set; }
        public DbSet<RolTable> roles { get; set; }
        public DbSet<TipoPagoTable> tipoPagos { get; set; }
        public DbSet<UsuarioTable> usuarios { get; set; }
        public DbSet<TrabajadorTable> trabajadores { get; set; }
        public DbSet<VentaTable> ventas { get; set; }
        public DbSet<MarcaTable> marcas { get; set; }
        public DbSet<CargoTable> cargos { get; set; }
    }
}
