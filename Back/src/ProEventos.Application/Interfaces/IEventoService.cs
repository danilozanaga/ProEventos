using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<bool> DeleteEvento(int eventoId);
        Task<Evento> UpdateEvento(int eventoId,Evento model);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes  = false);
        Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes  = false);


    }
}