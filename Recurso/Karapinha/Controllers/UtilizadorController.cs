using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        private readonly IUtilizadorRepositorio _utilizadorRepositorio;

        public UtilizadorController(IUtilizadorRepositorio utilizadorRepositorio)
        {
            _utilizadorRepositorio = utilizadorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Utilizador>>> BuscarTodosUtilizadores()
        {
            List<Utilizador> utilizadores = await _utilizadorRepositorio.BuscarTodosUtilizadores();
            return Ok(utilizadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> BuscarPorId(int id)
        {
            Utilizador utilizador = await _utilizadorRepositorio.BuscarPorId(id);
            if (utilizador == null)
            {
                return NotFound($"Utilizador com id: {id} não encontrado");
            }
            return Ok(utilizador);
        }

        [HttpPost]
        public async Task<ActionResult<Utilizador>> Cadastrar([FromBody] Utilizador utilizador)
        {
            Utilizador novoUtilizador = await _utilizadorRepositorio.Adicionar(utilizador);
            return Ok(novoUtilizador);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Utilizador>> Atualizar([FromBody] Utilizador utilizador, int id)
        {
            Utilizador utilizadorAtualizado = await _utilizadorRepositorio.Atualizar(utilizador, id);
            if (utilizadorAtualizado == null)
            {
                return NotFound($"Utilizador com id {id} não encontrado.");
            }
            return Ok(utilizadorAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool apagado = await _utilizadorRepositorio.Apagar(id);
            if (apagado)
            {
                return Ok(apagado);
            }
            else
            {
                return NotFound($"Utilizador com id {id} não encontrado.");
            }
        }
    }
}
