using AutoMapper;
using SpacecapsCase.Domain.Dto;
using SpacecapsCase.Infrastructure.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacecapsCase.Domain.Mappers
{
    public class TarefaMapper : Profile
    {
        public TarefaMapper()
        {
            CreateMap<Tarefa, TarefaEntity>(); // Mapeamento de Usuario para UsuarioEntity
            CreateMap<TarefaEntity, Tarefa>(); // Mapeamento de UsuarioEntity para Usuario}
        }
    }
}
