using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.Interfaces;

public interface ICategoriaRepositorio
{
    Task Salvar(Categoria entidade);
    Task<List<Categoria>> ObterTodos();
}
