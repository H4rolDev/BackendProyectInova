using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class TipoPagoServiceDbImpl : ITipoPagoService
    {
        private readonly InnovaDbContext _db;
        public TipoPagoServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public TipoPago Create(TipoPago entity)
        {
           TipoPagoTable tipoPagoTable = entity.ToTable();
            _db.tipoPagos.Add(tipoPagoTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = tipoPagoTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar el Tipo de Pago");
            }
        }
        public void Delete(int id)
        {
            TipoPagoTable? tipoPagoTable = _db.tipoPagos.FirstOrDefault(r => r.id == id && r.estado);
            if (tipoPagoTable == null) throw new MessageExeption("No se encontro el Tipo de Pago");
            //_db.proveedores.Remove(proveedorTable);
            tipoPagoTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Tipo de Pago");
        }
        public List<TipoPago> GetAll()
        {
            List<TipoPago> tipoPago = _db.tipoPagos
                .Where(r => r.estado)
                .Select<TipoPagoTable, TipoPago>(
                    rt => rt.ToModel()
                ).ToList();
            return tipoPago;
        }

        public TipoPago? GetById(int id)
        {
            TipoPagoTable? tipoPago = _db.tipoPagos
                .FirstOrDefault(r => r.id == id && r.estado);
            if (tipoPago == null) return null;
            return tipoPago.ToModel();
        }

        public void Update(int id, TipoPago body)
        {
            TipoPagoTable? tipoPago = _db.tipoPagos
                .FirstOrDefault(r => r.id == id && r.estado);
            if (tipoPago == null) throw new MessageExeption("No se encontro el Tipo de Pago");
            tipoPago.nombres = body.Nombre;
            tipoPago.descripcion = body.Descripcion;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el detalleVenta");
        }

        public void CambiarEstado(int id, bool nuevoEstado)
        {
            var trabajadorTable = _db.tipoPagos.FirstOrDefault(r => r.id == id);
            if (trabajadorTable == null) throw new MessageExeption("No se encontró el TIpo de Pago");
    
            trabajadorTable.estado = nuevoEstado;  // Cambiar el estado
            int result = _db.SaveChanges();
            if (result != 1) throw new MessageExeption("No se pudo cambiar el estado");
        }
    }
}