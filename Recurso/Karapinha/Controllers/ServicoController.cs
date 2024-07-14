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
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepositorio _servicoRepositorio;

        public ServicoController(IServicoRepositorio servicoRepositorio)
        {
            _servicoRepositorio = servicoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Servico>>> BuscarTodosServicos()
        {
            List<Servico> servicos = await _servicoRepositorio.BuscarTodosServicos();
            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> BuscarPorId(int id)
        {
            Servico servico = await _servicoRepositorio.BuscarPorId(id);
            if (servico == null)
            {
                return NotFound($"Serviço com id: {id} não encontrado");
            }
            return Ok(servico);
        }

        [HttpPost]
        public async Task<ActionResult<Servico>> Cadastrar([FromBody] Servico servico)
        {
            Servico novoServico = await _servicoRepositorio.Adicionar(servico);
            return Ok(novoServico);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Servico>> Atualizar([FromBody] Servico servico, int id)
        {
            Servico servicoAtualizado = await _servicoRepositorio.Atualizar(servico, id);
            if (servicoAtualizado == null)
            {
                return NotFound($"Serviço com id {id} não encontrado.");
            }
            return Ok(servicoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool apagado = await _servicoRepositorio.Apagar(id);
            if (apagado)
            {
                return Ok(apagado);
            }
            else
            {
                return NotFound($"Serviço com id {id} não encontrado.");
            }
        }
    }
}
