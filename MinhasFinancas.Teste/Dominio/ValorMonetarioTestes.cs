using MinhasFinancas.Dominio.ObjetosValor;
using Xunit; // A biblioteca de testes que vamos usar

namespace MinhasFinancas.Testes.Dominio;

public class ValorMonetarioTestes
{
    // O [Fact] diz ao C# que este método é um teste que deve ser executado
    [Fact]
    public void Deve_Criar_Valor_Quando_For_Positivo()
    {
        // 1. Arrange (Organizar)
        decimal valorEsperado = 100.50m;

        // 2. Act (Agir)
        var valorMonetario = new ValorMonetario(valorEsperado);

        // 3. Assert (Verificar)
        Assert.Equal(valorEsperado, (decimal)valorMonetario);
    }

    [Fact]
    public void Deve_Lancar_Erro_Quando_Valor_For_Negativo()
    {
        // Arrange
        decimal valorInvalido = -10m;

        // Act & Assert (Neste caso, o Act e o Assert acontecem juntos)
        // Estamos verificando se o sistema "explode" com a exceção correta
        Assert.Throws<ArgumentException>(() => new ValorMonetario(valorInvalido));
    }
}