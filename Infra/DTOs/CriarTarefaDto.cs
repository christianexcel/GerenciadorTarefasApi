using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class CriarTarefaDto
{
    [Required(ErrorMessage = "O título da tarefa é obrigatória.")]
    [MaxLength(100, ErrorMessage = "O título da tarefa não pode exceder 100 caracteres.")]
    [MinLength(3, ErrorMessage = "O título da tarefa deve ter no mínimo 3 caracteres.")]
    public string Titulo { get; set; } = string.Empty;
    [MaxLength(100, ErrorMessage = "O descrição da tarefa não pode exceder 500 caracteres.")]
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataConclusao { get; set; }
    public bool Concluida { get; set; } = false;
    [Required]
    public int IdUsuario { get; set; }

}
