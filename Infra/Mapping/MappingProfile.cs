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

        CreateMap<DetalhesTarefa, DetalhesTarefaDto>()
            .ReverseMap();

        CreateMap<CriarDetalhesTarefaDto, DetalhesTarefa>()
            .ReverseMap();

        CreateMap<Tarefa, CriarTarefaDto>()
            .ForMember(dest => dest.DetalhesTarefa, opt => opt.MapFrom(src => src.DetalhesTarefa != null ? src.DetalhesTarefa : null))
            .ReverseMap();

        CreateMap<Usuario, UsuarioDto>()
            .ReverseMap();

        CreateMap<Usuario, CriarUsuarioDto>()
            .ReverseMap();

        CreateMap<Tag, TagDto>()
            .ReverseMap();

        CreateMap<Tag, CriarTagDto>()
            .ReverseMap();

        CreateMap<TarefaTag, TarefaTagDto>()
            .ReverseMap();

        

    }

}