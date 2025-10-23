using System;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class DetalhesTarefaDto
{
    public int IdTarefa { get; set; }
    public int Prioridade { get; set; }
    public String NotasAdicionais { get; set; }
}
