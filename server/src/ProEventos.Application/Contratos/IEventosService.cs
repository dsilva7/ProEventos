using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventosService
    {
        Task<Event> AddEventos(Event model);
        Task<Event> UpdateEventos(int eventoId, Event model);
        Task<bool> DeleteEventos(int eventoId);

        Task<Event[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Event[]> GetAllEventosAsync(bool includePalestrantes = false );
        Task<Event> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false );
    }
}