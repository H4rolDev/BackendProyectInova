using InnovaSystemBussines.Store.Services;

namespace InnovaSystemBussines.Store.Repositories {
    public interface IOrdenServicioTecnicoRepository {
        public IOrdenServicioTecnicoService ordenserviciotecnico();
        public IClienteService cliente();
        public ITrabajadorService trabajador();
    }
}