using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RankingPatataios.Models
{
    [Table("Jogadores")]
    public class Jogador : Entidade
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(18, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(40, ErrorMessage = "Taminho máximo de {0} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public char Empunhadura { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public char Backhand { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Altura { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Status { get; set; }

        public virtual ICollection<JogoJogador> JogoJogadores { get; set; }
    }
}
