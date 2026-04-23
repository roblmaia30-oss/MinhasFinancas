namespace MinhasFinancas.Dominio.ObjetosValor;

public record ValorMonetario
{
    public decimal Valor { get; init; }

    public ValorMonetario(decimal valor)
    {
        if (valor < 0) throw new ArgumentException("O valor monetário não pode ser negativo");
        Valor = valor;
    }

    public static ValorMonetario operator +(ValorMonetario a, ValorMonetario b) => new(a.Valor + b.Valor);
    public static ValorMonetario operator -(ValorMonetario a, ValorMonetario b) => new(a.Valor - b.Valor);

    public static implicit operator decimal(ValorMonetario valorMonetario) => valorMonetario.Valor;
    public static implicit operator ValorMonetario(decimal valor) => new(valor);

    public override string ToString() => Valor.ToString("C2"); // Formata como R$ 0,00
}
