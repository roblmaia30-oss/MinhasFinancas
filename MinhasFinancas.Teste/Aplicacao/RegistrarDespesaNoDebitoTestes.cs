using MinhasFinancas.Aplicacao.CasosDeUso.RegistrarDespesaNoDebito;
using MinhasFinancas.Dominio.Entidades;
using MinhasFinancas.Testes.Fakes;
using Xunit;

namespace MinhasFinancas.Testes.Aplicacao;

public class RegistrarDespesaNoDebitoTestes
{
    [Fact]
    public async Task Deve_Debitar_Da_Conta_E_Salvar_Transacao()
    {
        // ==========================================
        // 1. ARRANGE (Preparar o cenário)
        // ==========================================
        
        // Criamos os bancos de mentira
        var contaRepoFake = new ContaRepositorioFake();
        var transacaoRepoFake = new TransacaoRepositorioFake();

        // Criamos uma conta real com R$ 100 e colocamos no banco de mentira
        var minhaConta = new Conta("Inter", 100m);
        await contaRepoFake.Salvar(minhaConta);

        // Instanciamos o Caso de Uso passando os fakes
        var casoDeUso = new RegistrarDespesaNoDebito(contaRepoFake, transacaoRepoFake);

        // Criamos o pedido: Gastar R$ 30 na padaria
        var request = new RegistrarDespesaNoDebitoRequest(
            Descricao: "Padaria",
            Valor: 30m,
            ContaId: minhaConta.Id, // Usamos o ID da conta que criamos
            CategoriaId: Guid.NewGuid(),
            Data: DateTime.Now
        );

        // ==========================================
        // 2. ACT (Agir)
        // ==========================================
        await casoDeUso.Executar(request);

        // ==========================================
        // 3. ASSERT (Verificar se deu certo)
        // ==========================================
        
        // A conta tinha 100, gastou 30. O saldo tem que ser 70.
        Assert.Equal(70m, minhaConta.Saldo);

        // O repositório de transações deve ter exatamente 1 transação salva
        Assert.Single(transacaoRepoFake.Transacoes);
        
        // O valor da transação salva deve ser 30
        Assert.Equal(30m, (decimal)transacaoRepoFake.Transacoes[0].Valor);
    }
}