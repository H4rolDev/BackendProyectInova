using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class MarcaServiceDbImpl : IMarcaService
    {
        private readonly InnovaDbContext _db;
        public MarcaServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Marca Create(Marca entity)
        {
            MarcaTable marcaTable = entity.ToTable();
            _db.marcas.Add(marcaTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = marcaTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar la Marca");
            }
        }
        public void Delete(int id)
        {
            MarcaTable? marcaTable = _db.marcas.FirstOrDefault(r => r.id == id && r.estado);
            if (marcaTable == null) throw new MessageExeption("No se encontro la Marca");
            //_db.proveedores.Remove(proveedorTable);
            marcaTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Marca");
        }
        public List<Marca> GetAll()
        {
            List<Marca> marca = _db.marcas
                .Where(r => r.estado)
                .Select<MarcaTable, Marca>(
                    rt => rt.ToModel()
                ).ToList();
            return marca;
        }

        public Marca? GetById(int id)
        {
            MarcaTable? marca = _db.marcas
                .FirstOrDefault(r => r.id == id && r.estado);
            if (marca == null) return null;
            return marca.ToModel();
        }

        public void Update(int id, Marca body)
        {
            MarcaTable? marca = _db.marcas
                .FirstOrDefault(r => r.id == id && r.estado);
            if (marca == null) throw new MessageExeption("No se encontro la Marca");
            marca.nombre = body.Nombre;
            marca.descripcion = body.Descripcion;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Marca");
        }

        public void CambiarEstado(int id, bool nuevoEstado)
        {
            // Busca la marca en la base de datos
            MarcaTable? marca = _db.marcas.FirstOrDefault(r => r.id == id);

            // Verifica si la marca existe
            if (marca == null)
            {
                throw new MessageExeption("No se encontró la Marca con el ID proporcionado");
            }

            // Cambia el estado de la marca
            marca.estado = nuevoEstado;

            // Guarda los cambios en la base de datos
            int resultado = _db.SaveChanges();

            // Verifica si la actualización fue exitosa
            if (resultado != 1)
            {
                throw new MessageExeption("No se pudo cambiar el estado de la Marca");
            }
        }
    }
}