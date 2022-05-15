using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrante
    {
        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos  = false);
        Task<Palestrante[]> GetAllPalestranteAsync( bool includeEventos  = false);
        Task<Palestrante> GetAllPalestranteByIdAsync(int PalestranteId, bool includeEventos  = false);
    }
}