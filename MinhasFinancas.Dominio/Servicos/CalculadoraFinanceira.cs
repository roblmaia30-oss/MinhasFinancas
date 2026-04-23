using MinhasFinancas.Dominio.Entidades;
using System.Linq;

namespace MinhasFinancas.Dominio.Servicos;

public class CalculadoraFinanceira
{
    public static decimal CalcularSaldoDisponivelReal(List<Conta> contas, List<CartaoCredito> cartoes)
    {
        decimal totalNasContas = contas.Sum(conta => conta.Saldo);
        decimal totalNasFaturas = cartoes.Sum(cartao => cartao.FaturaAtual);
        return totalNasContas - totalNasFaturas;
    }
}
