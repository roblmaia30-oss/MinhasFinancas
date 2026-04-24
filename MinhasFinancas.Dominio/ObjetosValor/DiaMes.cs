namespace MinhasFinancas.Dominio.ObjetosValor;

public record DiaMes
{
    public int Valor { get; }

    public DiaMes(int valor)
    {
        if (valor < 1 || valor > 31)
            throw new ArgumentException("O dia do mês deve estar entre 1 e 31.");
        
        Valor = valor;
    }

    public DateTime ObterDataParaOMes(int mes, int ano)
    {
        var ultimoDiaDoMes = DateTime.DaysInMonth(ano, mes);
        var diaReal = Math.Min(Valor, ultimoDiaDoMes);
        return new DateTime(ano, mes, diaReal);
    }

    public static implicit operator int(DiaMes d) => d.Valor;
    
    public static implicit operator DiaMes(int i) => new(i);

    public override string ToString() => Valor.ToString();
}