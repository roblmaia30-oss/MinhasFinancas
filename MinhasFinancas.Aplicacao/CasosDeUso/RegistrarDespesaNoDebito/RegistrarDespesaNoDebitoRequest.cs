namespace MinhasFinancas.Aplicacao.CasosDeUso.RegistrarDespesaNoDebito;

public record RegistrarDespesaNoDebitoRequest(
    string Descricao,
    decimal Valor,
    Guid ContaId,
    Guid CategoriaId,
    DateTime Data
);