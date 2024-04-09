using System.Text.Json.Serialization;

namespace SpacecapsCase.Domain.Dto
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public DateTime Data { get; set; }
        [JsonIgnore]
        public DateTime DataAtualizacao { get; set; }
        [JsonIgnore]
        public int UsuarioId { get; set; }
    }
}
