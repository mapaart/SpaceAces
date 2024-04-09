using AutoMapper;
using SpacecapsCase.Application.Services;
using SpacecapsCase.Domain.Constants;
using SpacecapsCase.Domain.Dto;
using SpacecapsCase.Domain.Exception;
using SpacecapsCase.Domain.Interfaces;
using SpacecapsCase.Infrastructure.Data.Context;
using SpacecapsCase.Infrastructure.Data.Entity;
using SpacecapsCase.Infrastructure.Data.Repositories;

namespace SpacecapsCase.Domain.UseCases
{
    public class TarefaUseCaseImpl : ITarefaUseCase
    {
        private readonly IMapper _mapper;

        public TarefaUseCaseImpl(IMapper mapper)
        {
            _mapper = mapper;
        }
        TarefaService CreateServiceTarefa()
        {
            DatabaseContext db = new DatabaseContext();
            TarefaRepository repository = new TarefaRepository(db);
            TarefaService service = new TarefaService(repository);
            return service;
        }

        UsuarioService CreateServiceUsuario()
        {
            DatabaseContext db = new DatabaseContext();
            UsuarioRepository repository = new UsuarioRepository(db);
            UsuarioService service = new UsuarioService(repository);
            return service;
        }
        public Task<Tarefa> CriarTarefa(Tarefa tarefa, string idSolicitante)
        {
            var service = CreateServiceTarefa();
            tarefa.UsuarioId = int.TryParse(idSolicitante, out int result) ? result : 0;
            var tarefaEntity = _mapper.Map<TarefaEntity>(tarefa);
            var tarefaCriada = service.Add(tarefaEntity);
            return Task.FromResult(_mapper.Map<Tarefa>(tarefaCriada));
        }

        public Task DeletarTarefa(int idTarefa, string idSolicitante)
        {
            var serviceTarefa = CreateServiceTarefa();
            var serviceUsuario = CreateServiceUsuario();
            var usuarioSolicitante = serviceUsuario.GetById(int.TryParse(idSolicitante, out int result) ? result : 0);
            if (usuarioSolicitante is not null)
            {
                var tarefa = serviceTarefa.GetById(idTarefa);
                if (ValidaAcessoUsuario(usuarioSolicitante.NivelUserId, usuarioSolicitante.Id, tarefa.UsuarioId))
                {
                    serviceTarefa.Delete(idTarefa);
                    return Task.CompletedTask;
                }
                else throw new UsuarioSemPermissaoException(Mensagens.USUARIO_SEM_PERMISSAO);
            }
            throw new UsuarioNaoCadastradoException(Mensagens.USUARIO_NAO_CADASTRADO);
        }

        public Task<Tarefa> AtualizarTarefa(Tarefa tarefa, string idSolicitante)
        {
            var serviceTarefa = CreateServiceTarefa();
            var serviceUsuario = CreateServiceUsuario();
            var usuarioSolicitante = serviceUsuario.GetById(int.TryParse(idSolicitante, out int result) ? result : 0);
            if (usuarioSolicitante is not null)
            {
                if (ValidaAcessoUsuario(usuarioSolicitante.NivelUserId, usuarioSolicitante.Id, tarefa.UsuarioId))
                {
                    var entity = _mapper.Map<TarefaEntity>(tarefa);
                    serviceTarefa.Edit(entity);
                    return Task.FromResult(tarefa);
                }
                else throw new UsuarioSemPermissaoException(Mensagens.USUARIO_SEM_PERMISSAO);
            }
            throw new UsuarioNaoCadastradoException(Mensagens.USUARIO_NAO_CADASTRADO);
        }

        public Task<Tarefa> ConsultarTarefa(int id, string idSolicitante)
        {
            var serviceTarefa = CreateServiceTarefa();
            var serviceUsuario = CreateServiceUsuario();
            var usuarioSolicitante = serviceUsuario.GetById(int.TryParse(idSolicitante, out int result) ? result : 0);
            if (usuarioSolicitante is not null)
            {
                var tarefa = serviceTarefa.GetById(id);
                if (tarefa is null)
                    throw new TarefaNaoEncontradaException(Mensagens.TAREFA_NAO_ENCONTRADA);

                if (ValidaAcessoUsuario(usuarioSolicitante.NivelUserId, usuarioSolicitante.Id, tarefa.UsuarioId))
                {
                    return Task.FromResult(_mapper.Map<Tarefa>(tarefa));
                }
                else throw new UsuarioSemPermissaoException(Mensagens.USUARIO_SEM_PERMISSAO);
            }
            throw new UsuarioNaoCadastradoException(Mensagens.USUARIO_NAO_CADASTRADO);
        }

        public Task<List<Tarefa>> TarefaList(string idSolicitante)
        {
            var serviceTarefa = CreateServiceTarefa();
            var serviceUsuario = CreateServiceUsuario();
            var usuarioSolicitante = serviceUsuario.GetById(int.TryParse(idSolicitante, out int result) ? result : 0);
            if (usuarioSolicitante is not null)
            {
                if (ValidaAcessoUsuario(usuarioSolicitante.NivelUserId, usuarioSolicitante.Id, -1))
                {
                    var tarefas = serviceTarefa.GetAll();
                    return Task.FromResult(_mapper.Map<List<Tarefa>>(tarefas));
                }
                else throw new UsuarioSemPermissaoException(Mensagens.USUARIO_SEM_PERMISSAO);
            }
            throw new UsuarioNaoCadastradoException(Mensagens.USUARIO_NAO_CADASTRADO);
        }

        private bool ValidaAcessoUsuario(int nivelUsuario, int idSolicitante, int idUsuarioTarefa)
        {
            if (nivelUsuario == NivelConstants.ADMINISTRADOR || idSolicitante == idUsuarioTarefa)
                return true;

            return false;
        }
    }
}
