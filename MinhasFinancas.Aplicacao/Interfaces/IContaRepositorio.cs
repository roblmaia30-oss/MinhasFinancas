using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.Interfaces;

public interface IContaRepositorio
{
    Task Salvar(Conta conta);
    Task Atualizar(Conta conta);
    Task<Conta?> ObterPorId(Guid id);
    Task<List<Conta>> ObterTodas();
}