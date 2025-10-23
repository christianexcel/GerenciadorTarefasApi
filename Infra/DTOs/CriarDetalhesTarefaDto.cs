using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class CriarDetalhesTarefaDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "A prioridade é obrigatória.")]
    [Range(0, 2, ErrorMessage = "A prioridade deve ser entre 0 e 2.")]
    public int Prioridade { get; set; }
    public String NotasAdicionais { get; set; }
}
