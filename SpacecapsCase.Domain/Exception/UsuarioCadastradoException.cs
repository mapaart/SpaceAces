using System;

namespace SpacecapsCase.Domain.Exception
{
    public class UsuarioCadastradoException : System.Exception
    {
        public UsuarioCadastradoException() { }
        public UsuarioCadastradoException(string mensagem) : base(mensagem) { }
    }
}
