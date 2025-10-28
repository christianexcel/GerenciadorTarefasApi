using System;
using GerenciadorTarefasApi.Infra.DTOs;

namespace GerenciadorTarefasApi.Services.Interfaces;

public interface ITagService
{
    List<TagDto> ObterTodos();
    TagDto? ObterPorId(int id);
    TagDto Adicionar(CriarTagDto tag);
    TagDto? Atualizar(int id, CriarTagDto tagAtualizada);
    bool Remover(int id);
}
