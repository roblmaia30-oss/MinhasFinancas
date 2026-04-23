using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Dominio.Entidades;

public class CartaoCredito(string nome, ValorMonetario limite)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; private set; } = nome;
    public ValorMonetario Limite { get; private set; } = limite;
    public ValorMonetario FaturaAtual { get; private set; } = 0;

    public void AdicionarDespesa(ValorMonetario valor)
    {
        if (FaturaAtual + valor > Limite) throw new InvalidOperationException("Limite do cartão excedido");
        FaturaAtual += valor;
    }

    public void PagarFatura(ValorMonetario valor)
    {
        if (valor > FaturaAtual) throw new InvalidOperationException("Valor de pagamento excede o valor da fatura");
        FaturaAtual -= valor;
    }
}
