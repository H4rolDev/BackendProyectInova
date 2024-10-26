using InnovaSystemBussines.Store.Services;

namespace InnovaSystemBussines.Store.Repositories {
    public interface IDetalleVentaRepository {
        public IDetalleVentaService detalleventa();
        public IProductoService producto();
        public IVentaService venta();
    }
}