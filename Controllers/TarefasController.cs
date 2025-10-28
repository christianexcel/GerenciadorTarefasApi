using System;
using GerenciadorTarefasApi.Entities;
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

    [HttpPut("{id}")]
    public ActionResult<CriarTarefaDto> Update(int id, CriarTarefaDto tarefaAtualizada)
    {
        try
        {
            var tarefa = _tarefaService.Atualizar(id, tarefaAtualizada);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<TarefaDto> Add([FromBody] CriarTarefaDto tarefaDto)
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

    [HttpPatch("{id}/concluir")]
    public ActionResult Patch(int id)
    {
        try
        {
            var tarefa = _tarefaService.ObterPorId(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            if (tarefa.Concluida)
            {
                return BadRequest("Tarefa já foi marcada como concluída.");
            }

            _tarefaService.concluirTarefa(id);

            return Ok(tarefa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(int id) 
    {
        try
        {
            var sucesso = _tarefaService.Remover(id);

            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 

}
