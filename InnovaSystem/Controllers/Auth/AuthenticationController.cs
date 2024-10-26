using InnovaSystem.Models;
using InnovaSystemBussines.Auth.models;
using InnovaSystemBussines.Auth.repositories;
using InnovaSystemBussines.Errors;
using Microsoft.AspNetCore.Mvc;
namespace InnovaSystem.Controllers.Auth
{
    [ApiController]
    [Route("/api/v1/auth")]
    public class AuthenticationController : ControllerBase
    {
        public readonly ILogger _logger;
        private readonly IAuthenticationRepository _auth;
        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IAuthenticationRepository auth){
            _auth = auth;
            _logger =logger;
        }
        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login([FromBody]LoginRequest body){
            try{
                return Ok(_auth.Login(body));
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TrabajadorController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[TrabajadorController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<CustomResponse> Register([FromBody]RegisterRequest body){
            try{
                _auth.Register(body);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[TrabajadorController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[TrabajadorController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}