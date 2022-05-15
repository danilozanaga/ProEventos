using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            this._eventoService = eventoService;
        }

        [HttpDelete]
        public async Task<IActionResult>  Delete(int id)
        {
             try
             {
                 return await _eventoService.DeleteEvento(id) ? 
                     Ok("Excluido") : 
                     BadRequest("Evento não deletado");                                  
             }
             catch (Exception ex)
             {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao excluir evento, erro: {ex.Message}");                    
             }
        }

        [HttpPost]
        public async Task<IActionResult>  Post(Evento model)
        {
            try
            {
                 var evento = await _eventoService.AddEventos(model);
                 if (evento == null) {
                     return BadRequest("Erro ao adicionar evento"); 
                 } else {
                     return Ok(evento);
                 }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro adicionar evento, erro: {ex.Message}");   
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                 var evento = await _eventoService.UpdateEvento(id,model);
                 if (evento == null) {
                     return BadRequest("Erro ao atualizar evento"); 
                 } else {
                     return Ok(evento);
                 }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro atualizar evento, erro: {ex.Message}");   
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            try
            {
                 var eventos = await _eventoService.GetAllEventosAsync(true);
                 if (eventos == null) {
                     return NotFound("Nenhum evento encontrado"); 
                 } else {
                     return Ok(eventos);
                 }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao recuperar eventos, erro: {ex.Message}");   
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {   
            try
            {
                 var evento = await _eventoService.GetAllEventosByIdAsync(id,true);
                 if (evento == null) {
                     return NotFound("Nenhum evento encontrado"); 
                 } else {
                     return Ok(evento);
                 }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao recuperar evento, erro: {ex.Message}");   
            }
        }


        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {   
            try
            {
                 var evento = await _eventoService.GetAllEventosByTemaAsync(tema,true);
                 if (evento == null) {
                     return NotFound("Eventos por tema não encontrados"); 
                 } else {
                     return Ok(evento);
                 }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao recuperar evento, erro: {ex.Message}");   
            }
        }
    }
}
