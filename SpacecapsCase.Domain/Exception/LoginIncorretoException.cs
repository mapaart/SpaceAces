
namespace SpacecapsCase.Domain.Exception
{
    public class LoginIncorretoException : System.Exception
    {
        public LoginIncorretoException() { }
        public LoginIncorretoException(string mensagem) : base(mensagem) { }
    }
}
