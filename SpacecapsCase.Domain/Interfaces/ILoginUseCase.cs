using SpacecapsCase.Domain.Dto;

namespace SpacecapsCase.Domain.Interfaces
{
    public interface ILoginUseCase
    {
        Task<string> RealizarLogin(Login login);
        string GerarToken(string username);
    }
}
