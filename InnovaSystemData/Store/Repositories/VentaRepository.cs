using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class VentaRepositoryImpl : IVentaRepository
    {
        private readonly IVentaService _venta;
        private readonly IClienteService _cliente;
        private readonly ITrabajadorService _trabajador;
        private readonly IDeliveryService _delivery;
        private readonly ITipoPagoService _tipoPago;
        public VentaRepositoryImpl(
           IVentaService venta,
           IClienteService cliente,
           ITrabajadorService trabajador,
           IDeliveryService delivery,
           ITipoPagoService tipoPago
        )
        {
            _venta = venta;
            _cliente = cliente;
            _trabajador = trabajador;
            _delivery = delivery;
            _tipoPago = tipoPago;
        }
        public IVentaService venta()
        {   
            return _venta;
        }
        public IClienteService cliente()
        {
            return _cliente;
        }
        public ITrabajadorService trabajador()
        {
            return _trabajador;
        }
        public IDeliveryService delivery()
        {
            return _delivery;
        }
        public ITipoPagoService tipopago()
        {
            return _tipoPago;
        }
    }
}