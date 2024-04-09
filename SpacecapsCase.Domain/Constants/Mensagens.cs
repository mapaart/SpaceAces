namespace SpacecapsCase.Domain.Constants
{
    public class Mensagens
    {
        public static string USUARIO_SEM_PERMISSAO = "Usuário informado não é um administrador e por isso não possui acesso a essa funcionalidade.";
        public static string USUARIO_JA_CADASTRADO = "Nome de usuário já cadastrado no sistema.";
        public static string USUARIO_NAO_CADASTRADO = "Usuário informado não é cadastrado no sistema.";
        public static string SENHA_INCORRETA = "Senha incorreta para o usuário informado.";
        public static string HEADER_ID_SOLICITANTE = "O header IdSolicitante e obrigatório.";
        public static string TAREFA_NAO_ENCONTRADA = "O ID da tarefa informado não foi encontrado no sistema.";
        public static string NIVEL_USUARIO_INVALIDO = "O sistema apenas comporta niveis de usuario 1 - Administrador e 2 - Comum. O nível informado é inválido.";
    }
}
