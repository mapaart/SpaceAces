
namespace SpacecapsCase.Domain.Exception
{
    public class UsuarioSemPermissaoException : System.Exception
    {
        public UsuarioSemPermissaoException() { }
        public UsuarioSemPermissaoException(string message) : base(message) { }
    }
}
