using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class TrabajadorRepositoryImpl : ITrabajadorRepository
    {
        private readonly ITrabajadorService _trabajador;
        public TrabajadorRepositoryImpl(
           ITrabajadorService trabajador
        )
        {
            _trabajador = trabajador;
        }
        public ITrabajadorService trabajador()
        {   
            return _trabajador;
        }
    }
}