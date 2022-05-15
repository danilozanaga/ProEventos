using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Models
{
    public class EventoService : IEventoService
    {
        private readonly IBaseInterface baseInterface;
        private readonly IEvento evento;

        public EventoService(IBaseInterface baseInterface, IEvento evento)
        {
            this.baseInterface = baseInterface;
            this.evento = evento;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                baseInterface.Add(model);
                if (await baseInterface.SaveChangesAsync()) {
                    return await evento.GetAllEventosByIdAsync(model.Id,false);
                }
                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao adicionar evento: " + ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId,Evento model)
        {
            try
            {
                Evento _evento = await evento.GetAllEventosByIdAsync(eventoId,false);
                if (evento !=  null) {
                    baseInterface.Update(model);
                    if (await baseInterface.SaveChangesAsync()) {
                        return model;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao editar evento: " + ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                Evento _evento = await evento.GetAllEventosByIdAsync(eventoId,false);
                if (evento !=  null) {
                    baseInterface.Delete<Evento>(_evento);
                    return (await baseInterface.SaveChangesAsync());
                } else {
                    throw new Exception("Evento não encontrado");
                }
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao excluir evento: " + ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                return await evento.GetAllEventosAsync(includePalestrantes);
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao obter eventos: " + ex.Message);
            }
        }

        public async Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            try
            {
                return await evento.GetAllEventosByIdAsync(EventoId,includePalestrantes);
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao obter eventos: " + ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                return await evento.GetAllEventosByTemaAsync(tema,includePalestrantes);
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao obter eventos: " + ex.Message);
            }
        }

    }
}