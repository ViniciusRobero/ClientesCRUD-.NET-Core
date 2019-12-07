using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteCRUD.Domain.Entities.Mapeamento
{
    [Table("Cliente")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
