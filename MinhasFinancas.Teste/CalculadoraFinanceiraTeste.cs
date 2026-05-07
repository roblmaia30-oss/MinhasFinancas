using MinhasFinancas.Dominio.Servicos;
using MinhasFinancas.Dominio.Entidades;
using Xunit;

namespace MinhasFinancas.Testes.Dominio;

public class CalculadoraFinanceiraTeste
{
    [Fact]
    public void Saldo_Disponivel_Deve_Descontar_Fatura_Dos_Cartoes()
    {
        var contaInter = new Conta("Inter", 1000m);
        var contaCaixaBia = new Conta("Caixa Bia", 500m);
        // Arrange
        var contas = new List<Conta>
        {
            contaInter,
            contaCaixaBia
        };

        var cartaoRobInter = new CartaoCredito ("Rob Inter", 10000m);
        cartaoRobInter.AdicionarDespesa(100m);
        cartaoRobInter.AdicionarDespesa(50m);
        cartaoRobInter.AdicionarDespesa(50m);
        var cartaoLeroyMerlin = new CartaoCredito ("Leroy Merlin", 500m);
        cartaoLeroyMerlin.AdicionarDespesa(20m);
        cartaoLeroyMerlin.AdicionarDespesa(30m);
        cartaoLeroyMerlin.AdicionarDespesa(50m);

        var cartoes = new List<CartaoCredito>
        {
            cartaoRobInter,
            cartaoLeroyMerlin
        };

        // Act
        decimal saldoDisponivel = CalculadoraFinanceira.CalcularSaldoDisponivelParaGastar(contas, cartoes);

        // Assert
        Assert.Equal(1200m, saldoDisponivel);
    }
}