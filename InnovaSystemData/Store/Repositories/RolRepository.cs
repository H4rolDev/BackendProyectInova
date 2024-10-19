using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class RolRepositoryImpl : IRolRepository
    {
        private readonly IRolService _rol;
        public RolRepositoryImpl(
           IRolService rol
        )
        {
            _rol = rol;
        }
        public IRolService rol()
        {   
            return _rol;
        }
    }
}