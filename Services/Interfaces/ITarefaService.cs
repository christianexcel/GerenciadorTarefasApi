using System;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.DTOs;

namespace GerenciadorTarefasApi.Services.Interfaces;

public interface ITarefaService
{
    List<TarefaDto> ObterTodos();
    Tarefa? ObterPorId(int id);
    Tarefa Adicionar(CriarTarefaDto clienteDto);
}
