using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class ProveedorRepositoryImpl : IProveedorRepository
    {
        private readonly IProveedorService _proveedor;
        public ProveedorRepositoryImpl(
           IProveedorService proveedor
        )
        {
            _proveedor = proveedor;
        }
        public IProveedorService proveedor()
        {   
            return _proveedor;
        }
    }
}