using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class ProductoServiceDbImpl : IProductoService
    {
        private readonly InnovaDbContext _db;
        public ProductoServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Producto Create(Producto entity)
        {
            ProductoTable productoTable = entity.ToTable();
            _db.productos.Add(productoTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = productoTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar el Producto");
            }
        }
        public void Delete(int id)
        {
            ProductoTable? productoTable = _db.productos.FirstOrDefault(r => r.id == id && r.estado);
            if (productoTable == null) throw new MessageExeption("No se encontro el Producto");
            //_db.proveedores.Remove(proveedorTable);
            productoTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Producto");
        }
        public List<Producto> GetAll()
        {
            List<Producto> productos = _db.productos
                .Where(r => r.estado)
                .Select<ProductoTable, Producto>(
                    rt => rt.ToModel()
                ).ToList();
            return productos;
        }

        public Producto? GetById(int id)
        {
            ProductoTable? producto = _db.productos
                .FirstOrDefault(r => r.id == id && r.estado);
            if (producto == null) return null;
            return producto.ToModel();
        }

        public void Update(int id, Producto body)
        {
            ProductoTable? producto = _db.productos
                .FirstOrDefault(r => r.id == id && r.estado);
            if (producto == null) throw new MessageExeption("No se encontro el Producto");
            producto.nombre = body.Nombre;
            producto.imagen = body.Imagen;
            producto.id_categoria = body.categoriaId;
            producto.descripcion = body.Descripcion;
            producto.modelo = body.Modelo;
            producto.id_marca = body.MarcaId;
            producto.stock = body.Stock;
            producto.precioVenta = body.PrecioVenta;
            producto.utilidadPrecioVenta = body.UtilidadPrecioVenta;
            producto.utilidadPorcentaje = body.UtilidadPorcentaje;
            producto.garantia = body.Garantia;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Producto");
        }

        public void CambiarEstado(int id, bool nuevoEstado)
        {
            var trabajadorTable = _db.productos.FirstOrDefault(r => r.id == id);
            if (trabajadorTable == null) throw new MessageExeption("No se encontró la Marca");
    
            trabajadorTable.estado = nuevoEstado;  // Cambiar el estado
            int result = _db.SaveChanges();
            if (result != 1) throw new MessageExeption("No se pudo cambiar el estado");
        }
    }
}