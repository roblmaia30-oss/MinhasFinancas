using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.Interfaces;

public interface ITransferenciaRepositorio
{
    Task Salvar(Transferencia entidade);
    Task<List<Transferencia>> ObterTodos();
}
