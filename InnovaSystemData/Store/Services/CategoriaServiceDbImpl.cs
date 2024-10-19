using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class CategoriaServiceDbImpl : ICategoriaService
    {
        private readonly InnovaDbContext _db;
        public CategoriaServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Categoria Create(Categoria entity)
        {
            CategoriaTable categoriaTable = entity.ToTable();
            _db.categorias.Add(categoriaTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = categoriaTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar la Categoria");
            }
        }
        public void Delete(int id)
        {
            CategoriaTable? categoriaTable = _db.categorias.FirstOrDefault(r => r.id == id && r.estado);
            if (categoriaTable == null) throw new MessageExeption("No se encontro la Categoria");
            //_db.proveedores.Remove(proveedorTable);
            categoriaTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Categoria");
        }
        public List<Categoria> GetAll()
        {
            List<Categoria> categorias = _db.categorias
                .Where(r => r.estado)
                .Select<CategoriaTable, Categoria>(
                    rt => rt.ToModel()
                ).ToList();
            return categorias;
        }

        public Categoria? GetById(int id)
        {
            CategoriaTable? categoria = _db.categorias
                .FirstOrDefault(r => r.id == id && r.estado);
            if (categoria == null) return null;
            return categoria.ToModel();
        }

        public void Update(int id, Categoria body)
        {
            CategoriaTable? categoria = _db.categorias
                .FirstOrDefault(r => r.id == id && r.estado);
            if (categoria == null) throw new MessageExeption("No se encontro la Categoria");
            categoria.nombre = body.Nombre;
            categoria.descripcion = body.Descripcion;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Categoria");
        }
    }
}