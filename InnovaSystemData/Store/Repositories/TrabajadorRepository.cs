using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class TrabajadorRepositoryImpl : ITrabajadorRepository
    {
        private readonly ITrabajadorService _trabajador;
        private readonly ICargoService _cargo;
        public TrabajadorRepositoryImpl(
           ITrabajadorService trabajador,
           ICargoService cargo
        )
        {
            _trabajador = trabajador;
            _cargo = cargo;
        }
        public ITrabajadorService trabajador()
        {   
            return _trabajador;
        }

        public ICargoService cargo()
        {   
            return _cargo;
        }

        public List<TrabajadorDto> ObtenerTrabajadoresConPuesto()
        {
            // Obtiene listas de trabajadores y cargos
            var trabajadores = _trabajador.GetAll();
            var cargos = _cargo.GetAll();

            // Realiza la unión en memoria
            var trabajadoresConPuesto = trabajadores
                .Join(
                    cargos,
                    trabajador => trabajador.PuestoId,
                    cargo => cargo.Id,
                    (trabajador, cargo) => new TrabajadorDto
                    {
                        Id = trabajador.Id,
                        Nombres = trabajador.Nombre,
                        ApellidoPaterno = trabajador.ApellidoPaterno,
                        ApellidoMaterno = trabajador.ApellidoMaterno,
                        Telefono = trabajador.Telefono,
                        Salario = trabajador.Salario,
                        NombrePuesto = cargo.Nombre  // Asigna el nombre del puesto
                    }
                ).ToList();

            return trabajadoresConPuesto;
        }
    }
}