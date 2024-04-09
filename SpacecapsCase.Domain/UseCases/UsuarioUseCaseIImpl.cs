using SpacecapsCase.Domain.Interfaces;
using SpacecapsCase.Domain.Constants;
using SpacecapsCase.Domain.Dto;
using SpacecapsCase.Application.Services;
using SpacecapsCase.Infrastructure.Data.Context;
using SpacecapsCase.Infrastructure.Data.Repositories;
using AutoMapper;
using SpacecapsCase.Infrastructure.Data.Entity;
using SpacecapsCase.Domain.Exception;

namespace SpacecapsCase.Domain.UseCases
{
    public class UsuarioUseCaseIImpl : IUsuarioUseCase
    {
        private readonly IMapper _mapper;

        public UsuarioUseCaseIImpl(IMapper mapper)
        {
            _mapper = mapper;
        }

        UsuarioService CreateService()
        {
            DatabaseContext db = new DatabaseContext();
            UsuarioRepository repository = new UsuarioRepository(db);
            UsuarioService service = new UsuarioService(repository);
            return service;
        }
        public Task<Usuario> CriarUsuario(Usuario usuario)
        {
            var service = CreateService();
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            var usarioEntity = _mapper.Map<UsuarioEntity>(usuario);
            if (ValidaUsuarioCriado(service, usarioEntity))
            {
                throw new UsuarioCadastradoException(Mensagens.USUARIO_JA_CADASTRADO);
            }
            if (!ValidaNivelValidoUsuario(usuario.NivelUserId))
                throw new NivelInvalidadoUsuarioException(Mensagens.NIVEL_USUARIO_INVALIDO);
            var usuarioCriado = service.Add(usarioEntity);
            return Task.FromResult(_mapper.Map<Usuario>(usuarioCriado));
        }

        public Task<List<Usuario>> ListUsuarios(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario>? ObterUsuario(int id, string idSolicitante)
        {
            int idSolicitador = int.TryParse(idSolicitante, out int result) ? result : 0;
            var service = CreateService();
            var usuarioSolicitante = _mapper.Map<Usuario>(service.GetById(idSolicitador));
            if (usuarioSolicitante is not null && ValidaAdmin(usuarioSolicitante.NivelUserId))
                return Task.FromResult(_mapper.Map<Usuario>(service.GetById(id)));
            else throw new UsuarioSemPermissaoException(Mensagens.USUARIO_SEM_PERMISSAO);
        }

        public Task<List<Usuario>>? ListUsuarios(string idSolicitante)
        {
            int idSolicitador = int.TryParse(idSolicitante, out int result) ? result : 0;
            var service = CreateService();
            var usuarioSolicitante = _mapper.Map<Usuario>(service.GetById(idSolicitador));
            if (usuarioSolicitante is not null && ValidaAdmin(usuarioSolicitante.NivelUserId))
                return Task.FromResult(_mapper.Map<List<Usuario>>(service.GetAll()));
            else throw new UsuarioSemPermissaoException(Mensagens.USUARIO_SEM_PERMISSAO);

        }

        private bool ValidaAdmin(int nivel)
        {
            return nivel == NivelConstants.ADMINISTRADOR;
        }

        private bool ValidaUsuarioCriado(UsuarioService service, UsuarioEntity entity)
        {
            var usuario = service.GetByName(entity.Nome);
            return usuario is not null;
        }

        private bool ValidaNivelValidoUsuario(int nivel)
        {
            if(NivelConstants.COMUM.Equals(nivel) || NivelConstants.ADMINISTRADOR.Equals(nivel)) { return true; }
            
            return false;
        }
    }
}
