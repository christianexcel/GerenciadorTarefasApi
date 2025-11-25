using System;

namespace GerenciadorTarefasApi.Entities;

public class TarefaTag
{
    public int IdTarefa { get; set; }
    public int IdTag { get; set; }
    public Tag Tag { get; set; }
    public Tarefa Tarefa { get; set; }
}
