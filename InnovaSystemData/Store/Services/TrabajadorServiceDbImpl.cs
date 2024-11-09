using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;
using Microsoft.EntityFrameworkCore;

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
                entity.Id = trabajadoresTable.Id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar este trabajador");
            }
        }
        public void Delete(int id)
        {
            TrabajadorTable? trabajadorTable = _db.trabajadores.FirstOrDefault(r => r.Id == id && r.Estado);
            if (trabajadorTable == null) throw new MessageExeption("No se encontro el trabajador");
            //_db.roles.Remove(trabajadorTable);
            trabajadorTable.Estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el trabajador");
        }
        public List<Trabajador> GetAll()
        {
            List<Trabajador> trabajadores = _db.trabajadores
                .Where(r => r.Estado)
                .Select<TrabajadorTable, Trabajador>(
                    rt => rt.ToModel()
                ).ToList();
            return trabajadores;
        }

        public Trabajador? GetById(int id)
        {
            TrabajadorTable? trabajador = _db.trabajadores
                .FirstOrDefault(r => r.Id == id && r.Estado);
            if (trabajador == null) return null;
            return trabajador.ToModel();
        }

        public void Update(int id, Trabajador body)
        {
            TrabajadorTable? rol = _db.trabajadores
                .FirstOrDefault(r => r.Id == id && r.Estado);
            if (rol == null) throw new MessageExeption("No se encontro el Trabajador");
            rol.Nombres = body.Nombre;
            rol.ApellidoPaterno = body.ApellidoPaterno;
            rol.ApellidoMaterno = body.ApellidoMaterno;
            rol.FechaInicioContrato = body.FechaInicioContrato;
            rol.FechaFinContrato = body.FechaFinContrato;
            rol.PuestoId = body.PuestoId;
            rol.Salario = body.Salario;
            rol.Telefono = body.Telefono;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Trabajador");
        }

        public void CambiarEstado(int id, bool nuevoEstado)
        {
            // Busca la state en la base de datos
            TrabajadorTable? state = _db.trabajadores.FirstOrDefault(r => r.Id == id);

            // Verifica si el state existe
            if (state == null)
            {
                throw new MessageExeption("No se encontró el Trabajador con el ID proporcionado");
            }

            // Cambia el estado de la categoria
            state.Estado = nuevoEstado;

            // Guarda los cambios en la base de datos
            int resultado = _db.SaveChanges();

            // Verifica si la actualización fue exitosa
            if (resultado != 1)
            {
                throw new MessageExeption("No se pudo cambiar el estado del Trabajador");
            }
        }

        public List<TrabajadorDto> ObtenerTrabajadoresConPuesto()
        {
            var trabajadoresConPuesto = _db.trabajadores
                .Include(t => t.Puesto)  // Incluye los datos de CargoTable
                .Select(t => new TrabajadorDto
                {
                    Id = t.Id,
                    Nombres = t.Nombres,
                    ApellidoPaterno = t.ApellidoPaterno,
                    ApellidoMaterno = t.ApellidoMaterno,
                    Telefono = t.Telefono,
                    Salario = t.Salario,
                    NombrePuesto = t.Puesto.nombre  // Obteniendo el nombre del puesto
                })
                .ToList();

            return trabajadoresConPuesto;
        }
    }
}