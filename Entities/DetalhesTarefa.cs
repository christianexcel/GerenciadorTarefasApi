using System;

namespace GerenciadorTarefasApi.Entities;

public class DetalhesTarefa
{
    int Id { get; set; }
    int Prioridade { get; set; }
    String NotasAdicionais { get; set; }
    int IdTarefa { get; set; }
}
