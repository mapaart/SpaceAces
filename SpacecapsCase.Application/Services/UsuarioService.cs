using SpacecapsCase.Application.Interfaces;
using SpacecapsCase.Infrastructure.Data.Entity;
using SpacecapsCase.Infrastructure.Data.Interfaces.Repositories;

namespace SpacecapsCase.Application.Services
{
    public class UsuarioService : IUsuarioService<UsuarioEntity, int>
    {
        private readonly IBaseRepository<UsuarioEntity, int> usuarioRepository;

        public UsuarioService(IBaseRepository<UsuarioEntity, int> _usuarioRepository)
        {
            this.usuarioRepository = _usuarioRepository;
        }

        public UsuarioEntity Add(UsuarioEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("O usuário é obrigatório.");

            var result = usuarioRepository.Add(entity);
            usuarioRepository.SaveAll();
            return result;
        }

        public List<UsuarioEntity> GetAll()
        {
            return usuarioRepository.GetAll();
        }

        public UsuarioEntity GetById(int entityId)
        {
            return usuarioRepository.GetById(entityId);
        }

        public UsuarioEntity GetByName(string nome)
        {
            return usuarioRepository.GetByName(nome);
        }
    }
}