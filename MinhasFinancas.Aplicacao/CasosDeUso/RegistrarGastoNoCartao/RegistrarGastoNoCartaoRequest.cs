namespace MinhasFinancas.Aplicacao.CasosDeUso.RegistrarGastoNoCartao;

public record RegistrarGastoNoCartaoRequest(
    string Descricao,
    decimal Valor,
    Guid CartaoId,
    Guid CategoriaId,
    DateTime Data
);