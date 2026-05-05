using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.CasosDeUso.ListarTransacoesDoMes;

public record class ListarTransacoesDoMesResponse(
    List<TransacaoDto> JaPago,
    List<TransacaoDto> Pendente
);
