using System;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.Context;
using GerenciadorTarefasApi.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasApi.Infra.Repositories;

public class TagDBRepository : ITagRepository
{
    private readonly TarefaContext _context;

    public TagDBRepository(TarefaContext context)
    {
        _context = context;
    }

    public Tag? Adicionar(Tag novaTag)
    {
        _context.Tags.Add(novaTag);
        _context.SaveChanges();
        return novaTag;
    }

    public List<Tag> ObterTodos()
    {
        return _context.Tags
            //.Include(t => t.TarefaTags)
            .ToList();
    }

    public Tag? ObterPorId(int id)
    {
        return _context.Tags
            //.Include(t => t.TarefaTags)
            .FirstOrDefault(t => t.Id == id);
    }

    public Tag? Atualizar(int id, Tag tagAtualizada)
    {
        _context.Tags.Update(tagAtualizada);
        _context.SaveChanges();
        return tagAtualizada;
    }

    public bool Remover(int id)
    {
        var tagParaDeletar = ObterPorId(id);
        if (tagParaDeletar == null) return false;

        _context.Tags.Remove(tagParaDeletar);
        _context.SaveChanges();
        return true;
    }

}
