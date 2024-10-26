using InnovaSystemBussines.Store.Services;

namespace InnovaSystemBussines.Store.Repositories {
    public interface IVentaRepository {
        public IVentaService venta();
        public IClienteService cliente();
        public ITrabajadorService trabajador();
        public IDeliveryService delivery();
        public ITipoPagoService tipopago();
    }
}