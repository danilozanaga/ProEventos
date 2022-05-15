using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence.Models
{
    public class PalestranteDAO: IPalestrante
    {

        private readonly ProEventosContext _context;

        public PalestranteDAO(ProEventosContext context)
        {
            this._context = context;
        }


        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = 
                _context.Palestrantes
                    .Include(p => p.RedesSociais);
            if (includeEventos) {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);    
            }
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();    
        }

        public async Task<Palestrante> GetAllPalestranteByIdAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = 
                _context.Palestrantes
                    .Include(p => p.RedesSociais);
            if (includeEventos) {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);    
            }
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(p => p.Id == PalestranteId);
            return await query.FirstOrDefaultAsync();    
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = 
                _context.Palestrantes
                    .Include(p => p.RedesSociais);
            if (includeEventos) {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);    
            }
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();    
        }

    }
}