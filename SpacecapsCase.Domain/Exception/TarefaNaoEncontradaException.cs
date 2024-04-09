
namespace SpacecapsCase.Domain.Exception
{
    public class TarefaNaoEncontradaException : System.Exception
    {
        public TarefaNaoEncontradaException() { }
        public TarefaNaoEncontradaException(string mensagem) : base(mensagem) { }
    }
}
