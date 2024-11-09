using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class DeliveryServiceDbImpl : IDeliveryService
    {
        private readonly InnovaDbContext _db;
        public DeliveryServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Delivery Create(Delivery entity)
        {
           DeliveryTable deliveryTable = entity.ToTable();
            _db.deliverys.Add(deliveryTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = deliveryTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar el Servicio de Delivery");
            }
        }
        public void Delete(int id)
        {
            DeliveryTable? deliveryTable = _db.deliverys.FirstOrDefault(r => r.id == id && r.estado);
            if (deliveryTable == null) throw new MessageExeption("No se encontro el Servicio de Delivery");
            //_db.proveedores.Remove(proveedorTable);
            deliveryTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Servicio de Delivery");
        }
        public List<Delivery> GetAll()
        {
            List<Delivery> delivery = _db.deliverys
                .Where(r => r.estado)
                .Select<DeliveryTable, Delivery>(
                    rt => rt.ToModel()
                ).ToList();
            return delivery;
        }

        public Delivery? GetById(int id)
        {
            DeliveryTable? delivery = _db.deliverys
                .FirstOrDefault(r => r.id == id && r.estado);
            if (delivery == null) return null;
            return delivery.ToModel();
        }
        public void Update(int id, Delivery body)
        {
            DeliveryTable? delivery = _db.deliverys
                .FirstOrDefault(r => r.id == id && r.estado);
            if (delivery == null) throw new MessageExeption("No se encontro el Servicio de Delivery");
            delivery.id_direccion = body.DireccionId;
            delivery.DNI = body.DNI;
            delivery.Nombre = body.Nombre;
            delivery.Apellidos = body.ApellidoPaterno;
            delivery.Correo = body.Email;
            delivery.Telefono = body.Telefono;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Sevicio de Delivery");
        }

        public void CambiarEstado(int id, bool nuevoEstado)
        {
            var trabajadorTable = _db.deliverys.FirstOrDefault(r => r.id == id);
            if (trabajadorTable == null) throw new MessageExeption("No se encontró la Marca");
    
            trabajadorTable.estado = nuevoEstado;  // Cambiar el estado
            int result = _db.SaveChanges();
            if (result != 1) throw new MessageExeption("No se pudo cambiar el estado");
        }
    }
}