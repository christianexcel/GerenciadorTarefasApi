using System;
using GerenciadorTarefasApi.Infra.DTOs;
using GerenciadorTarefasApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public ActionResult<List<UsuarioDto>> GetAll()
    {
        return Ok(_usuarioService.ObterTodos());
    }

    [HttpGet("{id}")]
    public ActionResult<UsuarioDto> GetById(int id)
    {
        var usuarioDto = _usuarioService.ObterPorId(id);

        if (usuarioDto == null)
        {
            return NotFound();
        }

        return Ok(usuarioDto);
    }

    [HttpPut("{id}")]
    public ActionResult<CriarUsuarioDto> Update(int id, CriarUsuarioDto usuarioAtualizado)
    {
        try
        {
            var usuario = _usuarioService.Atualizar(id, usuarioAtualizado);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<UsuarioDto> Add([FromBody] CriarUsuarioDto usuarioDto)
    {
        try
        {
            var usuarioCriado = _usuarioService.Adicionar(usuarioDto);
            var dtoRetorno = _usuarioService.ObterPorId(usuarioCriado.Id);

            return CreatedAtAction(nameof(GetById), new { id = usuarioCriado.Id }, dtoRetorno);
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
            var sucesso = _usuarioService.Remover(id);

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
