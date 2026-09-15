using SuperTrunfo.Core.Enums;
using SuperTrunfo.Core.Exceptions;
using SuperTrunfo.Core.Models;
using SuperTrunfo.Core.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("======================================");
Console.WriteLine("      SUPER TRUNFO - FÓRMULA 1");
Console.WriteLine("======================================");
Console.WriteLine("Tema: pilotos e equipes da Fórmula 1");
Console.WriteLine();

try
{
    string nome1 = LerNome("Nome do Jogador 1: ", "Jogador 1");
    string nome2 = LerNome("Nome do Jogador 2: ", "Jogador 2");

    var jogador1 = new Jogador(nome1);
    var jogador2 = new Jogador(nome2);

    Baralho baralho = Baralho.CriarPadrao();
    baralho.Embaralhar();
    baralho.Distribuir(jogador1, jogador2);

    var jogo = new JogoSuperTrunfo(jogador1, jogador2);

    while (!jogo.Finalizado && jogo.NumeroRodada < 30)
    {
        Console.WriteLine();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"Rodada {jogo.NumeroRodada + 1}");
        Console.WriteLine($"{jogador1.Nome}: {jogador1.QuantidadeCartas} cartas | {jogador2.Nome}: {jogador2.QuantidadeCartas} cartas");
        Console.WriteLine();
        Console.WriteLine($"Carta de {jogador1.Nome}:");
        Console.WriteLine(jogador1.EspiarCarta());

        ExibirMenuAtributos();
        Console.Write("Escolha o atributo para comparar: ");
        string? entrada = Console.ReadLine();

        try
        {
            Atributo atributo = ValidadorEntrada.ConverterAtributo(entrada);
            ResultadoRodada resultado = jogo.JogarRodada(atributo);
            ExibirResultado(resultado, jogador1, jogador2);
        }
        catch (OpcaoInvalidaException ex)
        {
            Console.WriteLine($"Erro de entrada: {ex.Message}");
            Console.WriteLine("A rodada não foi executada. Tente novamente.");
        }
    }

    Console.WriteLine();
    Console.WriteLine("======================================");
    Console.WriteLine("              FIM DO JOGO");
    Console.WriteLine("======================================");

    Jogador? vencedorFinal = jogo.ObterVencedorFinal();

    if (vencedorFinal is not null)
    {
        Console.WriteLine($"Vencedor final: {vencedorFinal.Nome}");
    }
    else
    {
        Console.WriteLine("O jogo foi encerrado pelo limite de 30 rodadas para facilitar a apresentação.");

        if (jogador1.QuantidadeCartas > jogador2.QuantidadeCartas)
            Console.WriteLine($"Líder por quantidade de cartas: {jogador1.Nome}");
        else if (jogador2.QuantidadeCartas > jogador1.QuantidadeCartas)
            Console.WriteLine($"Líder por quantidade de cartas: {jogador2.Nome}");
        else
            Console.WriteLine("Os jogadores terminaram empatados em quantidade de cartas.");
    }
}
catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine("Ocorreu um erro inesperado na aplicação.");
    Console.WriteLine(ex.Message);
}

static string LerNome(string mensagem, string nomePadrao)
{
    Console.Write(mensagem);
    string? nome = Console.ReadLine();
    return string.IsNullOrWhiteSpace(nome) ? nomePadrao : nome.Trim();
}

static void ExibirMenuAtributos()
{
    Console.WriteLine();
    Console.WriteLine("Atributos:");
    Console.WriteLine("1 - Vitórias");
    Console.WriteLine("2 - Pódios");
    Console.WriteLine("3 - Pole positions");
    Console.WriteLine("4 - Títulos mundiais");
    Console.WriteLine("5 - Tempo médio de pit stop (menor vence)");
}

static void ExibirResultado(ResultadoRodada resultado, Jogador jogador1, Jogador jogador2)
{
    Console.WriteLine();
    Console.WriteLine($"Carta de {jogador1.Nome}:");
    Console.WriteLine(resultado.CartaJogador1);

    Console.WriteLine();
    Console.WriteLine($"Carta de {jogador2.Nome}:");
    Console.WriteLine(resultado.CartaJogador2);

    Console.WriteLine();
    Console.WriteLine($"Atributo escolhido: {resultado.AtributoEscolhido}");

    switch (resultado.Vencedor)
    {
        case VencedorRodada.Jogador1:
            Console.WriteLine($"Vencedor da rodada: {jogador1.Nome}");
            break;
        case VencedorRodada.Jogador2:
            Console.WriteLine($"Vencedor da rodada: {jogador2.Nome}");
            break;
        default:
            Console.WriteLine("Resultado: empate");
            break;
    }
}
