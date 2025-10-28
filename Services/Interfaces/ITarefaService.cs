using System;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.DTOs;

namespace GerenciadorTarefasApi.Services.Interfaces;

public interface ITarefaService
{
    List<TarefaDto> ObterTodos();
    TarefaDto? ObterPorId(int id);
    TarefaDto Adicionar(CriarTarefaDto tarefa);
    TarefaDto? Atualizar(int id, CriarTarefaDto tarafaAtualizada);
    bool Remover(int id);
}
