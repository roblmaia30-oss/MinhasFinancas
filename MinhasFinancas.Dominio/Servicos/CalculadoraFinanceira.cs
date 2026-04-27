using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Dominio.Servicos;

public class CalculadoraFinanceira
{
    public static decimal CalcularSaldoDisponivelParaGastar(List<Conta> contas, List<CartaoCredito> cartoes)
    {
        decimal dinheiroNasContas = contas.Sum(c => c.Saldo);
        decimal dividaDosCartoes = cartoes.Sum(c => c.FaturaAtual);
        
        return dinheiroNasContas - dividaDosCartoes;
    }

    public static decimal CalcularPatrimonioTotal(List<Conta> contas, List<Investimento> investimentos, List<CartaoCredito> cartoes)
    {
        decimal total = contas.Sum(c => c.Saldo) + investimentos.Sum(i => i.Saldo);
        return total - cartoes.Sum(c => c.FaturaAtual);
    }
}