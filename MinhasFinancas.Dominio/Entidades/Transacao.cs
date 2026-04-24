using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Dominio.Entidades;

public class Transacao
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Texto Descricao { get; private set; }
    public ValorMonetario Valor { get; private set; }
    public DateTime Data { get; private set; }
    public TipoTransacao Tipo { get; private set; }
    public MetodoPagamento Metodo { get; private set; }
    
    public Guid? ContaId { get; private set; }
    public Guid? CartaoId { get; private set; }
    public Guid? CategoriaId { get; private set; }

    public Transacao(
        Texto descricao, 
        ValorMonetario valor, 
        DateTime data, 
        TipoTransacao tipo, 
        MetodoPagamento metodo,
        Guid? contaId = null,
        Guid? cartaoId = null,
        Guid? categoriaId = null)
    {

        // Regra: Se for crédito, precisa de um cartão. Se for débito, precisa de uma conta.
        if (metodo == MetodoPagamento.CartaoCredito && cartaoId == null)
            throw new ArgumentException("Transações no crédito precisam de um cartão.");

        Descricao = descricao;
        Valor = valor;
        Data = data;
        Tipo = tipo;
        Metodo = metodo;
        ContaId = contaId;
        CartaoId = cartaoId;
        CategoriaId = categoriaId;
    }
}