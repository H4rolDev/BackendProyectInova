using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class CargoRepositoryImpl : ICargoRepository
    {
        private readonly ICargoService _cargo;
        public CargoRepositoryImpl(
           ICargoService cargo
        )
        {
            _cargo = cargo;

        }
        public ICargoService cargo()
        {   
            return _cargo;
        }
    }
}