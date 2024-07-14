using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

/*namespace Karapinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaDeHorarioController : ControllerBase
    {
        private readonly ITabelaDeHorarioRepositorio _tabelaDeHorarioRepositorio;

        public TabelaDeHorarioController(ITabelaDeHorarioRepositorio tabelaDeHorarioRepositorio)
        {
            _tabelaDeHorarioRepositorio = tabelaDeHorarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TabelaDeHorario>>> BuscarTodosHorarios()
        {
            List<TabelaDeHorario> horarios = await _tabelaDeHorarioRepositorio.BuscarTodosHorarios();
            return Ok(horarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TabelaDeHorario>> BuscarPorId(int id)
        {
            TabelaDeHorario horario = await _tabelaDeHorarioRepositorio.BuscarPorId(id);
            if (horario == null)
            {
                return NotFound($"Horário com id: {id} não encontrado");
            }
            return Ok(horario);
        }

        [HttpPost]
        public async Task<ActionResult<TabelaDeHorario>> Cadastrar([FromBody] TabelaDeHorario horario)
        {
            TabelaDeHorario novoHorario = await _tabelaDeHorarioRepositorio.Adicionar(horario);
            return Ok(novoHorario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TabelaDeHorario>> Atualizar([FromBody] TabelaDeHorario horario, int id)
        {
            TabelaDeHorario horarioAtualizado = await _tabelaDeHorarioRepositorio.Atualizar(horario, id);
            if (horarioAtualizado == null)
            {
                return NotFound($"Horário com id {id} não encontrado.");
            }
            return Ok(horarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool apagado = await _tabelaDeHorarioRepositorio.Apagar(id);
            if (apagado)
            {
                return Ok(apagado);
            }
            else
            {
                return NotFound($"Horário com id {id} não encontrado.");
            }
        }
    }
}*/
