using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Dominio.Entidades;

public class DespesaRecorrente
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Texto Descricao { get; private set; }
    public ValorMonetario ValorEstimado { get; private set; }
    public DiaMes DiaVencimento { get; private set; }
    public Guid CategoriaId { get; private set; }
    public Guid ContaPadraoId { get; private set; } // De onde geralmente sai o dinheiro

    public DespesaRecorrente(Texto descricao, ValorMonetario valor, DiaMes dia, Guid categoriaId, Guid contaId)
    {
        Descricao = descricao;
        ValorEstimado = valor;
        DiaVencimento = dia;
        CategoriaId = categoriaId;
        ContaPadraoId = contaId;
    }
}