using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Event> AddEventos(Event model)
        {
            try
            {
                _geralPersist.add<Event>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                // TODO
                throw new Exception(ex.Message);
            }
        }
        public async Task<Event> UpdateEventos(int eventoId, Event model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                // TODO
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("EVento para delete não foi encontrado.");

                _geralPersist.Delete(evento);
                return (await _geralPersist.SaveChangesAsync());

            }
            catch (Exception ex)
            {
                // TODO
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventosAsync(bool includePalestrantes =false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if( eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                 // TODO
                 throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if( eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                 // TODO
                 throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
                if( eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                 // TODO
                 throw new Exception(ex.Message);
            }
        }

         }
}