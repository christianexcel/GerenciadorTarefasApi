using System;
using GerenciadorTarefasApi.Infra.DTOs;
using GerenciadorTarefasApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{

    private readonly ITarefaService _tarefaService;

    public TarefasController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpGet]
    public ActionResult<List<TarefaDto>> GetAll()
    {
        return Ok(_tarefaService.ObterTodos());
    }

    [HttpGet("{id}")]
    public ActionResult<TarefaDto> GetById(int id)
    {
        var tarefaDto = _tarefaService.ObterPorId(id);

        if (tarefaDto == null)
        {
            return NotFound();
        }

        return Ok(tarefaDto);
    }
    
    [HttpPost]  
    public ActionResult<TarefaDto> Add(CriarTarefaDto tarefaDto)  
    {
        try
        {
            var tarefaCriada = _tarefaService.Adicionar(tarefaDto);
            var dtoRetorno = _tarefaService.ObterPorId(tarefaCriada.Id);

            return CreatedAtAction(nameof(GetById), new { id = tarefaCriada.Id }, dtoRetorno);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 

}
