using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcacaoController : ControllerBase
    {
        private readonly IMarcacaoRepositorio _marcacaoRepositorio;

        public MarcacaoController(IMarcacaoRepositorio marcacaoRepositorio)
        {
            _marcacaoRepositorio = marcacaoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marcacao>>> BuscarTodasCategorias()
        {
            List<Marcacao> marcacao = await _marcacaoRepositorio.BuscarTodasMarcacoes();
            return Ok(marcacao);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Marcacao>>> BuscarPorId(int id)
        {
            Marcacao marcacao = await _marcacaoRepositorio.BuscarPorId(id);
            if (marcacao == null)
            {
                return NotFound($"marcacao com id: {id} nao encontrada");
            }
            return Ok(marcacao);
        }

        [HttpPost]
        public async Task<ActionResult<Marcacao>> Cadastrar([FromBody] Marcacao marc)
        {
            Marcacao marcacao = await _marcacaoRepositorio.Adicionar(marc);
            return Ok(marcacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Marcacao>> Atualizar([FromBody] Marcacao mac, int id)
        {
            Marcacao marcacao = await _marcacaoRepositorio.Atualizar(mac, id);
            if (marcacao == null)
            {
                return NotFound($"categoria com id {id} não encontrado.");
            }
            return Ok(marcacao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool apagado = await _marcacaoRepositorio.Apagar(id);
            if (apagado)
            {
                return Ok(apagado);
            }
            else
            {
                return NotFound($"marcacao com id {id} não encontrado.");
            }
        }
    }
}
