using MinhasFinancas.Aplicacao.Interfaces;

namespace MinhasFinancas.Aplicacao.CasosDeUso.ListarTransacoesDoMes;

public class ListarTransacoesDoMes(ITransacaoRepositorio transacaoRepositorio,
                                   ICategoriaRepositorio categoriaRepositorio)
{
    private readonly ITransacaoRepositorio _transacaoRepositorio = transacaoRepositorio;
    private readonly ICategoriaRepositorio _categoriaRepositorio = categoriaRepositorio;

    public async Task<ListarTransacoesDoMesResponse> Executar(ListarTransacoesDoMesRequest request)
    {
        var dataInicio = new DateTime(request.Ano, request.Mes, 1);
        var dataFim = dataInicio.AddMonths(1).AddDays(-1);

        var transacoes = await _transacaoRepositorio.ObterPorPeriodo(dataInicio, dataFim);
        var categorias = await _categoriaRepositorio.ObterTodos();

        var listaJaPago = transacoes.Where(t => t.EstaPago).Select(t => new TransacaoDto(
            Id: t.Id,
            Descricao: t.Descricao.ToString(),
            Valor: t.Valor.Valor,
            Data: t.Data,
            Tipo: t.Tipo.ToString(),
            MetodoPagamento: t.Metodo.ToString(),
            EstaPago: t.EstaPago,
            CategoriaNome: categorias.FirstOrDefault(c => c.Id == t.CategoriaId)?.Nome.Valor ?? "Categoria não encontrada"
        )).ToList();

        var listaPendente = transacoes.Where(t => !t.EstaPago).Select(t => new TransacaoDto(
            Id: t.Id,
            Descricao: t.Descricao.ToString(),
            Valor: t.Valor.Valor,
            Data: t.Data,
            Tipo: t.Tipo.ToString(),
            MetodoPagamento: t.Metodo.ToString(),
            EstaPago: t.EstaPago,
            CategoriaNome: categorias.FirstOrDefault(c => c.Id == t.CategoriaId)?.Nome.Valor ?? "Categoria não encontrada"
        )).ToList();

        return new ListarTransacoesDoMesResponse(JaPago: listaJaPago, Pendente: listaPendente);
    }
}

public record TransacaoDto(
    Guid Id,
    string Descricao,
    decimal Valor,
    DateTime Data,
    string Tipo,
    string MetodoPagamento,
    bool EstaPago,
    string CategoriaNome
);
