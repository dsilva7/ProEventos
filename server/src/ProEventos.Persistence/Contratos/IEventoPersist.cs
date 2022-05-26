using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        //Eventos
        Task<Event[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Event[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Event> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);

    }
}