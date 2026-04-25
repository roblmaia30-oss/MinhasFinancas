using MinhasFinancas.Aplicacao.Interfaces;
using MinhasFinancas.Dominio.Entidades;
using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Aplicacao.CasosDeUso.RegistrarGastoNoCartao;

public class RegistrarGastoNoCartao(ICartaoRepositorio cartaoRepositorio, ITransacaoRepositorio transacaoRepositorio)
{
    private readonly ICartaoRepositorio _cartaoRepositorio = cartaoRepositorio;
    private readonly ITransacaoRepositorio _transacaoRepositorio = transacaoRepositorio;

    public async Task Executar(RegistrarGastoNoCartaoRequest request)
    {
        var cartao = await _cartaoRepositorio.ObterPorId(request.CartaoId) ?? throw new Exception("Cartão não encontrado!");

        cartao.AdicionarDespesa(request.Valor);

        var transacao = new Transacao(
            descricao: request.Descricao,
            valor: request.Valor,
            data: request.Data,
            tipo: TipoTransacao.Despesa,
            metodo: MetodoPagamento.CartaoCredito,
            cartaoId: cartao.Id,
            categoriaId: request.CategoriaId
        );

        await _cartaoRepositorio.Atualizar(cartao);
        await _transacaoRepositorio.Adicionar(transacao);
    }
}