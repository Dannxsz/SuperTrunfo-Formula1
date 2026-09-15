using SuperTrunfo.Core.Models;
using SuperTrunfo.Core.Services;

namespace SuperTrunfo.Tests;

public class BaralhoTests
{
    [Fact]
    public void CriarPadrao_DeveCriarBaralhoComDezesseisCartas()
    {
        Baralho baralho = Baralho.CriarPadrao();

        Assert.Equal(16, baralho.Quantidade);
    }

    [Fact]
    public void Distribuir_DeveDividirCartasEntreDoisJogadores()
    {
        Baralho baralho = Baralho.CriarPadrao();
        var jogador1 = new Jogador("Daniel");
        var jogador2 = new Jogador("CPU");

        baralho.Distribuir(jogador1, jogador2);

        Assert.Equal(8, jogador1.QuantidadeCartas);
        Assert.Equal(8, jogador2.QuantidadeCartas);
    }

    [Fact]
    public void Construtor_QuandoTemMenosDeDuasCartas_DeveLancarExcecao()
    {
        var carta = new Carta("Piloto", "Equipe", 1, 1, 1, 0, 2.5);

        Assert.Throws<ArgumentException>(() => new Baralho(new[] { carta }));
    }
}
