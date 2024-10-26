using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly IUsuarioService _usuario;
        private readonly IClienteService _cliente;
        private readonly IRolService _rol;
        private readonly ITrabajadorService _trabajador;
        public UsuarioRepositoryImpl(
           IUsuarioService usuario,
           IClienteService cliente,
           IRolService rol,
           ITrabajadorService trabajador
        )
        {
            _usuario = usuario;
            _cliente = cliente;
            _rol = rol;
            _trabajador = trabajador;
        }
        public IUsuarioService usuario()
        {   
            return _usuario;
        }
        public IClienteService cliente()
        {
            return _cliente;
        }
        public IRolService rol()
        {
            return _rol;
        }
        public ITrabajadorService trabajador()
        {
            return _trabajador;
        }
    }
}