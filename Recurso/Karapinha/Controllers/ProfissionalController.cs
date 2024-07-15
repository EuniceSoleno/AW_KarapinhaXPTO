using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepositorio _profissionalRepositorio;

        public ProfissionalController(IProfissionalRepositorio profissionalRepositorio)
        {
            _profissionalRepositorio = profissionalRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profissional>>> BuscarTodosProfissionais()
        {
            List<Profissional> profissionais = await _profissionalRepositorio.BuscarTodosProfissionais();
            return Ok(profissionais);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profissional>> BuscarPorId(int id)
        {
            Profissional profissional = await _profissionalRepositorio.BuscarPorId(id);
            if (profissional == null)
            {
                return NotFound($"Profissional com id: {id} não encontrado");
            }
            return Ok(profissional);
        }

        [HttpPost]
        public async Task<ActionResult<Profissional>> Cadastrar([FromBody] Profissional profissional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Profissional novoProfissional = await _profissionalRepositorio.Adicionar(profissional);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoProfissional.id }, novoProfissional);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Profissional>> Atualizar([FromBody] Profissional profissional, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Profissional profissionalAtualizado = await _profissionalRepositorio.Atualizar(profissional, id);
            if (profissionalAtualizado == null)
            {
                return NotFound($"Profissional com id {id} não encontrado.");
            }
            return Ok(profissionalAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool apagado = await _profissionalRepositorio.Apagar(id);
            if (apagado)
            {
                return Ok(apagado);
            }
            else
            {
                return NotFound($"Profissional com id {id} não encontrado.");
            }
        }
    }
}
