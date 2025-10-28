using System;
using GerenciadorTarefasApi.Entities;

namespace GerenciadorTarefasApi.Infra.Repositories.Interfaces;

public interface ITagRepository
{
    List<Tag> ObterTodos();
    Tag? ObterPorId(int id);
    Tag Adicionar(Tag novaTag);
    Tag? Atualizar(int id, Tag tagAtualizada);
    bool Remover(int id);
}
