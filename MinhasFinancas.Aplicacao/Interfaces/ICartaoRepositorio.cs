using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.Interfaces;

public interface ICartaoRepositorio
{
    Task Salvar(CartaoCredito cartao);
    Task<CartaoCredito?> ObterPorId(Guid id);
    Task<List<CartaoCredito>> ObterTodos();
    Task Atualizar(CartaoCredito cartao);
}