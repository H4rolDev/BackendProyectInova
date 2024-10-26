using InnovaSystemBussines.Store.Services;

namespace InnovaSystemBussines.Store.Repositories {
    public interface IDeliveryRepository {
        public IDeliveryService delivery();
        public IClienteDireccionService direccion();
    }
}