using SuperTrunfo.Core.Exceptions;
using SuperTrunfo.Core.Models;

namespace SuperTrunfo.Tests;

public class JogadorTests
{
    [Fact]
    public void JogarCarta_QuandoJogadorPossuiCarta_DeveRemoverCartaDaFila()
    {
        var jogador = new Jogador("Daniel");
        var carta = new Carta("Piloto", "Equipe", 1, 1, 1, 0, 2.5);
        jogador.ReceberCarta(carta);

        Carta cartaJogada = jogador.JogarCarta();

        Assert.Equal(carta, cartaJogada);
        Assert.False(jogador.PossuiCartas);
    }

    [Fact]
    public void JogarCarta_QuandoJogadorNaoPossuiCarta_DeveLancarSemCartasException()
    {
        var jogador = new Jogador("Daniel");

        Assert.Throws<SemCartasException>(() => jogador.JogarCarta());
    }
}
