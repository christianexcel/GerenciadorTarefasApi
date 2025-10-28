using System;
using GerenciadorTarefasApi.Infra.DTOs;

namespace GerenciadorTarefasApi.Services.Interfaces;

public interface IUsuarioService
{
    List<UsuarioDto> ObterTodos();
    UsuarioDto? ObterPorId(int id);
    UsuarioDto Adicionar(CriarUsuarioDto usuario);
    UsuarioDto? Atualizar(int id, CriarUsuarioDto usuarioAtualizado);
    bool Remover(int id);

}
