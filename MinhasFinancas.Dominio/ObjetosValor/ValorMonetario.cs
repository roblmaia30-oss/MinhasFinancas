namespace MinhasFinancas.Dominio.ObjetosValor;

public record ValorMonetario
{
    public decimal Valor { get; }

    public ValorMonetario(decimal valor)
    {
        if (valor < 0) throw new ArgumentException("O valor monetário não pode ser negativo");
        Valor = valor;
    }

    public static implicit operator decimal(ValorMonetario valorMonetario) => valorMonetario.Valor;
    public static implicit operator ValorMonetario(decimal valor) => new(valor);
}
