using SuperTrunfo.Core.Enums;

namespace SuperTrunfo.Core.Models;

public class Carta
{
    public string Piloto { get; }
    public string Equipe { get; }
    public int Vitorias { get; }
    public int Podios { get; }
    public int PolePositions { get; }
    public int TitulosMundiais { get; }
    public double TempoMedioPitStop { get; }

    public Carta(
        string piloto,
        string equipe,
        int vitorias,
        int podios,
        int polePositions,
        int titulosMundiais,
        double tempoMedioPitStop)
    {
        if (string.IsNullOrWhiteSpace(piloto))
            throw new ArgumentException("O nome do piloto é obrigatório.", nameof(piloto));

        if (string.IsNullOrWhiteSpace(equipe))
            throw new ArgumentException("O nome da equipe é obrigatório.", nameof(equipe));

        if (vitorias < 0 || podios < 0 || polePositions < 0 || titulosMundiais < 0 || tempoMedioPitStop <= 0)
            throw new ArgumentOutOfRangeException(nameof(vitorias), "Os atributos numéricos precisam ser válidos.");

        Piloto = piloto;
        Equipe = equipe;
        Vitorias = vitorias;
        Podios = podios;
        PolePositions = polePositions;
        TitulosMundiais = titulosMundiais;
        TempoMedioPitStop = tempoMedioPitStop;
    }

    public double ObterValor(Atributo atributo)
    {
        return atributo switch
        {
            Atributo.Vitorias => Vitorias,
            Atributo.Podios => Podios,
            Atributo.PolePositions => PolePositions,
            Atributo.TitulosMundiais => TitulosMundiais,
            Atributo.TempoMedioPitStop => TempoMedioPitStop,
            _ => throw new ArgumentOutOfRangeException(nameof(atributo), "Atributo inválido.")
        };
    }

    public int CompararCom(Carta outra, Atributo atributo)
    {
        ArgumentNullException.ThrowIfNull(outra);

        double meuValor = ObterValor(atributo);
        double outroValor = outra.ObterValor(atributo);

        // No pit stop, o menor tempo é melhor.
        if (atributo == Atributo.TempoMedioPitStop)
            return outroValor.CompareTo(meuValor);

        // Nos demais atributos, o maior valor é melhor.
        return meuValor.CompareTo(outroValor);
    }

    public override string ToString()
    {
        return $"{Piloto} - {Equipe} | Vitórias: {Vitorias} | Pódios: {Podios} | Poles: {PolePositions} | " +
               $"Títulos: {TitulosMundiais} | Pit stop médio: {TempoMedioPitStop:0.00}s";
    }
}
