using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Dominio.Entidades;

public class Divida(Texto nome, ValorMonetario valorTotal, int totalParcelas, ValorMonetario valorParcela)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Texto Nome { get; private set; } = nome;
    public ValorMonetario ValorTotalOriginal { get; private set; } = valorTotal;
    public int TotalParcelas { get; private set; } = totalParcelas;
    public int ParcelasPagas { get; private set; } = 0;
    public ValorMonetario ValorParcela { get; private set; } = valorParcela;

    public decimal CalcularSaldoDevedor()
    {
        return ValorTotalOriginal - (ParcelasPagas * ValorParcela);
    }

    public void RegistrarPagamentoParcela()
    {
        if (ParcelasPagas >= TotalParcelas)
            throw new InvalidOperationException("Todas as parcelas já foram pagas.");
        
        ParcelasPagas++;
    }
}