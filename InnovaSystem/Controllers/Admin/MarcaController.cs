using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Repositories;
using InnovaSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnovaSystem.Controllers.Admin
{
    [ApiController]
    [Route("/api/v1/admin/marca")]
    public class MarcaController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IMarcaRepository _marcaRepo;
        public MarcaController(
            IMarcaRepository marcaRepo,
            ILogger<MarcaController> logger
        ) {
          _marcaRepo = marcaRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Marca>> Listar()
        {
            try
            {
                List<Marca> marcas = _marcaRepo.marca().GetAll();
                return Ok(marcas);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[MarcaController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[MarcaController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{marca_id}")]
        public ActionResult<Marca> Obtener([FromRoute]int marca_id)
        {
            try
            {
                Marca? marca = _marcaRepo.marca().GetById(marca_id); 
                if (marca == null)
                {
                    return NotFound();
                }
                return Ok(marca);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[MarcaController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[MarcaController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Marca> Crear([FromBody] MarcaBody body)
        {
            try
            {
                Marca marca = _marcaRepo.marca().Create( (Marca)body );
               
                return Ok(marca);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[MarcaController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[MarcaController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{marca_id}")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int marca_id, [FromBody] MarcaBody body)
        {
            try
            {
                _marcaRepo.marca().Update(marca_id, (Marca)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[MarcaController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[MarcaController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{marca_id}")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int marca_id)
        {
            try
            {
                _marcaRepo.marca().Delete(marca_id);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[MarcaController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[MarcaController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}