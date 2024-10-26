using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class TipoPagoRepositoryImpl : ITipoPagoRepository
    {
        private readonly ITipoPagoService _tipoPago;
        public TipoPagoRepositoryImpl(
           ITipoPagoService tipoPago
        )
        {
            _tipoPago = tipoPago;
        }
        public ITipoPagoService tipopago()
        {   
            return _tipoPago;
        }
        
    }
}