using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    
    private readonly DataContext _context;

    public EventController(DataContext context)
    {
        _context = context;

    }

    [HttpGet]
    public IEnumerable<Event> Get()
    {
        return _context.Events;

    }
    [HttpGet("{id}")]
    public Event GetById(int id)
    {
        return _context.Events.FirstOrDefault(e => e.EventId == id);

    }

    [HttpPost]
    public string Post()
    {
        return "Exemplo de Post";
    }
}


