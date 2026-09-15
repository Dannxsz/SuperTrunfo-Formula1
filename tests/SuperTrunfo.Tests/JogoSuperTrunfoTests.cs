using SuperTrunfo.Core.Enums;
using SuperTrunfo.Core.Exceptions;
using SuperTrunfo.Core.Models;
using SuperTrunfo.Core.Services;

namespace SuperTrunfo.Tests;

public class JogoSuperTrunfoTests
{
    [Fact]
    public void JogarRodada_QuandoJogador1Vence_DeveReceberDuasCartas()
    {
        var jogador1 = new Jogador("Daniel");
        var jogador2 = new Jogador("CPU");
        jogador1.ReceberCarta(new Carta("Piloto Forte", "Equipe A", 30, 50, 20, 2, 2.50));
        jogador2.ReceberCarta(new Carta("Piloto Fraco", "Equipe B", 10, 20, 5, 0, 2.20));
        var jogo = new JogoSuperTrunfo(jogador1, jogador2);

        ResultadoRodada resultado = jogo.JogarRodada(Atributo.Vitorias);

        Assert.Equal(VencedorRodada.Jogador1, resultado.Vencedor);
        Assert.Equal(2, jogador1.QuantidadeCartas);
        Assert.Equal(0, jogador2.QuantidadeCartas);
    }

    [Fact]
    public void JogarRodada_QuandoEmpata_DeveManterUmaCartaParaCadaJogador()
    {
        var jogador1 = new Jogador("Daniel");
        var jogador2 = new Jogador("CPU");
        jogador1.ReceberCarta(new Carta("Piloto A", "Equipe A", 10, 20, 5, 0, 2.50));
        jogador2.ReceberCarta(new Carta("Piloto B", "Equipe B", 10, 22, 7, 0, 2.60));
        var jogo = new JogoSuperTrunfo(jogador1, jogador2);

        ResultadoRodada resultado = jogo.JogarRodada(Atributo.Vitorias);

        Assert.Equal(VencedorRodada.Empate, resultado.Vencedor);
        Assert.Equal(1, jogador1.QuantidadeCartas);
        Assert.Equal(1, jogador2.QuantidadeCartas);
    }

    [Fact]
    public void JogarRodada_QuandoJogoFinalizado_DeveLancarSemCartasException()
    {
        var jogador1 = new Jogador("Daniel");
        var jogador2 = new Jogador("CPU");
        var jogo = new JogoSuperTrunfo(jogador1, jogador2);

        Assert.Throws<SemCartasException>(() => jogo.JogarRodada(Atributo.Vitorias));
    }
}
