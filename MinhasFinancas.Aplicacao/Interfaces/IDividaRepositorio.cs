using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.Interfaces;

public interface IDividaRepositorio
{
    Task Salvar(Divida entidade);
    Task<List<Divida>> ObterTodos();
}
