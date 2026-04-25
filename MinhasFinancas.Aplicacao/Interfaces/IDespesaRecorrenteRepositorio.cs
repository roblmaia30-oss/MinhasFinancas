using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.Interfaces;

public interface IDespesaRecorrenteRepositorio
{
    Task Salvar(DespesaRecorrente entidade);
    Task<List<DespesaRecorrente>> ObterTodos();
}
