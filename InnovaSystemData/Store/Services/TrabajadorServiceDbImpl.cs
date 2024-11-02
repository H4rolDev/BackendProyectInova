using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class TrabajadorServiceDbImpl : ITrabajadorService
    {
        private readonly InnovaDbContext _db;
        public TrabajadorServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Trabajador Create(Trabajador entity)
        {
            TrabajadorTable trabajadoresTable = entity.ToTable();
            _db.trabajadores.Add(trabajadoresTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = trabajadoresTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar este trabajador");
            }
        }
        public void Delete(int id)
        {
            TrabajadorTable? trabajadorTable = _db.trabajadores.FirstOrDefault(r => r.id == id && r.estado);
            if (trabajadorTable == null) throw new MessageExeption("No se encontro el trabajador");
            //_db.roles.Remove(trabajadorTable);
            trabajadorTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el trabajador");
        }
        public List<Trabajador> GetAll()
        {
            List<Trabajador> trabajadores = _db.trabajadores
                .Where(r => r.estado)
                .Select<TrabajadorTable, Trabajador>(
                    rt => rt.ToModel()
                ).ToList();
            return trabajadores;
        }

        public Trabajador? GetById(int id)
        {
            TrabajadorTable? trabajador = _db.trabajadores
                .FirstOrDefault(r => r.id == id && r.estado);
            if (trabajador == null) return null;
            return trabajador.ToModel();
        }

        public void Update(int id, Trabajador body)
        {
            TrabajadorTable? rol = _db.trabajadores
                .FirstOrDefault(r => r.id == id && r.estado);
            if (rol == null) throw new MessageExeption("No se encontro el Trabajador");
            rol.nombres = body.Nombre;
            rol.apellidoPaterno = body.ApellidoPaterno;
            rol.apellidoMaterno = body.ApellidoMaterno;
            rol.FechaInicioContrato = body.FechaInicioContrato;
            rol.FechaFinContrato = body.FechaFinContrato;
            rol.id_Puesto = body.PuestoId;
            rol.salario = body.Salario;
            rol.telefono = body.Telefono;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Trabajador");
        }
    }
}