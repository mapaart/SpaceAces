using Microsoft.AspNetCore.Mvc;
using SpacecapsCase.Domain.Dto;
using SpacecapsCase.Domain.Interfaces;

namespace SpacecapsCase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginUseCase _loginUseCase;

        public LoginController(ILogger<LoginController> logger, ILoginUseCase loginUseCase)
        {
            _logger = logger;
            _loginUseCase = loginUseCase;
        }

        [HttpPost("valida")]
        public IActionResult ValidaLogin(Login login)
        {
            return Ok(_loginUseCase.RealizarLogin(login));
        }
    }
}
