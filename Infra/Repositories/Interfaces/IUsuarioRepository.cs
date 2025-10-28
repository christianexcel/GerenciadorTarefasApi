using System;
using GerenciadorTarefasApi.Entities;

namespace GerenciadorTarefasApi.Infra.Repositories.Interfaces;

public interface IUsuarioRepository
{
    List<Usuario> ObterTodos();
    Usuario? ObterPorId(int id);
    Usuario Adicionar(Usuario novoUsuario);
    Usuario? Atualizar(int id, Usuario usuarioAtualizado);
    bool Remover(int id);
}
