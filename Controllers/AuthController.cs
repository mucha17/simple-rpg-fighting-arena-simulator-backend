using simple_rpg_fighting_simulator.Data;
using simple_rpg_fighting_simulator.Dtos.User;
using simple_rpg_fighting_simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace simple_rpg_fighting_simulator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(
            UserRegisterDto request)
        {
            var response = await _authRepository.Register(
                new User { Username = request.Username }, request.Password
            );
            if(!response.Success) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(
            UserLoginDto request)
        {
            var response = await _authRepository.Login(request.Username,
                request.Password);
            if(!response.Success) {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}