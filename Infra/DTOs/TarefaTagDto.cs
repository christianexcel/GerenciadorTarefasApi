using System;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class TarefaTagDto
{
    public int IdTag { get; set; }
    public TagDto Tag { get; set; }
}
