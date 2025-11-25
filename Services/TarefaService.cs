using System;
using AutoMapper;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.DTOs;
using GerenciadorTarefasApi.Infra.Repositories.Interfaces;
using GerenciadorTarefasApi.Services.Interfaces;

namespace GerenciadorTarefasApi.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public TarefaService(ITarefaRepository tarefaRepository, ITagRepository tagRepository, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public List<TarefaDto> ObterTodos()
    {
        var tarefas = _tarefaRepository
            .ObterTodos()
            .ToList();

        return _mapper.Map<List<TarefaDto>>(tarefas);
    }

    public TarefaDto? ObterPorId(int id)
    {
        return _mapper.Map<TarefaDto>(_tarefaRepository.ObterPorId(id));
    }

    public TarefaDto Adicionar(CriarTarefaDto tarefaDto)
    {
        var novaTarefa = new CriarTarefaDto
        {
            Titulo = tarefaDto.Titulo,
            Descricao = tarefaDto.Descricao,
            DataConclusao = tarefaDto.DataConclusao,
            DetalhesTarefa = tarefaDto.DetalhesTarefa,
            Concluida = tarefaDto.Concluida,
            IdUsuario = tarefaDto.IdUsuario
        };
        var tarefaAdicionada = _tarefaRepository.Adicionar(_mapper.Map<Tarefa>(novaTarefa));

        return _mapper.Map<TarefaDto>(tarefaAdicionada);
    }

    public TarefaDto? Atualizar(int id, CriarTarefaDto tarefaAtualizada)
    {
        var tarefa = _tarefaRepository.ObterPorId(id);
        if (tarefa != null)
        {
            tarefa.Concluida = tarefaAtualizada.Concluida;
            tarefa.DataConclusao = tarefaAtualizada.DataConclusao;
            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.IdUsuario = tarefaAtualizada.IdUsuario;
            tarefa.DetalhesTarefa.NotasAdicionais = tarefaAtualizada.DetalhesTarefa.NotasAdicionais;
            tarefa.DetalhesTarefa.Prioridade = tarefaAtualizada.DetalhesTarefa.Prioridade;
            var _tarefaAtualizada = _tarefaRepository.Atualizar(id, tarefa);

            return _mapper.Map<TarefaDto>(_tarefaAtualizada);
        }

        return null;
    }

    public bool concluirTarefa(int id)
    {
        var tarefa = _tarefaRepository.ObterPorId(id);
        if (tarefa != null)
        {
            tarefa.Concluida = true;
            _tarefaRepository.Atualizar(id, tarefa);
            return true;
        }
        return false;
    }
    
    public bool VincularTag(int tarefaId, int tagId)
    {
        var tarefa = _tarefaRepository.ObterPorId(tarefaId);
        var tag = _tagRepository.ObterPorId(tagId);
        if (tarefa != null)
        {
            tarefa.TarefaTags.Add(new TarefaTag
            {
                IdTarefa = tarefa.Id,
                IdTag = tag.Id
            });
            Atualizar(tarefaId, _mapper.Map<CriarTarefaDto>(tarefa));
            return true; 
        }
        return false;
    }

    public bool Remover(int id)
    {
        return _tarefaRepository.Remover(id);
    }

}
