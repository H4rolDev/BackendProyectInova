using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/cliente")]
    public class ClienteController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IClienteRepository _clienterRepo;
        public ClienteController(
            IClienteRepository clienteRepo,
            ILogger<ClienteController> logger
        ) {
          _clienterRepo = clienteRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Cliente>> Listar()
        {
            try
            {
                List<Cliente> clientes = _clienterRepo.cliente().GetAll();
                return Ok(clientes);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[ClienteController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{cliente_id}")]
        public ActionResult<Proveedor> Obtener([FromRoute]int cliente_id)
        {
            try
            {
                Cliente? cliente = _clienterRepo.cliente().GetById(cliente_id); 
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[ClienteController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Cliente> Crear([FromBody] ClienteBody body)
        {
            try
            {
                Cliente cliente = _clienterRepo.cliente().Create( (Cliente)body );
               
                return Ok(cliente);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ClienteController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{cliente_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int cliente_id, [FromBody] ClienteBody body)
        {
            try
            {
                _clienterRepo.cliente().Update(cliente_id, (Cliente)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ClienteController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{cliente_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int cliente_id)
        {
            try
            {
                _clienterRepo.cliente().Delete(cliente_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ClienteController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ClienteController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}