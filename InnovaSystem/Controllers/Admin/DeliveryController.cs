using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/delivery")]
    public class DeliveryController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IDeliveryRepository _deliveryRepo;
        public DeliveryController(
            IDeliveryRepository deliveryRepo,
            ILogger<DeliveryController> logger
        ) {
          _deliveryRepo = deliveryRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Delivery>> Listar()
        {
            try
            {
                List<Delivery> delivery = _deliveryRepo.delivery().GetAll();
                return Ok(delivery);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DeliveryController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[DeliveryController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{delivery_id}")]
        public ActionResult<Delivery> Obtener([FromRoute]int delivery_id)
        {
            try
            {
                Delivery? delivery = _deliveryRepo.delivery().GetById(delivery_id); 
                if (delivery == null)
                {
                    return NotFound();
                }
                return Ok(delivery);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DeliveryController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[DeliveryController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Delivery> Crear([FromBody] DeliveryBody body)
        {
            try
            {
                Delivery delivery = _deliveryRepo.delivery().Create( (Delivery)body );
               
                return Ok(delivery);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DeliveryController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[DeliveryController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{delivery_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int delivery_id)
        {
            try
            {
                _deliveryRepo.delivery().Delete(delivery_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[DeliveryController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[DeliveryController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}