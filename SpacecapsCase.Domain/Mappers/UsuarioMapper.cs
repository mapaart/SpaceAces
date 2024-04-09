using AutoMapper;
using SpacecapsCase.Domain.Dto;
using SpacecapsCase.Infrastructure.Data.Entity;

namespace SpacecapsCase.Domain.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioEntity>(); // Mapeamento de Usuario para UsuarioEntity
            CreateMap<UsuarioEntity, Usuario>(); // Mapeamento de UsuarioEntity para Usuario
        }
    }
}
