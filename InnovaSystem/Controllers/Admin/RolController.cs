using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/rol")]
    public class RolController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IRolRepository _rolRepo;
        public RolController(
            IRolRepository rolRepo,
            ILogger<RolController> logger
        ) {
          _rolRepo = rolRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Rol>> Listar()
        {
            try
            {
                List<Rol> roles = _rolRepo.rol().GetAll();
                return Ok(roles);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[ProductController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{rol_id}")]
        public ActionResult<Rol> Obtener([FromRoute]int rol_id)
        {
            try
            {
                Rol? rol = _rolRepo.rol().GetById(rol_id); 
                if (rol == null)
                {
                    return NotFound();
                }
                return Ok(rol);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[ProductController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Rol> Crear([FromBody] RolBody body)
        {
            try
            {
                Rol rol = _rolRepo.rol().Create( (Rol)body );
               
                return Ok(rol);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{rol_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int rol_id, 
                                     [FromBody] RolBody body)
        {
            try
            {
                _rolRepo.rol().Update(rol_id, (Rol)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{rol_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int rol_id)
        {
            try
            {
                _rolRepo.rol().Delete(rol_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}
