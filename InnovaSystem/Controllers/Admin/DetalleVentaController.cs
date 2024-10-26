using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/detalleVenta")]
    public class DetalleVentaController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IDetalleVentaRepository _detalleVentaRepo;
        public DetalleVentaController(
            IDetalleVentaRepository detalleVentaRepo,
            ILogger<DetalleVentaController> logger
        ) {
          _detalleVentaRepo = detalleVentaRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<DetalleVenta>> Listar()
        {
            try
            {
                List<DetalleVenta> detalleVenta = _detalleVentaRepo.detalleventa().GetAll();
                return Ok(detalleVenta);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DetalleVentaController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[DetalleVentaController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{detalleventa_id}")]
        public ActionResult<DetalleVenta> Obtener([FromRoute]int detalleventa_id)
        {
            try
            {
                DetalleVenta? detalleVenta = _detalleVentaRepo.detalleventa().GetById(detalleventa_id); 
                if (detalleVenta == null)
                {
                    return NotFound();
                }
                return Ok(detalleVenta);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DetalleVentaController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[DetalleVentaController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<DetalleVenta> Crear([FromBody] DetalleVentaBody body)
        {
            try
            {
                DetalleVenta detalleVenta = _detalleVentaRepo.detalleventa().Create( (DetalleVenta)body );
               
                return Ok(detalleVenta);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DetalleVentaController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[DetalleVentaController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{detalleventa_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int detalleventa_id, [FromBody] DetalleVentaBody body)
        {
            try
            {
                _detalleVentaRepo.detalleventa().Update(detalleventa_id, (DetalleVenta)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DetalleVentaController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[DetalleVentaController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{detalleventa_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int detalleventa_id)
        {
            try
            {
                _detalleVentaRepo.detalleventa().Delete(detalleventa_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DetalleVentaController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[DetalleVentaController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}