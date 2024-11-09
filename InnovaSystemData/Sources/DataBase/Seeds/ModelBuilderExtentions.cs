using InnovaSystemData.Sources.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSystemData.Sources.DataBase.Seeds
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolTable>().HasData(
                new RolTable
                {
                    id = 1,
                    nombre = "Trabajador",
                    descripcion = "Acceso total a todas las funcionalidades.",
                    estado = true
                },
                new RolTable
                {
                    id = 2,
                    nombre = "Cliente",
                    descripcion = "Acceso limitado a funcionalidades básicas.",
                    estado = true
                }
            );
            modelBuilder.Entity<PersonaTable>().HasData(
                new PersonaTable
                {
                    id = 1,
                    nombres = "Juan",
                    apellidos = "Pérez",
                    tipo_documento = "DNI",
                    numero_documento = "12345678",
                    estado = true
                },
                new PersonaTable
                {
                    id = 2,
                    nombres = "María",
                    apellidos = "González",
                    tipo_documento = "DNI",
                    numero_documento = "87654321",
                    estado = true
                }
            );
            modelBuilder.Entity<ClienteTable>().HasData(
                new ClienteTable
                {
                    id = 1,
                    id_Direccion = 1,
                    id_Persona = 1,
                    RSocial = "Cliente 1",
                    Nombres = "Juan",
                    Apellidos = "Perez",
                    telefono = 123456789,
                    correo = "juan.cliente@example.com",
                    TipoDocumento = "DNI",
                    NumeroDocumento = 12345678,
                    estado = true
                },
                new ClienteTable
                {
                    id = 2,
                    id_Direccion = 2,
                    id_Persona = 2,
                    RSocial = null,
                    Nombres = "Maria",
                    Apellidos = "Gomez",
                    telefono = 987654321,
                    correo = "maria.cliente@example.com",
                    TipoDocumento = "DNI",
                    NumeroDocumento = 87654321,
                    estado = true
                }
            );
            modelBuilder.Entity<CargoTable>().HasData(
                new CargoTable
                {
                    id = 1,
                    nombre = "Gerente",
                    descripcion = "Encargado de la empresa.",
                    salarioBase = 4000m,
                    Estado = true
                },
                new CargoTable
                {
                    id = 2,
                    nombre = "Vendedor",
                    descripcion = "Vende en tienda.",
                    salarioBase = 2000m,
                    Estado = true
                },
                new CargoTable
                {
                    id = 3,
                    nombre = "Servicio Tecnico",
                    descripcion = "Tecnico en computacion.",
                    salarioBase = 2000m,
                    Estado = true
                }
            );
            
            modelBuilder.Entity<TrabajadorTable>().HasData(
                new TrabajadorTable
                {
                    Id = 1,
                    Id_Persona = 1,
                    PuestoId = 1, // Asegúrate de que el cargo con ID 1 exista en CargoTable
                    Nombres = "Juan",
                    ApellidoPaterno = "García",
                    ApellidoMaterno = "Pérez",
                    FechaInicioContrato = new DateTime(2022, 01, 15),
                    FechaFinContrato = new DateTime(2024, 01, 15),
                    Salario = 4000.00m,
                    Telefono = "987654321",
                    Estado = true
                }
            );
            modelBuilder.Entity<UsuarioTable>().HasData(
                new UsuarioTable
                {
                    id = 1,
                    Correo = "juan.usuario@example.com",
                    clave = "123456",
                    salt = "randomsalt1",
                    estado = true,
                    id_Persona = 1,
                    id_rol = 1
                },
                new UsuarioTable
                {
                    id = 2,
                    Correo = "maria.usuario@example.com",
                    clave = "123456",
                    salt = "randomsalt2",
                    estado = true,
                    id_Persona = 2,
                    id_rol = 2
                }
            );
            modelBuilder.Entity<CategoriaTable>().HasData(
                new CategoriaTable
                {
                    id = 1,
                    nombre = "Computadoras",
                    descripcion = "Todo tipo de computadoras, desde portátiles hasta de escritorio.",
                    estado = true
                },
                new CategoriaTable
                {
                    id = 2,
                    nombre = "Periféricos",
                    descripcion = "Accesorios y dispositivos periféricos para computadoras.",
                    estado = true
                },
                new CategoriaTable
                {
                    id = 3,
                    nombre = "Componentes",
                    descripcion = "Componentes internos como tarjetas madre, procesadores, etc.",
                    estado = true
                }
            );

            
            modelBuilder.Entity<ClienteDireccionTable>().HasData(
                new ClienteDireccionTable
                {
                    id = 1,
                    direccion = "Av. José Larco 123",
                    referencia = "Frente al parque central",
                    departamento = "Lima",
                    provincia = "Lima",
                    distrito = "Miraflores",
                    estado = true
                },
                new ClienteDireccionTable
                {
                    id = 2,
                    direccion = "Jr. Tacna 456",
                    referencia = "Cerca a la plaza de armas",
                    departamento = "Arequipa",
                    provincia = "Arequipa",
                    distrito = "Arequipa",
                    estado = true
                },
                new ClienteDireccionTable
                {
                    id = 3,
                    direccion = "Av. Los Incas 789",
                    referencia = "Cerca del colegio nacional",
                    departamento = "Cusco",
                    provincia = "Cusco",
                    distrito = "Cusco",
                    estado = true
                }
            );
            modelBuilder.Entity<ProductoTable>().HasData(
                new ProductoTable
                {
                    id = 1,
                    id_categoria = 1, // Referencia a la categoría correspondiente
                    id_marca = 1,     // Referencia a la marca "HP"
                    nombre = "HP Pavilion 15",
                    imagen = "hp_pavilion_15.jpg",
                    descripcion = "Laptop HP Pavilion con procesador Intel Core i5 y 8GB de RAM.",
                    modelo = "15-eh2021nr",
                    precioVenta = 3500.00m,
                    utilidadPrecioVenta = 500.00m,
                    utilidadPorcentaje = 14,
                    stock = 20,
                    garantia = 12, // meses
                    estado = true
                },
                new ProductoTable
                {
                    id = 2,
                    id_categoria = 1, // Referencia a la categoría correspondiente
                    id_marca = 3,     // Referencia a la marca "Dell"
                    nombre = "Dell XPS 13",
                    imagen = "dell_xps_13.jpg",
                    descripcion = "Laptop Dell XPS 13 con pantalla InfinityEdge y procesador Intel Core i7.",
                    modelo = "XPS 13 9310",
                    precioVenta = 4500.00m,
                    utilidadPrecioVenta = 600.00m,
                    utilidadPorcentaje = 13,
                    stock = 15,
                    garantia = 12, // meses
                    estado = true
                },
                new ProductoTable
                {
                    id = 3,
                    id_categoria = 2, // Referencia a la categoría correspondiente
                    id_marca = 2,     // Referencia a la marca "Logitech"
                    nombre = "Logitech MX Master 3",
                    imagen = "logitech_mx_master_3.jpg",
                    descripcion = "Mouse inalámbrico Logitech MX Master 3 con control preciso.",
                    modelo = "MX Master 3",
                    precioVenta = 150.00m,
                    utilidadPrecioVenta = 20.00m,
                    utilidadPorcentaje = 13,
                    stock = 50,
                    garantia = 24, // meses
                    estado = true
                },
                new ProductoTable
                {
                    id = 4,
                    id_categoria = 3, // Referencia a la categoría correspondiente
                    id_marca = 6,     // Referencia a la marca "Razer"
                    nombre = "Razer BlackWidow V3",
                    imagen = "razer_blackwidow_v3.jpg",
                    descripcion = "Teclado mecánico Razer BlackWidow V3 con retroiluminación RGB.",
                    modelo = "BlackWidow V3",
                    precioVenta = 200.00m,
                    utilidadPrecioVenta = 30.00m,
                    utilidadPorcentaje = 15,
                    stock = 25,
                    garantia = 12, // meses
                    estado = true
                }
            );
            modelBuilder.Entity<MarcaTable>().HasData(
                new MarcaTable
                {
                    id = 1,
                    nombre = "HP",
                    descripcion = "Líder en computadoras portátiles y de escritorio.",
                    estado = true
                },
                new MarcaTable
                {
                    id = 2,
                    nombre = "Logitech",
                    descripcion = "Famosa por sus periféricos como teclados y mouses.",
                    estado = true
                },
                new MarcaTable
                {
                    id = 3,
                    nombre = "Dell",
                    descripcion = "Reconocida por sus laptops y soluciones empresariales.",
                    estado = true
                },
                new MarcaTable
                {
                    id = 4,
                    nombre = "Asus",
                    descripcion = "Conocida por sus computadoras y componentes de alto rendimiento.",
                    estado = true
                },
                new MarcaTable
                {
                    id = 5,
                    nombre = "Acer",
                    descripcion = "Fabricante de computadoras y tecnología innovadora.",
                    estado = true
                },
                new MarcaTable
                {
                    id = 6,
                    nombre = "Razer",
                    descripcion = "Marca premium en periféricos para gamers.",
                    estado = true
                },
                new MarcaTable
                {
                    id = 7,
                    nombre = "Microsoft",
                    descripcion = "Conocida por sus productos de software y hardware, incluyendo teclados.",
                    estado = true
                },
                new MarcaTable
                {
                    id = 8,
                    nombre = "Apple",
                    descripcion = "Reconocida por su tecnología innovadora y productos de alta gama.",
                    estado = true
                }
            );
        }
    }
}
