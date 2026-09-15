using SuperTrunfo.Core.Enums;
using SuperTrunfo.Core.Exceptions;

namespace SuperTrunfo.Core.Services;

public static class ValidadorEntrada
{
    public static Atributo ConverterAtributo(string? entrada)
    {
        if (!int.TryParse(entrada, out int opcao) || !Enum.IsDefined(typeof(Atributo), opcao))
            throw new OpcaoInvalidaException("Escolha uma opção entre 1 e 5.");

        return (Atributo)opcao;
    }
}
