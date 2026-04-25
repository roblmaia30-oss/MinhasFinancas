using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.Interfaces;

public interface ITransacaoRepositorio
{
    Task Adicionar(Transacao transacao);
    
    Task<List<Transacao>> ObterPorPeriodo(DateTime inicio, DateTime fim);
    
    Task<List<Transacao>> ObterTodas();
}