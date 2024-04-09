﻿using System.Text.Json.Serialization;

namespace SpacecapsCase.Domain.Dto
{
    public class Usuario
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int NivelUserId { get; set; }

    }
}
