using Microsoft.EntityFrameworkCore;
using RankingPatataios.Models;

namespace RankingPatataios.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Torneio> Torneios { get; set; }
        public DbSet<Rodada> Rodadas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<JogoJogador> JogosJogadores { get; set; }
        public DbSet<Set> Sets { get; set; }
    }
}
