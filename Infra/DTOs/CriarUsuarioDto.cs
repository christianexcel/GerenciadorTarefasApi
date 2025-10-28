using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class CriarUsuarioDto
{
    [Required(ErrorMessage = "O nome do usuário é obrigatório")]
    [MaxLength(100, ErrorMessage = "O nome do usuário não pode exceder mais que 100 caracteres.")]
    [MinLength(3, ErrorMessage = "O nome do usuário deve ter no mínimo 3 caracteres.")]
    public string Nome { get; set; } = string.Empty;
    [Required(ErrorMessage = "O nome do usuário é obrigatório")]
    [MaxLength(100, ErrorMessage = "O email do usuário não pode exceder mais que 100 caracteres.")]
    [MinLength(3, ErrorMessage = "O email do usuário deve ter no mínimo 3 caracteres.")]
    public string Email { get; set; } = string.Empty;
}
