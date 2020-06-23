using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankingPatataios.Migrations
{
    public partial class Criatabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Apelido = table.Column<string>(maxLength: 15, nullable: false),
                    NomeCompleto = table.Column<string>(maxLength: 50, nullable: false),
                    Celular = table.Column<string>(maxLength: 18, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Empunhadura = table.Column<string>(nullable: false),
                    Backhand = table.Column<string>(nullable: false),
                    Altura = table.Column<decimal>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Torneios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rodadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(maxLength: 30, nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TorneioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rodadas_Torneios_TorneioId",
                        column: x => x.TorneioId,
                        principalTable: "Torneios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    SetsGanhosJogador1 = table.Column<int>(nullable: false),
                    SetsGanhosJogador2 = table.Column<int>(nullable: false),
                    Testemunha = table.Column<string>(maxLength: 20, nullable: true),
                    RodadaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Rodadas_RodadaId",
                        column: x => x.RodadaId,
                        principalTable: "Rodadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JogosJogadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    JogoId = table.Column<Guid>(nullable: false),
                    JogadorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogosJogadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogosJogadores_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogosJogadores_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    GamesGanhosJogador1 = table.Column<int>(nullable: false),
                    GamesGanhosJogador2 = table.Column<int>(nullable: false),
                    TieBreakJogador1 = table.Column<int>(nullable: false),
                    TieBreakJogador2 = table.Column<int>(nullable: false),
                    JogoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_RodadaId",
                table: "Jogos",
                column: "RodadaId");

            migrationBuilder.CreateIndex(
                name: "IX_JogosJogadores_JogadorId",
                table: "JogosJogadores",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_JogosJogadores_JogoId",
                table: "JogosJogadores",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Rodadas_TorneioId",
                table: "Rodadas",
                column: "TorneioId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_JogoId",
                table: "Sets",
                column: "JogoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogosJogadores");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Rodadas");

            migrationBuilder.DropTable(
                name: "Torneios");
        }
    }
}
