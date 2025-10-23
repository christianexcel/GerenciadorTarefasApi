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
    private readonly IMapper _mapper;

    public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
        _mapper = mapper;
    }

    public List<TarefaDto> ObterTodos()
    {
        var tarefas = _tarefaRepository
            .ObterTodos()
            .ToList();

        return _mapper.Map<List<TarefaDto>>(tarefas);
    }

    public Tarefa? ObterPorId(int id)
    {
        return _tarefaRepository.ObterPorId(id);
    }

    public Tarefa Adicionar(CriarTarefaDto tarefaDto)
    {
        var novaTarefa = new Tarefa
        {
            Titulo = tarefaDto.Titulo,
            Descricao = tarefaDto.Descricao,
            DataConclusao = tarefaDto.DataConclusao,
            Concluida = tarefaDto.Concluida,
            IdUsuario = tarefaDto.IdUsuario
        };
        var tarefaAdicionada = _tarefaRepository.Adicionar(_mapper.Map<Tarefa>(novaTarefa));

        return _tarefaRepository.ObterPorId(tarefaAdicionada.Id) ?? tarefaAdicionada;
    }

}
