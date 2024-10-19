using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class ProductoRepositoryImpl : IProductoRepository
    {
        private readonly IProductoService _producto;
        public ProductoRepositoryImpl(
           IProductoService producto
        )
        {
            _producto = producto;
        }
        public IProductoService producto()
        {   
            return _producto;
        }
    }
}