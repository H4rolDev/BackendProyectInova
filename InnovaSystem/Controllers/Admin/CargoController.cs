using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/cargo")]
    public class CargoController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly ICargoRepository _cargoRepo;
        public CargoController(
            ICargoRepository cargoRepo,
            ILogger<CargoController> logger
        ) {
          _cargoRepo = cargoRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Cargo>> Listar()
        {
            try
            {
                List<Cargo> cargos = _cargoRepo.cargo().GetAll();
                return Ok(cargos);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CargoController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[CargoController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{cargo_id}")]
        public ActionResult<Cargo> Obtener([FromRoute]int cargo_id)
        {
            try
            {
                Cargo? cargo = _cargoRepo.cargo().GetById(cargo_id); 
                if (cargo == null)
                {
                    return NotFound();
                }
                return Ok(cargo);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CargoController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[CargoController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Cargo> Crear([FromBody] CargoBody body)
        {
            try
            {
                Cargo cargo = _cargoRepo.cargo().Create( (Cargo)body );
               
                return Ok(cargo);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CargoController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CargoController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{cargo_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int cargo_id, [FromBody] CargoBody body)
        {
            try
            {
                _cargoRepo.cargo().Update(cargo_id, (Cargo)body);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CargoController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CargoController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{cargo_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int cargo_id)
        {
            try
            {
                _cargoRepo.cargo().Delete(cargo_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CargoController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CargoController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}