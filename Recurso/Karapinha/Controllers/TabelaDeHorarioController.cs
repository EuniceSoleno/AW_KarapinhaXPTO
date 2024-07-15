using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TabelaDeHorarioController : ControllerBase
    {
        private readonly ITabelaDeHorarioRepositorio _tabelaDeHorarioRepositorio;

        public TabelaDeHorarioController(ITabelaDeHorarioRepositorio tabelaDeHorarioRepositorio)
        {
            _tabelaDeHorarioRepositorio = tabelaDeHorarioRepositorio;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tabelaDeHorario = await _tabelaDeHorarioRepositorio.BuscarPorId(id);
            if (tabelaDeHorario == null)
            {
                return NotFound();
            }
            return Ok(tabelaDeHorario);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tabelasDeHorario = await _tabelaDeHorarioRepositorio.BuscarTodos();
            return Ok(tabelasDeHorario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TabelaDeHorario tabelaDeHorario)
        {
            var novaTabelaDeHorario = await _tabelaDeHorarioRepositorio.Adicionar(tabelaDeHorario);
            return CreatedAtAction(nameof(Get), new { id = novaTabelaDeHorario.Id }, novaTabelaDeHorario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TabelaDeHorario tabelaDeHorario)
        {
            var tabelaDeHorarioAtualizada = await _tabelaDeHorarioRepositorio.Atualizar(tabelaDeHorario, id);
            if (tabelaDeHorarioAtualizada == null)
            {
                return NotFound();
            }
            return Ok(tabelaDeHorarioAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tabelaDeHorario = await _tabelaDeHorarioRepositorio.Apagar(id);
            if (tabelaDeHorario == null)
            {
                return NotFound();
            }
            return Ok(tabelaDeHorario);
        }
    }
}
