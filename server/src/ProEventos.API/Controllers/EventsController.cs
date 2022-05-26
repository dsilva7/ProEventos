using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Application.Contratos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
   
    private readonly IEventosService _eventoService;

    public EventsController(IEventosService eventoService)
    {
        _eventoService = eventoService;

    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var evento = await _eventoService.GetAllEventosAsync(true);
            if (evento == null) return NotFound("Nenhum evento encontrado");
            return Ok(evento);
        }
        catch (Exception ex)
        {
            // TODO
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var evento = await _eventoService.GetEventoByIdAsync(id, true);
            if (evento == null) return NotFound("Nenhum evento encontrado");
            return Ok(evento);
        }
        catch (Exception ex)
        {
            // TODO
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }

    }

    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if (evento == null) return NotFound("Eventos por tema não encontrados");
            return Ok(evento);
        }
        catch (Exception ex)
        {
            // TODO
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post(Event model)
    {
        try
        {
            var evento = await _eventoService.AddEventos(model);
            if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");
            return Ok(evento);
        }
        catch (Exception ex)
        {
            // TODO
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Event model)
    {
        try
        {
            var evento = await _eventoService.UpdateEventos(id, model);
            if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");
            return Ok(evento);
        }
        catch (Exception ex)
        {
            // TODO
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        try
        {
            return await _eventoService.DeleteEventos(id) ?
            Ok("Deletado") :
            BadRequest("Evento não deletado");

        }
        catch (Exception ex)
        {
            // TODO
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
        }

    }

}


