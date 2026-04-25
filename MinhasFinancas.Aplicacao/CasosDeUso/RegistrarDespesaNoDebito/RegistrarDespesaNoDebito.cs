using MinhasFinancas.Aplicacao.Interfaces;
using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.CasosDeUso.RegistrarDespesaNoDebito;

public class RegistrarDespesaNoDebito(IContaRepositorio contaRepositorio, ITransacaoRepositorio transacaoRepositorio)
{
    private readonly IContaRepositorio _contaRepositorio = contaRepositorio;
    private readonly ITransacaoRepositorio _transacaoRepositorio = transacaoRepositorio;

    public async Task Executar(RegistrarDespesaNoDebitoRequest request)
    {
        var conta = await _contaRepositorio.ObterPorId(request.ContaId) ?? throw new Exception("Conta de débito não encontrada!");

        conta.Debitar(request.Valor);

        var transacao = new Transacao(
            descricao: request.Descricao,
            valor: request.Valor,
            data: request.Data,
            tipo: TipoTransacao.Despesa,
            metodo: MetodoPagamento.Debito,
            contaId: conta.Id,
            categoriaId: request.CategoriaId
        );

        await _contaRepositorio.Atualizar(conta);
        await _transacaoRepositorio.Adicionar(transacao);
    }
}
