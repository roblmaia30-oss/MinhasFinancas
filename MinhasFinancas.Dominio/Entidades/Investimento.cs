using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Dominio.Entidades;

public class Investimento
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Texto Nome { get; private set; }
    public ValorMonetario Saldo { get; private set; }
    public ValorMonetario? Meta { get; private set; } // Para os "Cofrinhos"

    public Investimento(Texto nome, ValorMonetario saldoInicial, ValorMonetario? meta = null)
    {
        Nome = nome;
        Saldo = saldoInicial;
        Meta = meta;
    }

    // Regra específica: Rendimento aumenta o saldo sem ser uma "Transferência"
    public void RegistrarRendimento(ValorMonetario valorRendimento)
    {
        Saldo = Saldo + valorRendimento;
    }

    public void AdicionarAporte(ValorMonetario valor)
    {
        Saldo = Saldo + valor;
    }

    public void RetirarValor(ValorMonetario valor)
    {
        if (valor > Saldo) throw new InvalidOperationException("Saldo insuficiente no investimento");
        Saldo = Saldo - valor;
    }
}