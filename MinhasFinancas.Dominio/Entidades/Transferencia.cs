using MinhasFinancas.Dominio.ObjetosValor;

namespace MinhasFinancas.Dominio.Entidades;

public class Transferencia
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Texto Descricao { get; private set; }
    public ValorMonetario Valor { get; private set; }
    public DateTime Data { get; private set; }

    public Guid ContaOrigemId { get; private set; }
    public Guid ContaDestinoId { get; private set; }

    public Transferencia(Texto descricao, ValorMonetario valor, DateTime data, Guid origemId, Guid destinoId)
    {
        if (origemId == destinoId)
            throw new ArgumentException("A conta de origem não pode ser igual à de destino.");

        Descricao = descricao;
        Valor = valor;
        Data = data;
        ContaOrigemId = origemId;
        ContaDestinoId = destinoId;
    }
}