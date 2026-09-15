using SuperTrunfo.Core.Enums;
using SuperTrunfo.Core.Exceptions;
using SuperTrunfo.Core.Models;

namespace SuperTrunfo.Core.Services;

public class JogoSuperTrunfo
{
    public Jogador Jogador1 { get; }
    public Jogador Jogador2 { get; }
    public int NumeroRodada { get; private set; }

    public bool Finalizado => !Jogador1.PossuiCartas || !Jogador2.PossuiCartas;

    public JogoSuperTrunfo(Jogador jogador1, Jogador jogador2)
    {
        Jogador1 = jogador1 ?? throw new ArgumentNullException(nameof(jogador1));
        Jogador2 = jogador2 ?? throw new ArgumentNullException(nameof(jogador2));
    }

    public ResultadoRodada JogarRodada(Atributo atributo)
    {
        if (Finalizado)
            throw new SemCartasException("Não é possível iniciar outra rodada porque um dos jogadores está sem cartas.");

        Carta carta1 = Jogador1.JogarCarta();
        Carta carta2 = Jogador2.JogarCarta();
        int comparacao = carta1.CompararCom(carta2, atributo);

        VencedorRodada vencedor;

        if (comparacao > 0)
        {
            Jogador1.ReceberCartas(carta1, carta2);
            vencedor = VencedorRodada.Jogador1;
        }
        else if (comparacao < 0)
        {
            Jogador2.ReceberCartas(carta2, carta1);
            vencedor = VencedorRodada.Jogador2;
        }
        else
        {
            Jogador1.ReceberCarta(carta1);
            Jogador2.ReceberCarta(carta2);
            vencedor = VencedorRodada.Empate;
        }

        NumeroRodada++;
        return new ResultadoRodada(carta1, carta2, atributo, vencedor);
    }

    public Jogador? ObterVencedorFinal()
    {
        if (!Finalizado)
            return null;

        if (Jogador1.PossuiCartas)
            return Jogador1;

        if (Jogador2.PossuiCartas)
            return Jogador2;

        return null;
    }
}
