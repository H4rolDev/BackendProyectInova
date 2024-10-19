using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class ClienteRepositoryImpl : IClienteRepository
    {
        private readonly IClienteService _cliente;
        public ClienteRepositoryImpl(
           IClienteService cliente
        )
        {
            _cliente = cliente;
        }
        public IClienteService cliente()
        {   
            return _cliente;
        }
    }
}