using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RankingPatataios.Models
{
    [Table("Jogos")]
    public class Jogo : Entidade
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int SetsGanhosJogador1 { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int SetsGanhosJogador2 { get; set; }

        [StringLength(20, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string Testemunha { get; set; }
        public Guid RodadaId { get; set; }

        public virtual ICollection<JogoJogador> JogoJogadores { get; set; }
        public virtual Rodada Rodada { get; set; }
        public virtual ICollection<Set> Sets { get; set; }
    }
}
