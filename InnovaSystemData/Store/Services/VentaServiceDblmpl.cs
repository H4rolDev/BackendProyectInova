using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class VentaServiceDbImpl : IVentaService
    {
        private readonly InnovaDbContext _db;
        public VentaServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Venta Create(Venta entity)
        {
           VentaTable ventaTable = entity.ToTable();
            _db.ventas.Add(ventaTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = ventaTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar la Venta");
            }
        }
        public void Delete(int id)
        {
            VentaTable? ventaTable = _db.ventas.FirstOrDefault(r => r.id == id && r.estado);
            if (ventaTable == null) throw new MessageExeption("No se encontro la Venta");
            //_db.proveedores.Remove(proveedorTable);
            ventaTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Venta");
        }
        public List<Venta> GetAll()
        {
            List<Venta> Venta = _db.ventas
                .Where(r => r.estado)
                .Select<VentaTable, Venta>(
                    rt => rt.ToModel()
                ).ToList();
            return Venta;
        }

        public Venta? GetById(int id)
        {
            VentaTable? Venta = _db.ventas
                .FirstOrDefault(r => r.id == id && r.estado);
            if (Venta == null) return null;
            return Venta.ToModel();
        }
        public void Update(int id, Venta body)
        {
            VentaTable? venta = _db.ventas
                .FirstOrDefault(r => r.id == id && r.estado);
            if (venta == null) throw new MessageExeption("No se encontro la Venta");
            venta.id_cliente = body.ClienteId;
            venta.id_trabajador = body.TrabajadorId;
            venta.id_delivery = body.DeliveryId;
            venta.id_tipoPago = body.TipoPagoId;
            venta.id_recojoAlmacen = body.RecojoAlmacenId;
            venta.fechaCompra = body.FechaCompra;
            venta.totalVenta = body.TotalVenta;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar a Venta");
        }
    }
}