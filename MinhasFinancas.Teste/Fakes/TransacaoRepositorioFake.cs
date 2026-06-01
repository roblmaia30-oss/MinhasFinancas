using MinhasFinancas.Aplicacao.Interfaces;
using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Testes.Fakes;

public class TransacaoRepositorioFake : ITransacaoRepositorio
{
    public List<Transacao> Transacoes = new();

    public Task Adicionar(Transacao transacao)
    {
        Transacoes.Add(transacao);
        return Task.CompletedTask;
    }

    // (Implemente os outros métodos retornando listas vazias por enquanto)
    public Task<List<Transacao>> ObterPorPeriodo(DateTime inicio, DateTime fim) => Task.FromResult(Transacoes);
    public Task<List<Transacao>> ObterTodas() => Task.FromResult(Transacoes);
}