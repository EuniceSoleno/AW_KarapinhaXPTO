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

        [HttpGet("nome/{nome}")]
      public async Task<IActionResult> GetByNome(string nome)
        {
            var tabelaDeHorario = await _tabelaDeHorarioRepositorio.BuscarPorNomeProfissional(nome);
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
            try
            {
                var novaTabelaDeHorario = await _tabelaDeHorarioRepositorio.Adicionar(tabelaDeHorario);
                return CreatedAtAction(nameof(Get), new { id = novaTabelaDeHorario.Id }, novaTabelaDeHorario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TabelaDeHorario tabelaDeHorario)
        {
            try
            {
                var tabelaDeHorarioAtualizada = await _tabelaDeHorarioRepositorio.Atualizar(tabelaDeHorario, id);
                return Ok(tabelaDeHorarioAtualizada);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tabelaDeHorario = await _tabelaDeHorarioRepositorio.Apagar(id);
                return Ok(tabelaDeHorario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
