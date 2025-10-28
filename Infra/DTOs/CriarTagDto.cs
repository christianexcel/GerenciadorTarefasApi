using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class CriarTagDto
{
    [Required(ErrorMessage = "O nome da tag é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome da tag não pode exceder 50 caracteres.")]
    [MinLength(3, ErrorMessage = "O nome da tag deve ter no mínimo 3 caracteres.")]
    public string Nome { get; set; } = string.Empty;
}
