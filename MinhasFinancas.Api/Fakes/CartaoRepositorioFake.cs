using MinhasFinancas.Aplicacao.Interfaces;
using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Api.Fakes;

public class CartaoRepositorioFake : ICartaoRepositorio
{
    // A nossa "tabela" do banco de dados de mentira
    public List<CartaoCredito> Cartoes = new();

    public Task Salvar(CartaoCredito cartao)
    {
        Cartoes.Add(cartao);
        return Task.CompletedTask;
    }

    public Task Atualizar(CartaoCredito cartao)
    {
        // Como estamos usando uma lista na memória, o objeto já é atualizado automaticamente
        // por referência. No futuro, com SQL, aqui faríamos o "UPDATE tabela...".
        return Task.CompletedTask;
    }

    public Task<CartaoCredito?> ObterPorId(Guid id)
    {
        var cartao = Cartoes.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(cartao);
    }

    public Task<List<CartaoCredito>> ObterTodos()
    {
        return Task.FromResult(Cartoes);
    }
}