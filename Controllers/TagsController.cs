using System;
using GerenciadorTarefasApi.Infra.DTOs;
using GerenciadorTarefasApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public ActionResult<List<TagDto>> GetAll()
    {
        return Ok(_tagService.ObterTodos());
    }

    [HttpGet("{id}")]
    public ActionResult<TagDto> GetById(int id)
    {
        var tagDto = _tagService.ObterPorId(id);

        if (tagDto == null)
        {
            return NotFound();
        }

        return Ok(tagDto);
    }

    [HttpPut("{id}")]
    public ActionResult<CriarTagDto> Update(int id, CriarTagDto tagAtualizada)
    {
        try
        {
            var tag = _tagService.Atualizar(id, tagAtualizada);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<TagDto> Add([FromBody] CriarTagDto tagDto)
    {
        try
        {
            var tagCriada = _tagService.Adicionar(tagDto);
            var dtoRetorno = _tagService.ObterPorId(tagCriada.Id);

            return CreatedAtAction(nameof(GetById), new { id = tagCriada.Id }, dtoRetorno);
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
            var sucesso = _tagService.Remover(id);

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
