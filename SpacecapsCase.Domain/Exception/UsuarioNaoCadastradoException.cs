
namespace SpacecapsCase.Domain.Exception
{
    public class UsuarioNaoCadastradoException : System.Exception
    {
        public UsuarioNaoCadastradoException() { }
        public UsuarioNaoCadastradoException(string mensagem) : base(mensagem) { }
    }
}
