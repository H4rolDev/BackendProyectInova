using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class MarcaRepositoryImpl : IMarcaRepository
    {
        private readonly IMarcaService _marca;
        public MarcaRepositoryImpl(
           IMarcaService marca
        )
        {
            _marca = marca;
        }
        public IMarcaService marca()
        {   
            return _marca;
        }
    }
}