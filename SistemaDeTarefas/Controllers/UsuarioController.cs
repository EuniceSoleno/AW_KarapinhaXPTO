using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuariorepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuariorepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuariorepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuariorepositorio.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound($"Usuário com id {id} não encontrado.");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuariorepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuario = await _usuariorepositorio.Atualizar(usuarioModel, id);
            if (usuario == null)
            {
                return NotFound($"Usuário com id {id} não encontrado.");
            }
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool apagado = await _usuariorepositorio.Apagar(id);
            if (apagado)
            {
                return Ok(apagado);
            }
            else
            {
                return NotFound($"Usuário com id {id} não encontrado.");
            }
        }
    }
}
