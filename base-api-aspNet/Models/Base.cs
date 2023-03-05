using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace base_api_aspNet.Models
{
    public class Base
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo de Nome é obrigatorio!")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "A Idade é obrigatorio!")]
        [Range(1, 100, ErrorMessage = "Quantidade da idade deve estar entre 1 e 100")]
        public int? Idade { get; set; }

        public DateTime? Data { get; set; }


        [Range(1, 200, ErrorMessage = "Altura deve estar entreo 1 e 200 cm")]
        public int? Altura { get; set; }

        [JsonIgnore]
        public DateTime? Criado_em { get; set; }
        //public ICollection<BigInteger>? Array { get; set; }

        public string Formatar()
        {
            return "texto";
        }
    }
}
