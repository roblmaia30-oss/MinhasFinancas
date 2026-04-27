namespace MinhasFinancas.Aplicacao.CasosDeUso.RealizarTransferencia;

public record RealizarTransferenciaRequest(
    string Descricao,
    decimal Valor,
    Guid ContaOrigemId,
    Guid ContaDestinoId,
    DateTime Data
);