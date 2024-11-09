using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class ClienteDireccionServiceDbImpl : IClienteDireccionService
    {
        private readonly InnovaDbContext _db;
        public ClienteDireccionServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public ClienteDireccion Create(ClienteDireccion entity)
        {
            ClienteDireccionTable clientedireccionTable = entity.ToTable();
            _db.clienteDirecciones.Add(clientedireccionTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = clientedireccionTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar la Direccion del CLiente");
            }
        }
        public void Delete(int id)
        {
            ClienteDireccionTable? clientedireccionTable = _db.clienteDirecciones.FirstOrDefault(r => r.id == id && r.estado);
            if (clientedireccionTable == null) throw new MessageExeption("No se encontro la Direccion del CLiente");
            //_db.proveedores.Remove(proveedorTable);
            clientedireccionTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Direccion del CLiente");
        }
        public List<ClienteDireccion> GetAll()
        {
            List<ClienteDireccion> clientedirecciones = _db.clienteDirecciones
                .Where(r => r.estado)
                .Select<ClienteDireccionTable, ClienteDireccion>(
                    rt => rt.ToModel()
                ).ToList();
            return clientedirecciones;
        }

        public ClienteDireccion? GetById(int id)
        {
            ClienteDireccionTable? clientedirecciones = _db.clienteDirecciones
                .FirstOrDefault(r => r.id == id && r.estado);
            if (clientedirecciones == null) return null;
            return clientedirecciones.ToModel();
        }

        public void Update(int id, ClienteDireccion body)
        {
            ClienteDireccionTable? clienteDireccion = _db.clienteDirecciones
                .FirstOrDefault(r => r.id == id && r.estado);
            if (clienteDireccion == null) throw new MessageExeption("No se encontro la Direccion del Cliente");
            clienteDireccion.direccion = body.Direccion;
            clienteDireccion.referencia = body.Referencia;
            clienteDireccion.departamento = body.Departamento;
            clienteDireccion.provincia = body.Provincia;
            clienteDireccion.distrito = body.Distrito;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Direccion del Cliente");
        }

        public void CambiarEstado(int id, bool nuevoEstado)
        {
            var trabajadorTable = _db.clienteDirecciones.FirstOrDefault(r => r.id == id);
            if (trabajadorTable == null) throw new MessageExeption("No se encontró la Marca");
    
            trabajadorTable.estado = nuevoEstado;  // Cambiar el estado
            int result = _db.SaveChanges();
            if (result != 1) throw new MessageExeption("No se pudo cambiar el estado");
        }

    }
}