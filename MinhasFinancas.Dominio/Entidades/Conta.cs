using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Dominio.Entidades;

public class Conta(String nome, decimal saldoInicial)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; private set; } = nome;
    public decimal Saldo { get; private set; } = saldoInicial;

    public void Creditar(ValorMonetario valor)
    {
        Saldo += valor;
    }

    public void Debitar(ValorMonetario valor)
    {
        if (valor > Saldo) throw new InvalidOperationException("Saldo insuficiente");
        Saldo -= valor;
    }
}
