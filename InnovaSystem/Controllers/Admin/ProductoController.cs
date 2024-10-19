using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/producto")]
    public class ProductoController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IProductoRepository _productoRepo;
        public ProductoController(
            IProductoRepository productoRepo,
            ILogger<ProductoController> logger
        ) {
          _productoRepo = productoRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Producto>> Listar()
        {
            try
            {
                List<Producto> productos = _productoRepo.producto().GetAll();
                return Ok(productos);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductoController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[ProductoController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{producto_id}")]
        public ActionResult<Producto> Obtener([FromRoute]int producto_id)
        {
            try
            {
                Producto? producto = _productoRepo.producto().GetById(producto_id); 
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductoController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[ProductoController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Producto> Crear([FromBody] ProductoBody body)
        {
            try
            {
                Producto producto = _productoRepo.producto().Create( (Producto)body );
               
                return Ok(producto);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductoController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductoController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{producto_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int producto_id, [FromBody] ProductoBody body)
        {
            try
            {
                _productoRepo.producto().Update(producto_id, (Producto)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductoController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductoController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{producto_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int producto_id)
        {
            try
            {
                _productoRepo.producto().Delete(producto_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductoController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductoController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}