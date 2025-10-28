using System;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.Context;
using GerenciadorTarefasApi.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        _context.Tarefas.Add(novaTarefa);
        _context.SaveChanges();
        return novaTarefa;
    }

    public List<Tarefa> ObterTodos()
    {
        return _context.Tarefas
            .Include(t => t.DetalhesTarefa)
            .ToList();
    }

    public Tarefa? ObterPorId(int id)
    {
        return _context.Tarefas
            .Include(t => t.DetalhesTarefa)
            .FirstOrDefault(p => p.Id == id);
    }

    public Tarefa? Atualizar(int id, Tarefa tarefaAtualizada)
    {
        _context.Tarefas.Update(tarefaAtualizada);
        _context.SaveChanges();
        return tarefaAtualizada;
    }

    public bool Remover(int id)
    {
        var tarefaParaDeletar = ObterPorId(id);
        if (tarefaParaDeletar == null) return false;

        _context.Tarefas.Remove(tarefaParaDeletar);
        _context.SaveChanges();
        return true;
    }

}
