using InnovaSystemBussines.Store.Services;

namespace InnovaSystemBussines.Store.Repositories {
    public interface IClienteRepository {
        public IClienteService cliente();
        public IClienteDireccionService clientedireccion();
    }
}