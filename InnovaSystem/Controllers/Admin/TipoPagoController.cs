using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/tipopago")]
    public class TipoPagoController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly ITipoPagoRepository _tipoPagoRepo;
        public TipoPagoController(
            ITipoPagoRepository tipoPagoRepo,
            ILogger<TipoPagoController> logger
        ) {
          _tipoPagoRepo = tipoPagoRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<TipoPago>> Listar()
        {
            try
            {
                List<TipoPago> tipoPago = _tipoPagoRepo.tipopago().GetAll();
                return Ok(tipoPago);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TipoPagoController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[TipoPagoController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{tipopago_id}")]
        public ActionResult<TipoPago> Obtener([FromRoute]int tipopago_id)
        {
            try
            {
                TipoPago? tipoPago = _tipoPagoRepo.tipopago().GetById(tipopago_id); 
                if (tipoPago == null)
                {
                    return NotFound();
                }
                return Ok(tipoPago);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TipoPagoController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[TipoPagoController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<TipoPago> Crear([FromBody] TipoPagoBody body)
        {
            try
            {
                TipoPago tipoPago = _tipoPagoRepo.tipopago().Create( (TipoPago)body );
               
                return Ok(tipoPago);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TipoPagoController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[TipoPagoController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{tipopago_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int tipopago_id)
        {
            try
            {
                _tipoPagoRepo.tipopago().Delete(tipopago_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TipoPagoController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[TipoPagoController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}