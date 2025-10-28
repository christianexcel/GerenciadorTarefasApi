using System;
using AutoMapper;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.DTOs;
using GerenciadorTarefasApi.Infra.Repositories.Interfaces;
using GerenciadorTarefasApi.Services.Interfaces;

namespace GerenciadorTarefasApi.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public List<UsuarioDto> ObterTodos()
    {
        var usuarios = _usuarioRepository
            .ObterTodos()
            .ToList();

        return _mapper.Map<List<UsuarioDto>>(usuarios);
    }

    public UsuarioDto? ObterPorId(int id)
    {
        return _mapper.Map<UsuarioDto>(_usuarioRepository.ObterPorId(id));
    }

    public UsuarioDto Adicionar(CriarUsuarioDto usuarioDto)
    {
        var novoUsuario = new CriarUsuarioDto
        {
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email
        };

        var usuarioAdicionado = _usuarioRepository.Adicionar(_mapper.Map<Usuario>(usuarioDto));

        return _mapper.Map<UsuarioDto>(usuarioAdicionado);
    }

    public UsuarioDto? Atualizar(int id, CriarUsuarioDto usuarioAtualizado)
    {
        var usuario = _usuarioRepository.ObterPorId(id);
        if (usuario != null)
        {
            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;

            var _usuarioAtualizado = _usuarioRepository.Atualizar(id, usuario);
            return _mapper.Map<UsuarioDto>(_usuarioAtualizado);
        }
        return null;
    }

    public bool Remover(int id)
    {
        return _usuarioRepository.Remover(id);
    }
}
