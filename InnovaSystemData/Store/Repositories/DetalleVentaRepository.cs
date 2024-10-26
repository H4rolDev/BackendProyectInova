using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class DetalleVentaRepositoryImpl : IDetalleVentaRepository
    {
        private readonly IDetalleVentaService _detalleVenta;
        private readonly IProductoService _producto;
        private readonly IVentaService _venta;
        public DetalleVentaRepositoryImpl(
           IDetalleVentaService detalleVenta,
           IProductoService producto,
           IVentaService venta
        )
        {
            _detalleVenta = detalleVenta;
            _producto = producto;
            _venta = venta;
        }
        public IDetalleVentaService detalleventa()
        {   
            return _detalleVenta;
        }
        public IProductoService producto()
        {
            return _producto;
        }
        public IVentaService venta()
        {
            return _venta;
        }
    }
}