using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class ClienteDireccionRepositoryImpl : IClienteDireccionRepository
    {
        private readonly IClienteDireccionService _clienteDireccion;
        public ClienteDireccionRepositoryImpl(
           IClienteDireccionService clienteDireccion
        )
        {
            _clienteDireccion = clienteDireccion;
        }
        public IClienteDireccionService clientedireccion()
        {   
            return _clienteDireccion;
        }
    }
}