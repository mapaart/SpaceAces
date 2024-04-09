using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacecapsCase.Domain.Dto;

namespace SpacecapsCase.Domain.Interfaces
{
    public interface IUsuarioUseCase
    {
        Task<Usuario> CriarUsuario(Usuario usuario);
        Task<Usuario>? ObterUsuario(int id, string idSolicitante);
        Task<List<Usuario>>? ListUsuarios(string idSolicitante);
    }
}
