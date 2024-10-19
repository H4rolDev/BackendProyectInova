using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class RolServiceDbImpl : IRolService
    {
        private readonly InnovaDbContext _db;
        public RolServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Rol Create(Rol entity)
        {
            RolTable rolesTable = entity.ToTable();
            _db.roles.Add(rolesTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = rolesTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar esta marca");
            }
        }
        public void Delete(int id)
        {
            RolTable? rolTable = _db.roles.FirstOrDefault(r => r.id == id && r.estado);
            if (rolTable == null) throw new MessageExeption("No se encontro la marca");
            //_db.roles.Remove(rolTable);
            rolTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la marca");
        }
        public List<Rol> GetAll()
        {
            List<Rol> roles = _db.roles
                .Where(r => r.estado)
                .Select<RolTable, Rol>(
                    rt => rt.ToModel()
                ).ToList();
            return roles;
        }

        public Rol? GetById(int id)
        {
            RolTable? rol = _db.roles
                .FirstOrDefault(r => r.id == id && r.estado);
            if (rol == null) return null;
            return rol.ToModel();
        }

        public void Update(int id, Rol body)
        {
            RolTable? rol = _db.roles
                .FirstOrDefault(r => r.id == id && r.estado);
            if (rol == null) throw new MessageExeption("No se encontro el rol");
            rol.nombre = body.Nombre;
            rol.descripcion = body.Descripcion;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la marca");
        }
    }
}