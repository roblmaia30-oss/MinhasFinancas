namespace MinhasFinancas.Dominio.ObjetosValor;

public record Texto
{
    public string Valor { get; }

    public Texto(string valor)
    {
        // Regra 1: Não pode ser nulo ou apenas espaços
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("O texto não pode estar vazio.");

        // Regra 2: Tamanho mínimo (exemplo: 3 caracteres)
        if (valor.Trim().Length < 3)
            throw new ArgumentException("O texto deve ter pelo menos 3 caracteres.");

        // Regra 3: Você pode querer que sempre comece com letra maiúscula
        Valor = char.ToUpper(valor[0]) + valor.Substring(1);
    }

    // Atalhos para facilitar o uso
    public static implicit operator string(Texto t) => t.Valor;
    public static implicit operator Texto(string s) => new Texto(s);

    public override string ToString() => Valor;
}