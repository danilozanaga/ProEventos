using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {


        public EventoController()
        {

        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Delete id = {id} ";
        }

        [HttpPost("{id}")]
        public string Post(int id)
        {
            return $"Post id = {id} ";
        }


        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Put id = {id} ";
        }


        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new Evento[] { 
                new Evento
                {
                    EventoId = 1,
                    Tema = "Música",
                    Local = "-23.649258052169333,-46.79044599616174",
                    QtdPessoas = 10,
                    DataEvento = DateTime.Now.AddDays(30),
                    Lote = "Vip",
                    ImagemUrl = "1"
                },
                new Evento
                {
                    EventoId = 1,
                    Tema = "Internet",
                    Local = "-23.649258052169333,-46.79044599616174",
                    QtdPessoas = 120,
                    DataEvento = DateTime.Now.AddDays(60),
                    Lote = "1o Lote Público",
                    ImagemUrl = "2"
                },

            };
        }
    }
}
