using SuperTrunfo.Core.Enums;
using SuperTrunfo.Core.Exceptions;
using SuperTrunfo.Core.Services;

namespace SuperTrunfo.Tests;

public class ValidadorEntradaTests
{
    [Theory]
    [InlineData("1", Atributo.Vitorias)]
    [InlineData("5", Atributo.TempoMedioPitStop)]
    public void ConverterAtributo_QuandoEntradaValida_DeveRetornarEnum(string entrada, Atributo esperado)
    {
        Atributo resultado = ValidadorEntrada.ConverterAtributo(entrada);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("6")]
    [InlineData("abc")]
    public void ConverterAtributo_QuandoEntradaInvalida_DeveLancarOpcaoInvalidaException(string entrada)
    {
        Assert.Throws<OpcaoInvalidaException>(() => ValidadorEntrada.ConverterAtributo(entrada));
    }
}
