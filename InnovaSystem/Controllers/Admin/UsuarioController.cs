using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/usuarios")]
    public class UsuarioController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IUsuarioRepository _usuarioRepo;
        public UsuarioController(
            IUsuarioRepository usuarioRepo,
            ILogger<UsuarioController> logger
        ) {
          _usuarioRepo = usuarioRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Usuario>> Listar()
        {
            try
            {
                List<Usuario> usuarios = _usuarioRepo.usuario().GetAll();
                return Ok(usuarios);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[UsuarioController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[UsuarioController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{usuario_id}")]
        public ActionResult<Usuario> Obtener([FromRoute]int usuario_id)
        {
            try
            {
                Usuario? usuario = _usuarioRepo.usuario().GetById(usuario_id); 
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[UsuarioController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[UsuarioController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Usuario> Crear([FromBody] UsuarioBody body)
        {
            try
            {
                Usuario usuario = _usuarioRepo.usuario().Create( (Usuario)body );
               
                return Ok(usuario);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[UsuarioController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[UsuarioController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{usuario_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int usuario_id, [FromBody] UsuarioBody body)
        {
            try
            {
                _usuarioRepo.usuario().Update(usuario_id, (Usuario)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[UsuarioController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[UsuarioController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{usuario_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int usuario_id)
        {
            try
            {
                _usuarioRepo.usuario().Delete(usuario_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[UsuarioController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[UsuarioController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}