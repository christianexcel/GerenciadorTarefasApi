using System;
using GerenciadorTarefasApi.Entities;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class TagDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    //public ICollection<TarefaTagDto> TagTarefas { get; set; } = new List<TarefaTagDto>();

}
