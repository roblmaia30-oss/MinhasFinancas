namespace MinhasFinancas.Aplicacao.CasosDeUso.ObterResumoMensal;

public record ObterResumoMensalResponse(
    decimal TotalReceitas,
    decimal TotalDespesas,
    decimal Superavit,
    decimal SaldoDisponivelReal
);