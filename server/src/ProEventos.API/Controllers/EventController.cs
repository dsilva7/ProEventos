using Microsoft.AspNetCore.Mvc;
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

    public IEnumerable<Event> _event = new Event[] {
        new Event(){
        EventId = 1,
        Tema = "Angular 11 e .Net 5",
        Local = "Belo Horizonte",
        Lote = "1º Lote",
        QntPessoas = 250,
        DataEvent = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
        ImagemURL = "foto.png"
        },
        new Event(){
        EventId = 2,
        Tema = "Angular 11 e suas novidade",
        Local = "São Paulo",
        Lote = "2º Lote",
        QntPessoas = 350,
        DataEvent = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
        ImagemURL = "foto1.png"
        }
    };

    public EventController()
    {

    }

    [HttpGet]
    public IEnumerable<Event> Get()
    {
        return _event;

    }
    [HttpGet("{id}")]
    public IEnumerable<Event> GetById(int id)
    {
        return _event.Where(e => e.EventId == id);

    }

    [HttpPost]
    public string Post()
    {
        return "Exemplo de Post";
    }
}


