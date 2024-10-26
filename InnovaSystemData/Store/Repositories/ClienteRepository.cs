using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class ClienteRepositoryImpl : IClienteRepository
    {
        private readonly IClienteService _cliente;
        private readonly IClienteDireccionService _clienteDireccion;
        public ClienteRepositoryImpl(
           IClienteService cliente,
           IClienteDireccionService clienteDireccion
        )
        {
            _cliente = cliente;
            _clienteDireccion = clienteDireccion;
        }
        public IClienteService cliente()
        {   
            return _cliente;
        }
        public IClienteDireccionService clientedireccion()
        {
            return _clienteDireccion;
        }
    }
}