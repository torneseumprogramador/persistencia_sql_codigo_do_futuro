using Database.Atributos;

namespace Negocio.Entidades;


[Tabela(Nome = "fornecedor")]
public record Fornecedor
{
    public int Id { get;set; }

    [Coluna(Nome = "razao_social")]
    public string? Nome { get;set; }
    
    public string? Email { get;set; }
}