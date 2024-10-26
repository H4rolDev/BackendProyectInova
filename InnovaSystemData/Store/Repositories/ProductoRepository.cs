using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class ProductoRepositoryImpl : IProductoRepository
    {
        private readonly IProductoService _producto;
        private readonly ICategoriaService _categoria;
        private readonly IMarcaService _marca;
        public ProductoRepositoryImpl(
           IProductoService producto,
           ICategoriaService categoria,
           IMarcaService marca
        )
        {
            _producto = producto;
            _categoria = categoria;
            _marca = marca;
        }
        public IProductoService producto()
        {   
            return _producto;
        }
        public ICategoriaService categoria()
        {
            return _categoria;
        }
        public IMarcaService marca()
        {
            return _marca;
        }
    }
}