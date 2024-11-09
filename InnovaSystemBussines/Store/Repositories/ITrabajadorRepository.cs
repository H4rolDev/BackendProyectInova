using InnovaSystemBussines.Store.Services;

namespace InnovaSystemBussines.Store.Repositories {
    public interface ITrabajadorRepository {
        public ITrabajadorService trabajador();
        public ICargoService cargo();
        List<TrabajadorDto> ObtenerTrabajadoresConPuesto();
    }
}