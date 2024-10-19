using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/ordenserviciotecnico")]
    public class OrdenServicioTecnicoController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IOrdenServicioTecnicoRepository _ordenserviciotecnicoRepo;
        public OrdenServicioTecnicoController(
            IOrdenServicioTecnicoRepository ordenserviciotecnicoRepo,
            ILogger<OrdenServicioTecnicoController> logger
        ) {
          _ordenserviciotecnicoRepo =ordenserviciotecnicoRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<OrdenServicioTecnico>> Listar()
        {
            try
            {
                List<OrdenServicioTecnico> ordenServicioTecnicos = _ordenserviciotecnicoRepo.ordenserviciotecnico().GetAll();
                return Ok(ordenServicioTecnicos);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{ordenserviciotecnico_id}")]
        public ActionResult<OrdenServicioTecnico> Obtener([FromRoute]int ordenserviciotecnico_id)
        {
            try
            {
                OrdenServicioTecnico? ordenserviciotecnico = _ordenserviciotecnicoRepo.ordenserviciotecnico().GetById(ordenserviciotecnico_id); 
                if (ordenserviciotecnico == null)
                {
                    return NotFound();
                }
                return Ok(ordenserviciotecnico);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<OrdenServicioTecnico> Crear([FromBody] OrdenServicioTecnicoBody body)
        {
            try
            {
                OrdenServicioTecnico ordenserviciotecnico = _ordenserviciotecnicoRepo.ordenserviciotecnico().Create( (OrdenServicioTecnico)body );
               
                return Ok(ordenserviciotecnico);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{ordenserviciotecnico_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int ordenserviciotecnico_id, [FromBody] OrdenServicioTecnicoBody body)
        {
            try
            {
                _ordenserviciotecnicoRepo.ordenserviciotecnico().Update(ordenserviciotecnico_id, (OrdenServicioTecnico)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{ordenserviciotecnico_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int ordenserviciotecnico_id)
        {
            try
            {
                _ordenserviciotecnicoRepo.ordenserviciotecnico().Delete(ordenserviciotecnico_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[OrdenServicioTecnicoController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}