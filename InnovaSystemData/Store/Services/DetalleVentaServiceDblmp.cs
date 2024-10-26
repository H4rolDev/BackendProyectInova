using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class DetalleVentaServiceDbImpl : IDetalleVentaService
    {
        private readonly InnovaDbContext _db;
        public DetalleVentaServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public DetalleVenta Create(DetalleVenta entity)
        {
           DetalleVentaTable detalleVentaTable = entity.ToTable();
            _db.detalleVentas.Add(detalleVentaTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = detalleVentaTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar el Detalle de la Venta");
            }
        }
        public void Delete(int id)
        {
            DetalleVentaTable? detalleVentaTable = _db.detalleVentas.FirstOrDefault(r => r.id == id && r.estado);
            if (detalleVentaTable == null) throw new MessageExeption("No se encontro el Detalle de la Venta");
            //_db.proveedores.Remove(proveedorTable);
            detalleVentaTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Detalle de la Venta");
        }
        public List<DetalleVenta> GetAll()
        {
            List<DetalleVenta> detalleVenta = _db.detalleVentas
                .Where(r => r.estado)
                .Select<DetalleVentaTable, DetalleVenta>(
                    rt => rt.ToModel()
                ).ToList();
            return detalleVenta;
        }

        public DetalleVenta? GetById(int id)
        {
            DetalleVentaTable? detalleVenta = _db.detalleVentas
                .FirstOrDefault(r => r.id == id && r.estado);
            if (detalleVenta == null) return null;
            return detalleVenta.ToModel();
        }

        public void Update(int id, DetalleVenta body)
        {
            DetalleVentaTable? detalleVenta = _db.detalleVentas
                .FirstOrDefault(r => r.id == id && r.estado);
            if (detalleVenta == null) throw new MessageExeption("No se encontro el Detalle de la Venta");
            detalleVenta.id_producto = body.ProductoId;
            detalleVenta.id_venta = body.VentaId;
            detalleVenta.precioUnitario = body.PrecioUnitario;
            detalleVenta.cantidad = body.Cantidad;
            detalleVenta.impuestos = body.Impuesto;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el detalleVenta");
        }
    }
}