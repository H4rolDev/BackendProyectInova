using InnovaSystemBussines.Store.Services;

namespace InnovaSystemBussines.Store.Repositories {
    public interface IProductoRepository {
        public IProductoService producto();
        public ICategoriaService categoria();
        public IMarcaService marca();
    }
}