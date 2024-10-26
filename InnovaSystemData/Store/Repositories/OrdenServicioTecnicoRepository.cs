using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class OrdenServicioTecnicoRepositoryImpl : IOrdenServicioTecnicoRepository
    {
        private readonly IOrdenServicioTecnicoService _ordenserviciotecnico;
        private readonly IClienteService _cliente;
        private readonly ITrabajadorService _trabajador;
        public OrdenServicioTecnicoRepositoryImpl(
           IOrdenServicioTecnicoService ordenserviciotecnico,
           IClienteService cliente,
           ITrabajadorService trabajador
        )
        {
            _ordenserviciotecnico = ordenserviciotecnico;
            _cliente = cliente;
            _trabajador = trabajador;
        }
        public IOrdenServicioTecnicoService ordenserviciotecnico()
        {   
            return _ordenserviciotecnico;
        }
        public IClienteService cliente()
        {   
            return _cliente;
        }
        public ITrabajadorService trabajador()
        {   
            return _trabajador;
        }
    }
}