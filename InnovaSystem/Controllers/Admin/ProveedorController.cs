using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/proveedor")]
    public class ProveedorController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IProveedorRepository _proveedorRepo;
        public ProveedorController(
            IProveedorRepository proveedorRepo,
            ILogger<ProveedorController> logger
        ) {
          _proveedorRepo = proveedorRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Proveedor>> Listar()
        {
            try
            {
                List<Proveedor> proveedores = _proveedorRepo.proveedor().GetAll();
                return Ok(proveedores);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProveedorController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[ProveedorController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{proveedor_id}")]
        public ActionResult<Proveedor> Obtener([FromRoute]int proveedor_id)
        {
            try
            {
                Proveedor? proveedor = _proveedorRepo.proveedor().GetById(proveedor_id); 
                if (proveedor == null)
                {
                    return NotFound();
                }
                return Ok(proveedor);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProveedorController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[ProveedorController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Proveedor> Crear([FromBody] ProveedorBody body)
        {
            try
            {
                Proveedor proveedor = _proveedorRepo.proveedor().Create( (Proveedor)body );
               
                return Ok(proveedor);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProveedorController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProveedorController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{proveedor_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int proveedor_id, [FromBody] ProveedorBody body)
        {
            try
            {
                _proveedorRepo.proveedor().Update(proveedor_id, (Proveedor)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProveedorController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProveedorController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{proveedor_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int proveedor_id)
        {
            try
            {
                _proveedorRepo.proveedor().Delete(proveedor_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProveedorController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProveedorController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}