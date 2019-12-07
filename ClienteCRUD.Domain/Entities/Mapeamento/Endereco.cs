using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteCRUD.Domain.Entities.Mapeamento
{
    [Table("Endereco")]
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
