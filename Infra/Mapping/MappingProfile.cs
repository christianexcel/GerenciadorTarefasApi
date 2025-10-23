using System;

namespace GerenciadorTarefasApi.Infra.Mapping;

using System;
using AutoMapper;
using GerenciadorTarefasApi.Entities;
using GerenciadorTarefasApi.Infra.DTOs;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<Tarefa, TarefaDto>()
            .ReverseMap();
    }

}