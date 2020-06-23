using System;

namespace RankingPatataios.Models
{
    public class JogoJogador : Entidade
    {
        public Guid JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public Guid JogadorId { get; set; }
        public Jogador Jogador { get; set; }
    }
}
