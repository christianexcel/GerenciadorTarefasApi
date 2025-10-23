using System;

namespace GerenciadorTarefasApi.Infra.DTOs;

public class TarefaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
    public bool Concluida { get; set; }
    public int IdUsuario { get; set; }
}
