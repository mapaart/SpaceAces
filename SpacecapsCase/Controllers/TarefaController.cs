using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpacecapsCase.Application.Interfaces;
using SpacecapsCase.Domain.Constants;
using SpacecapsCase.Domain.Dto;
using SpacecapsCase.Domain.Interfaces;

namespace SpacecapsCase.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : Controller
    {
        private readonly ILogger<TarefaController> _logger;
        private readonly ITarefaUseCase _tarefaUseCase;
        private readonly IHttpHeaderService _httpHeaderSevice;

        public TarefaController(ILogger<TarefaController> logger, ITarefaUseCase tarefaUseCase, IHttpHeaderService httpHeaderService)
        {
            _logger = logger;
            _tarefaUseCase = tarefaUseCase;
            _httpHeaderSevice = httpHeaderService;
        }

        [Authorize]
        [HttpPost("create")]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            var idSolicitante = _httpHeaderSevice.GetHeaderValue("IdSolicitante");
            if (idSolicitante is null)
                return BadRequest(Mensagens.HEADER_ID_SOLICITANTE);

            return Ok(_tarefaUseCase.CriarTarefa(tarefa, idSolicitante));
        }

        [Authorize]
        [HttpPut("update")]
        public IActionResult AtualizarTarefa(Tarefa tarefa)
        {
            var idSolicitante = _httpHeaderSevice.GetHeaderValue("IdSolicitante");
            if (idSolicitante is null)
                return BadRequest(Mensagens.HEADER_ID_SOLICITANTE);

            return Ok(_tarefaUseCase.AtualizarTarefa(tarefa, idSolicitante));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult ApagarTarefa(int id)
        {
            var idSolicitante = _httpHeaderSevice.GetHeaderValue("IdSolicitante");
            if (idSolicitante is null)
                return BadRequest(Mensagens.HEADER_ID_SOLICITANTE);

            return Ok(_tarefaUseCase.DeletarTarefa(id, idSolicitante));
        }

        [Authorize]
        [HttpGet()]
        public IActionResult ObterTarefas()
        {
            var idSolicitante = _httpHeaderSevice.GetHeaderValue("IdSolicitante");
            if (idSolicitante is null)
                return BadRequest(Mensagens.HEADER_ID_SOLICITANTE);

            return Ok(_tarefaUseCase.TarefaList(idSolicitante));
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult ObterTarefa(int id)
        {
            var idSolicitante = _httpHeaderSevice.GetHeaderValue("IdSolicitante");
            if (idSolicitante is null)
                return BadRequest(Mensagens.HEADER_ID_SOLICITANTE);

            return Ok(_tarefaUseCase.ConsultarTarefa(id, idSolicitante));
        }
    }
}