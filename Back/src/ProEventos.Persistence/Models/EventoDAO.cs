using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;
using ProEventos.Persistence.Models;

namespace ProEventos.Persistence.Interfaces
{
    public class EventoDAO :  IEvento
    {
        private readonly ProEventosContext _context;

        public EventoDAO(ProEventosContext context) 
        {
            this._context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(r => r.RedesSociais);
            if (includePalestrantes) {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);    
            }
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == EventoId);
            return await query.FirstOrDefaultAsync();    
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(r => r.RedesSociais);
            if (includePalestrantes) {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);    
            }
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();    
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
             IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(r => r.RedesSociais);
            if (includePalestrantes) {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);   
            }
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();    
       }

    }
}