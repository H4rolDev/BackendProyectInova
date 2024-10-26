using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class DeliveryRepositoryImpl : IDeliveryRepository
    {
        private readonly IDeliveryService _delivery;
        private readonly IClienteDireccionService _direccion;
        public DeliveryRepositoryImpl(
           IDeliveryService delivery,
           IClienteDireccionService direccion
        )
        {
            _delivery = delivery;
            _direccion = direccion;
 
        }
        public IDeliveryService delivery()
        {   
            return _delivery;
        }
        public IClienteDireccionService direccion()
        {
            return _direccion;
        }
    }
}