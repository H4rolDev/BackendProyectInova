using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/trabajador")]
    public class TrabajadorController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly ITrabajadorRepository _trabajadorRepo;
        public TrabajadorController(
            ITrabajadorRepository trabajadorRepo,
            ILogger<TrabajadorController> logger
        ) {
          _trabajadorRepo = trabajadorRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Trabajador>> Listar()
        {
            try
            {
                List<Trabajador> trabajadores = _trabajadorRepo.trabajador().GetAll();
                return Ok(trabajadores);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TrabajadorController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[TrabajadorController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{trabajador_id}")]
        public ActionResult<Trabajador> Obtener([FromRoute]int trabajador_id)
        {
            try
            {
                Trabajador? trabajador = _trabajadorRepo.trabajador().GetById(trabajador_id); 
                if (trabajador == null)
                {
                    return NotFound();
                }
                return Ok(trabajador);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TrabajadorController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[TrabajadorController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Trabajador> Crear([FromBody] TrabajadorBody body)
        {
            try
            {
                Trabajador trabajador = _trabajadorRepo.trabajador().Create( (Trabajador)body );
               
                return Ok(trabajador);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TrabajadorController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[TrabajadorController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{trabajador_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int trabajador_id, [FromBody] TrabajadorBody body)
        {
            try
            {
                _trabajadorRepo.trabajador().Update(trabajador_id, (Trabajador)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TrabajadorController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[TrabajadorController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{trabajador_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int trabajador_id)
        {
            try
            {
                _trabajadorRepo.trabajador().Delete(trabajador_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TrabajadorController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[TrabajadorController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}