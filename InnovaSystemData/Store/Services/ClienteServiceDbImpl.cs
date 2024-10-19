using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class ClienteServiceDbImpl : IClienteService
    {
        private readonly InnovaDbContext _db;
        public ClienteServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Cliente Create(Cliente entity)
        {
            ClienteTable clienteTable = entity.ToTable();
            _db.clientes.Add(clienteTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = clienteTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar este cliente");
            }
        }
        public void Delete(int id)
        {
            ClienteTable? clienteTable = _db.clientes.FirstOrDefault(r => r.id == id && r.estado);
            if (clienteTable == null) throw new MessageExeption("No se encontro el Cliente");
            //_db.proveedores.Remove(proveedorTable);
            clienteTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Cliente");
        }
        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = _db.clientes
                .Where(r => r.estado)
                .Select<ClienteTable, Cliente>(
                    rt => rt.ToModel()
                ).ToList();
            return clientes;
        }

        public Cliente? GetById(int id)
        {
            ClienteTable? cliente = _db.clientes
                .FirstOrDefault(r => r.id == id && r.estado);
            if (cliente == null) return null;
            return cliente.ToModel();
        }

        public void Update(int id, Cliente body)
        {
            ClienteTable? cliente = _db.clientes
                .FirstOrDefault(r => r.id == id && r.estado);
            if (cliente == null) throw new MessageExeption("No se encontro el Cliente");
            cliente.RSocial = body.RazonSocial;
            cliente.documento = body.Documento;
            cliente.Nombres = body.Nombres;
            cliente.Apellidos = body.Apellidos;
            cliente.telefono = body.Telefono;
            cliente.correo = body.Correo;
            cliente.direccion = body.Direccion;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Cliente");
        }
    }
}