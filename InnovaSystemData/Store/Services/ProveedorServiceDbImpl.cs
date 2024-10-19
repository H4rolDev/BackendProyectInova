using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class ProveedorServiceDbImpl : IProveedorService
    {
        private readonly InnovaDbContext _db;
        public ProveedorServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Proveedor Create(Proveedor entity)
        {
            ProveedorTable proveedoresTable = entity.ToTable();
            _db.proveedores.Add(proveedoresTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = proveedoresTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar este proveedor");
            }
        }
        public void Delete(int id)
        {
            ProveedorTable? proveedorTable = _db.proveedores.FirstOrDefault(r => r.id == id && r.estado);
            if (proveedorTable == null) throw new MessageExeption("No se encontro el proveedor");
            //_db.proveedores.Remove(proveedorTable);
            proveedorTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el trabajador");
        }
        public List<Proveedor> GetAll()
        {
            List<Proveedor> proveedores = _db.proveedores
                .Where(r => r.estado)
                .Select<ProveedorTable, Proveedor>(
                    rt => rt.ToModel()
                ).ToList();
            return proveedores;
        }

        public Proveedor? GetById(int id)
        {
            ProveedorTable? proveedor = _db.proveedores
                .FirstOrDefault(r => r.id == id && r.estado);
            if (proveedor == null) return null;
            return proveedor.ToModel();
        }

        public void Update(int id, Proveedor body)
        {
            ProveedorTable? proveedor = _db.proveedores
                .FirstOrDefault(r => r.id == id && r.estado);
            if (proveedor == null) throw new MessageExeption("No se encontro el Proveedor");
            proveedor.nombreContacto = body.PersonaContacto;
            proveedor.RSocial = body.RazonSocial;
            proveedor.RUC = body.RUC;
            proveedor.telefono = body.Telefono;
            proveedor.correo = body.CorreoElectronico;
            proveedor.direccion = body.Direccion;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Proveedor");
        }
    }
}