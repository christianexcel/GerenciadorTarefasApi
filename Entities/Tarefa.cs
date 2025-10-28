using System;

namespace GerenciadorTarefasApi.Entities;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
    public bool Concluida { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public DetalhesTarefa DetalhesTarefa { get; set; }
    public ICollection<TarefaTag> TarefaTags { get; set; } = new List<TarefaTag>();
}
