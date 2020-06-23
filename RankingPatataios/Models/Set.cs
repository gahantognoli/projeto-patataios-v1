using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RankingPatataios.Models
{
    [Table("Sets")]
    public class Set : Entidade
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int GamesGanhosJogador1 { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int GamesGanhosJogador2 { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TieBreakJogador1 { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TieBreakJogador2 { get; set; }
        public Guid JogoId { get; set; }

        public virtual Jogo Jogo { get; set; }
    }
}
