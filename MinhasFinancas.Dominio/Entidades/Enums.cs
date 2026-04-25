namespace MinhasFinancas.Dominio.Entidades;

public enum TipoTransacao
{
    Receita,
    Despesa, 
    Transferencia,
    Ajuste
}

public enum MetodoPagamento
{
    Dinheiro,
    Debito,
    CartaoCredito,
}
