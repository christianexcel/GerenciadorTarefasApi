using System;

namespace GerenciadorTarefasApi.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<TarefaTag> TarefaTags { get; set; } = new List<TarefaTag>();
}
