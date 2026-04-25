using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.Interfaces;

public interface IInvestimentoRepositorio
{
    Task Salvar(Investimento entidade);
    Task<List<Investimento>> ObterTodos();
}
