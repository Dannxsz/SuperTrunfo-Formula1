using SuperTrunfo.Core.Enums;

namespace SuperTrunfo.Core.Models;

public class ResultadoRodada
{
    public Carta CartaJogador1 { get; }
    public Carta CartaJogador2 { get; }
    public Atributo AtributoEscolhido { get; }
    public VencedorRodada Vencedor { get; }

    public ResultadoRodada(Carta cartaJogador1, Carta cartaJogador2, Atributo atributoEscolhido, VencedorRodada vencedor)
    {
        CartaJogador1 = cartaJogador1;
        CartaJogador2 = cartaJogador2;
        AtributoEscolhido = atributoEscolhido;
        Vencedor = vencedor;
    }
}
