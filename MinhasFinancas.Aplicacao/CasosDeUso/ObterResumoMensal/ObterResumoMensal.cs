using MinhasFinancas.Aplicacao.Interfaces;
using MinhasFinancas.Dominio.Entidades;
using MinhasFinancas.Dominio.Servicos;
using System.Linq;

namespace MinhasFinancas.Aplicacao.CasosDeUso.ObterResumoMensal;

public class ObterResumoMensal(
    ITransacaoRepositorio transacaoRepositorio,
    IContaRepositorio contaRepositorio,
    ICartaoRepositorio cartaoRepositorio)
{
    private readonly ITransacaoRepositorio _transacaoRepositorio = transacaoRepositorio;
    private readonly IContaRepositorio _contaRepositorio = contaRepositorio;
    private readonly ICartaoRepositorio _cartaoRepositorio = cartaoRepositorio;

    public async Task<ObterResumoMensalResponse> Executar(ObterResumoMensalRequest request)
    {
        var dataInicio = new DateTime(request.Ano, request.Mes, 1);
        var dataFim = dataInicio.AddMonths(1).AddDays(-1);

        var transacoes = await _transacaoRepositorio.ObterPorPeriodo(dataInicio, dataFim);
        var contas = await _contaRepositorio.ObterTodas();
        var cartoes = await _cartaoRepositorio.ObterTodos();

        var totalReceitas = transacoes
            .Where(t => t.Tipo == TipoTransacao.Receita
            ).Sum(t => t.Valor);

        var totalDespesas = transacoes
            .Where(t => t.Tipo == TipoTransacao
            .Despesa).Sum(t => t.Valor);

        var superavit = totalReceitas - totalDespesas;

        var saldoReal = CalculadoraFinanceira.CalcularSaldoDisponivelParaGastar(contas, cartoes);
        
        return new ObterResumoMensalResponse(
            totalReceitas, 
            totalDespesas, 
            superavit, 
            saldoReal);
    }
}
