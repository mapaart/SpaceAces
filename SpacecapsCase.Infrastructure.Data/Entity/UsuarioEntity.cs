namespace SpacecapsCase.Infrastructure.Data.Entity
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public int NivelUserId { get; set; }    
    }
}
