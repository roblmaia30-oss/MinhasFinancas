using MinhasFinancas.Aplicacao.Interfaces;
using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Testes.Fakes;

public class ContaRepositorioFake : IContaRepositorio
{
    public List<Conta> Contas = new();

    public Task<Conta?> ObterPorId(Guid id)
    {
        var conta = Contas.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(conta);
    }

    public Task Atualizar(Conta conta)
    {
        // Na memória não precisamos fazer nada, o objeto já atualizou.
        return Task.CompletedTask; 
    }

    // (Implemente os outros métodos da interface retornando Task.CompletedTask se necessário)
    public Task Salvar(Conta conta) { Contas.Add(conta); return Task.CompletedTask; }
    public Task<List<Conta>> ObterTodas() => Task.FromResult(Contas);
}