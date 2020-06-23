using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RankingPatataios.Models
{
    [Table("Rodadas")]
    public class Rodada : Entidade
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Status { get; set; }
        public Guid TorneioId { get; set; }

        public virtual Torneio Torneio { get; set; }
        public virtual ICollection<Jogo> Jogos { get; set; }
    }
}
