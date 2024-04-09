using SpacecapsCase.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacecapsCase.Domain.Interfaces
{
    public interface ITarefaUseCase
    {
        Task<Tarefa> CriarTarefa(Tarefa tarefa, string idSolicitante);
        Task DeletarTarefa(int idTarefa, string idSolicitante);
        Task<Tarefa> AtualizarTarefa(Tarefa tarefa, string idSolicitante);
        Task<Tarefa> ConsultarTarefa(int id, string idSolicitante);
        Task<List<Tarefa>> TarefaList(string idSolicitante);
    }
}
