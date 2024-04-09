using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpacecapsCase.Application.Interfaces;
using SpacecapsCase.Application.Services;
using SpacecapsCase.Domain;
using SpacecapsCase.Domain.Constants;
using SpacecapsCase.Domain.Dto;
using SpacecapsCase.Domain.Interfaces;

namespace SpacecapsCase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IHttpHeaderService _httpHeaderSevice;
        private readonly IUsuarioUseCase _usuarioUseCase;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioUseCase usuarioUseCase, IHttpHeaderService httpHeaderService)
        {
            _logger = logger;
            _usuarioUseCase = usuarioUseCase;
            _httpHeaderSevice = httpHeaderService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var idSolicitante = _httpHeaderSevice.GetHeaderValue("IdSolicitante");
            if (idSolicitante is null)
                return BadRequest(Mensagens.HEADER_ID_SOLICITANTE);

            var result = _usuarioUseCase.ObterUsuario(id, idSolicitante);
            if(result.Result is null)
                return NoContent();

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var idSolicitante = _httpHeaderSevice.GetHeaderValue("IdSolicitante");
            if (idSolicitante is null)
                return BadRequest(Mensagens.HEADER_ID_SOLICITANTE);

            var result = _usuarioUseCase.ListUsuarios(idSolicitante);
            if (result.Result is null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult Post(Usuario usuario)
        {
            return Ok(_usuarioUseCase.CriarUsuario(usuario));
        }
    }
}
