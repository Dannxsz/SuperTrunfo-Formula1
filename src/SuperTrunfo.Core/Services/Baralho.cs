using SuperTrunfo.Core.Models;

namespace SuperTrunfo.Core.Services;

public class Baralho
{
    private readonly List<Carta> _cartas;

    public int Quantidade => _cartas.Count;
    public IReadOnlyList<Carta> Cartas => _cartas.AsReadOnly();

    public Baralho(IEnumerable<Carta> cartas)
    {
        ArgumentNullException.ThrowIfNull(cartas);
        _cartas = cartas.ToList();

        if (_cartas.Count < 2)
            throw new ArgumentException("O baralho precisa possuir pelo menos duas cartas.", nameof(cartas));
    }

    public void Embaralhar(Random? random = null)
    {
        random ??= Random.Shared;

        for (int i = _cartas.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (_cartas[i], _cartas[j]) = (_cartas[j], _cartas[i]);
        }
    }

    public void Distribuir(Jogador jogador1, Jogador jogador2)
    {
        ArgumentNullException.ThrowIfNull(jogador1);
        ArgumentNullException.ThrowIfNull(jogador2);

        for (int i = 0; i < _cartas.Count; i++)
        {
            if (i % 2 == 0)
                jogador1.ReceberCarta(_cartas[i]);
            else
                jogador2.ReceberCarta(_cartas[i]);
        }
    }

    public static Baralho CriarPadrao()
    {
        // Dados didáticos e aproximados para fins acadêmicos.
        return new Baralho(new[]
        {
            new Carta("Ayrton Senna", "McLaren", 41, 80, 65, 3, 2.35),
            new Carta("Lewis Hamilton", "Mercedes", 105, 202, 104, 7, 2.42),
            new Carta("Michael Schumacher", "Ferrari", 91, 155, 68, 7, 2.55),
            new Carta("Max Verstappen", "Red Bull Racing", 63, 112, 40, 4, 2.30),
            new Carta("Sebastian Vettel", "Red Bull Racing", 53, 122, 57, 4, 2.48),
            new Carta("Alain Prost", "McLaren", 51, 106, 33, 4, 2.61),
            new Carta("Fernando Alonso", "Renault", 32, 106, 22, 2, 2.70),
            new Carta("Niki Lauda", "Ferrari", 25, 54, 24, 3, 2.80),
            new Carta("Nelson Piquet", "Brabham", 23, 60, 24, 3, 2.76),
            new Carta("Kimi Räikkönen", "Ferrari", 21, 103, 18, 1, 2.66),
            new Carta("Mika Häkkinen", "McLaren", 20, 51, 26, 2, 2.58),
            new Carta("Jenson Button", "Brawn GP", 15, 50, 8, 1, 2.73),
            new Carta("Charles Leclerc", "Ferrari", 8, 43, 26, 0, 2.40),
            new Carta("Lando Norris", "McLaren", 7, 35, 10, 0, 2.32),
            new Carta("Rubens Barrichello", "Ferrari", 11, 68, 14, 0, 2.64),
            new Carta("Felipe Massa", "Ferrari", 11, 41, 16, 0, 2.68)
        });
    }
}
