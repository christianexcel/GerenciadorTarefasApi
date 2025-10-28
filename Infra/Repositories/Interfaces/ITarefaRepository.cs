using System;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.DTOs;

namespace GerenciadorTarefasApi.Infra.Repositories.Interfaces;

public interface ITarefaRepository
{
    List<Tarefa> ObterTodos();
    Tarefa? ObterPorId(int id);
    Tarefa Adicionar(Tarefa novaTarefa);
    Tarefa? Atualizar(int id, Tarefa tarefaAtualziada);
    bool Remover(int id);
}
