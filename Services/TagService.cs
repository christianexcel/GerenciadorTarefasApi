using System;
using AutoMapper;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.DTOs;
using GerenciadorTarefasApi.Infra.Repositories.Interfaces;
using GerenciadorTarefasApi.Services.Interfaces;

namespace GerenciadorTarefasApi.Services;

public class TagService : ITagService
{
private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public TagService(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public List<TagDto> ObterTodos()
    {
        var tags = _tagRepository
            .ObterTodos()
            .ToList();

        return _mapper.Map<List<TagDto>>(tags);
    }

    public TagDto? ObterPorId(int id)
    {
        return _mapper.Map<TagDto>(_tagRepository.ObterPorId(id));
    }

    public TagDto Adicionar(CriarTagDto tagDto)
    {
        var novaTag = new CriarTagDto
        {
            Nome = tagDto.Nome
        };
        var tagAdicionada = _tagRepository.Adicionar(_mapper.Map<Tag>(novaTag));

        return _mapper.Map<TagDto>(tagAdicionada);
    }

    public TagDto? Atualizar(int id, CriarTagDto tagAtualizada)
    {
        var tag = _tagRepository.ObterPorId(id);
        if (tag != null)
        {
            tag.Nome = tagAtualizada.Nome;
            var _tagAtualizada = _tagRepository.Atualizar(id, tag);

            return _mapper.Map<TagDto>(_tagAtualizada);
        }

        return null;
    }

    public bool Remover(int id)
    {
        return _tagRepository.Remover(id);
    }
}
