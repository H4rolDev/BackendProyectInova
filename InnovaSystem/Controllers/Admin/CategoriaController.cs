using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/categoria")]
    public class CategoriaController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly ICategoriaRepository _categoriaRepo;
        public CategoriaController(
            ICategoriaRepository categoriaRepo,
            ILogger<CategoriaController> logger
        ) {
          _categoriaRepo = categoriaRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Categoria>> Listar()
        {
            try
            {
                List<Categoria> categorias = _categoriaRepo.categoria().GetAll();
                return Ok(categorias);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoriaController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[CategoriaController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{categoria_id}")]
        public ActionResult<Categoria> Obtener([FromRoute]int categoria_id)
        {
            try
            {
                Categoria? categoria = _categoriaRepo.categoria().GetById(categoria_id); 
                if (categoria == null)
                {
                    return NotFound();
                }
                return Ok(categoria);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoriaController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[CategoriaController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Categoria> Crear([FromBody] CategoriaBody body)
        {
            try
            {
                Categoria categoria = _categoriaRepo.categoria().Create( (Categoria)body );
               
                return Ok(categoria);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoriaController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoriaController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{categoria_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int categoria_id, [FromBody] CategoriaBody body)
        {
            try
            {
                _categoriaRepo.categoria().Update(categoria_id, (Categoria)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoriaController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoriaController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{categoria_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int categoria_id)
        {
            try
            {
                _categoriaRepo.categoria().Delete(categoria_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoriaController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoriaController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}