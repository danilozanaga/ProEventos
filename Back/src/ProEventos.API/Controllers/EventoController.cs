using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            this._context = context;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            Evento _evento = _context.Eventos.Where(e => e.Id == id).FirstOrDefault();
            if (_evento == null)
                throw new Exception("Evento não encontrado para exclusão"); 
            _context.Remove(_evento);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Post(Evento evento)
        {
            evento.Id = Guid.NewGuid();
            _context.Add(evento);
            _context.SaveChanges();
        }


        [HttpPut]
        public void Put(Evento evento)
        {
            _context.Update(evento);
            _context.SaveChanges();
        }


        [HttpGet]
        public IEnumerable<Evento> Get()
        {   
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(Guid id)
        {   
            return _context.Eventos.Where(e => e.Id == id);
        }


    }
}
