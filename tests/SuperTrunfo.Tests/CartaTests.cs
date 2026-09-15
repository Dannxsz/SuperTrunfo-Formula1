using SuperTrunfo.Core.Enums;
using SuperTrunfo.Core.Models;

namespace SuperTrunfo.Tests;

public class CartaTests
{
    [Fact]
    public void CompararCom_QuandoMaiorNumeroDeVitorias_DeveVencer()
    {
        var carta1 = new Carta("Piloto A", "Equipe A", 20, 40, 15, 2, 2.40);
        var carta2 = new Carta("Piloto B", "Equipe B", 10, 30, 8, 1, 2.30);

        int resultado = carta1.CompararCom(carta2, Atributo.Vitorias);

        Assert.True(resultado > 0);
    }

    [Fact]
    public void CompararCom_QuandoMenorTempoPitStop_DeveVencer()
    {
        var carta1 = new Carta("Piloto A", "Equipe A", 10, 20, 5, 1, 2.10);
        var carta2 = new Carta("Piloto B", "Equipe B", 10, 20, 5, 1, 2.80);

        int resultado = carta1.CompararCom(carta2, Atributo.TempoMedioPitStop);

        Assert.True(resultado > 0);
    }

    [Fact]
    public void Construtor_QuandoPilotoVazio_DeveLancarArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Carta("", "Equipe", 1, 1, 1, 0, 2.5));
    }
}
