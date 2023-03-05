using System.Numerics;

namespace base_api_aspNet.Models.Dtos
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public DateTime? Data { get; set; }
        public int? Altura { get; set; }
        public DateTime? Criado_em { get; set; }
       // public ICollection<BigInteger>? Array { get; set; }
    }
}
