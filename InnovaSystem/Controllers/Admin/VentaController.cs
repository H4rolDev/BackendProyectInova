using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/venta")]
    public class VentaController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IVentaRepository _ventaRepo;
        public VentaController(
            IVentaRepository ventaRepo,
            ILogger<VentaController> logger
        ) {
          _ventaRepo = ventaRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Venta>> Listar()
        {
            try
            {
                List<Venta> venta = _ventaRepo.venta().GetAll();
                return Ok(venta);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[VentaController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[VentaController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{venta_id}")]
        public ActionResult<Venta> Obtener([FromRoute]int venta_id)
        {
            try
            {
                Venta? Venta = _ventaRepo.venta().GetById(venta_id); 
                if (Venta == null)
                {
                    return NotFound();
                }
                return Ok(Venta);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[VentaController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[VentaController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Venta> Crear([FromBody] VentaBody body)
        {
            try
            {
                Venta Venta = _ventaRepo.venta().Create( (Venta)body );
               
                return Ok(Venta);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[VentaController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[VentaController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{venta_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int venta_id)
        {
            try
            {
                _ventaRepo.venta().Delete(venta_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[VentaController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[VentaController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}