using System;

namespace GerenciadorTarefasApi.Entities;

public class Usuario
{
    public int Id { get; set; }
    public String Nome { get; set; }
    public String Email { get; set; }
    public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
}
