using InnovaSystemBussines.Store.Services;

namespace InnovaSystemBussines.Store.Repositories {
    public interface IUsuarioRepository {
        public IUsuarioService usuario();
        public IClienteService cliente();
        public IRolService rol();
        public ITrabajadorService trabajador();
    }
}