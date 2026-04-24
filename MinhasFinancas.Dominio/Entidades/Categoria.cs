using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Dominio.Entidades;

public class Categoria(Texto nome, ValorMonetario? metaMensal = null)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Texto Nome { get; private set; } = nome;
    public ValorMonetario? MetaMensal { get; private set; } = metaMensal;

    public void AtualizarMeta(ValorMonetario novaMeta)
    {
        MetaMensal = novaMeta;
    }
}
