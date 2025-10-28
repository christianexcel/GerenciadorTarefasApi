using System;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.Context;
using GerenciadorTarefasApi.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasApi.Infra.Repositories;

public class UsuarioDBRepository : IUsuarioRepository
{
    private readonly TarefaContext _context;

    public UsuarioDBRepository(TarefaContext context)
    {
        _context = context;
    }

    public Usuario? Adicionar(Usuario novoUsuario)
    {
        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges();
        return novoUsuario;
    }

    public List<Usuario> ObterTodos()
    {
        return _context.Usuarios
            .Include(u => u.Tarefas)
                .ThenInclude(t => t.DetalhesTarefa)
            .ToList();
    }

    public Usuario? ObterPorId(int id)
    {
        return _context.Usuarios
            .Include(u => u.Tarefas)
                .ThenInclude(t => t.DetalhesTarefa)
            .FirstOrDefault(p => p.Id == id);
    }

    public Usuario? Atualizar(int id, Usuario usuarioAtualizado)
    {
        _context.Usuarios.Update(usuarioAtualizado);
        _context.SaveChanges();
        return usuarioAtualizado;
    }

    public bool Remover(int id)
    {
        var usuarioParaDeletar = ObterPorId(id);
        if (usuarioParaDeletar == null) return false;

        _context.Usuarios.Remove(usuarioParaDeletar);
        _context.SaveChanges();
        return true;
    }
}
