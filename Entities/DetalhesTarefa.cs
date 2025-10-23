using System;

namespace GerenciadorTarefasApi.Entities;

public class DetalhesTarefa
{
    public int Prioridade { get; set; }
    public String NotasAdicionais { get; set; }
    public int IdTarefa { get; set; }
    public Tarefa Tarefa { get; set; }
}
