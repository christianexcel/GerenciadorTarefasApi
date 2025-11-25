using System;
using GerenciadorTarefasApi.Entities;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class UsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public ICollection<TarefaDto> Tarefas { get; set; } = new List<TarefaDto>();
}
