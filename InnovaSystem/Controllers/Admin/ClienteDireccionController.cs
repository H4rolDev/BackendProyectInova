using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/clientedireccion")]
    public class ClienteDireccionController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IClienteDireccionRepository _clienteDireccionRepo;
        public ClienteDireccionController(
            IClienteDireccionRepository clienteDireccionRepo,
            ILogger<ClienteDireccionController> logger
        ) {
          _clienteDireccionRepo = clienteDireccionRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<ClienteDireccion>> Listar()
        {
            try
            {
                List<ClienteDireccion> clientedirecciones = _clienteDireccionRepo.clientedireccion().GetAll();
                return Ok(clientedirecciones);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteDireccionController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[ClienteDireccionController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{clientedireccion_id}")]
        public ActionResult<ClienteDireccion> Obtener([FromRoute]int clientedireccion_id)
        {
            try
            {
                ClienteDireccion? clintedireccion = _clienteDireccionRepo.clientedireccion().GetById(clientedireccion_id); 
                if (clintedireccion == null)
                {
                    return NotFound();
                }
                return Ok(clintedireccion);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteDireccionController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[ClienteDireccionController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<ClienteDireccion> Crear([FromBody] ClienteDireccionBody body)
        {
            try
            {
                ClienteDireccion clientedireccion = _clienteDireccionRepo.clientedireccion().Create( (ClienteDireccion)body );
               
                return Ok(clientedireccion);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteDireccionController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ClienteDireccionController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{clientedireccion_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int clientedireccion_id, [FromBody] ClienteDireccionBody body)
        {
            try
            {
                _clienteDireccionRepo.clientedireccion().Update(clientedireccion_id, (ClienteDireccion)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteDireccionController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ClienteDireccionController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{clientedireccion_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int clientedireccion_id)
        {
            try
            {
                _clienteDireccionRepo.clientedireccion().Delete(clientedireccion_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteDireccionController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ClienteDireccionController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}