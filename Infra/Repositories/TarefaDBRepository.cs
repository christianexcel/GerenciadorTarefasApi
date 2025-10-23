using System;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.Context;
using GerenciadorTarefasApi.Infra.Repositories.Interfaces;

namespace GerenciadorTarefasApi.Infra.Repositories;

public class TarefaDBRepository : ITarefaRepository
{

    private readonly TarefaContext _context;

    public TarefaDBRepository(TarefaContext context)
    {
        _context = context;
    }

    public Tarefa? Adicionar(Tarefa novaTarefa)
    {
        novaTarefa.DataCriacao = DateTime.UtcNow;
        _context.SaveChanges();
        return novaTarefa;
    }

    public Tarefa? ObterPorId(int id)
    {
        return _context.Tarefas
            .FirstOrDefault(p => p.Id == id);
    }

    public List<Tarefa> ObterTodos()
    {
        return _context.Tarefas
            .ToList();
    }

}
