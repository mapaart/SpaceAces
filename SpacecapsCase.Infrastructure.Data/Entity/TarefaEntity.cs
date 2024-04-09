namespace SpacecapsCase.Infrastructure.Data.Entity
{
    public class TarefaEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int UsuarioId { get; set; }
    }
}
