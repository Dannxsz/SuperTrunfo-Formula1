using SuperTrunfo.Core.Exceptions;

namespace SuperTrunfo.Core.Models;

public class Jogador
{
    private readonly Queue<Carta> _cartas = new();

    public string Nome { get; }
    public int QuantidadeCartas => _cartas.Count;
    public bool PossuiCartas => _cartas.Count > 0;

    public Jogador(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do jogador é obrigatório.", nameof(nome));

        Nome = nome;
    }

    public void ReceberCarta(Carta carta)
    {
        ArgumentNullException.ThrowIfNull(carta);
        _cartas.Enqueue(carta);
    }

    public void ReceberCartas(params Carta[] cartas)
    {
        ArgumentNullException.ThrowIfNull(cartas);

        foreach (var carta in cartas)
            ReceberCarta(carta);
    }

    public Carta EspiarCarta()
    {
        if (!PossuiCartas)
            throw new SemCartasException($"{Nome} não possui cartas.");

        return _cartas.Peek();
    }

    public Carta JogarCarta()
    {
        if (!PossuiCartas)
            throw new SemCartasException($"{Nome} não possui cartas para jogar.");

        return _cartas.Dequeue();
    }
}
