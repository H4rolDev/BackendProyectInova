using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class OrdenServicioTecnicoRepositoryImpl : IOrdenServicioTecnicoRepository
    {
        private readonly IOrdenServicioTecnicoService _ordenserviciotecnico;
        public OrdenServicioTecnicoRepositoryImpl(
           IOrdenServicioTecnicoService ordenserviciotecnico
        )
        {
            _ordenserviciotecnico = ordenserviciotecnico;
        }
        public IOrdenServicioTecnicoService ordenserviciotecnico()
        {   
            return _ordenserviciotecnico;
        }
    }
}