using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class CargoServiceDbImpl : ICargoService
    {
        private readonly InnovaDbContext _db;
        public CargoServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Cargo Create(Cargo entity)
        {
            CargoTable cargoTable = entity.ToTable();
            _db.cargos.Add(cargoTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = cargoTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar el Cargo");
            }
        }
        public void Delete(int id)
        {
            CargoTable? cargoTable = _db.cargos.FirstOrDefault(r => r.id == id && r.Estado);
            if (cargoTable == null) throw new MessageExeption("No se encontro el Cargo");
            //_db.proveedores.Remove(proveedorTable);
            cargoTable.Estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Cargo");
        }
        public List<Cargo> GetAll()
        {
            List<Cargo> cargos = _db.cargos
                .Where(r => r.Estado)
                .Select<CargoTable, Cargo>(
                    rt => rt.ToModel()
                ).ToList();
            return cargos;
        }

        public Cargo? GetById(int id)
        {
            CargoTable? cargo = _db.cargos
                .FirstOrDefault(r => r.id == id && r.Estado);
            if (cargo == null) return null;
            return cargo.ToModel();
        }

        public void Update(int id, Cargo body)
        {
            CargoTable? cargo = _db.cargos
                .FirstOrDefault(r => r.id == id && r.Estado);
            if (cargo == null) throw new MessageExeption("No se encontro el Cargo");
            cargo.nombre = body.Nombre;
            cargo.descripcion = body.Descripcion;
            cargo.salarioBase = body.SalarioBase;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Cargo");
        }

        public void CambiarEstado(int id, bool nuevoEstado)
        {
            // Busca la cargo en la base de datos
            CargoTable? cargo = _db.cargos.FirstOrDefault(r => r.id == id);

            // Verifica si el cargo existe
            if (cargo == null)
            {
                throw new MessageExeption("No se encontró el Cargo con el ID proporcionado");
            }

            // Cambia el estado de la cargo
            cargo.Estado = nuevoEstado;

            // Guarda los cambios en la base de datos
            int resultado = _db.SaveChanges();

            // Verifica si la actualización fue exitosa
            if (resultado != 1)
            {
                throw new MessageExeption("No se pudo cambiar el estado del Cargo");
            }
        }
        public List<CargoTable> ObtenerTodosLosCargos()
        {
            // Consulta para obtener todos los cargos
            return _db.cargos.ToList();
        }
    }
}