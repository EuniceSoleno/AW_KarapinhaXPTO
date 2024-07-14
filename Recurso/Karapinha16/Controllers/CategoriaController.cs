using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> BuscarTodasCategorias()
        {
            List<Categoria> categorias = await _categoriaRepositorio.BuscarTodasCategorias();
            return Ok(categorias);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Categoria>>> BuscarPorId(int id)
        {
            Categoria categoria = await _categoriaRepositorio.BuscarPorId(id);
            if (categoria == null)
            {
                  return NotFound($"Categoria com id: {id} nao encontrada");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Cadastrar([FromBody] Categoria categ)
        {
            Categoria categoria = await _categoriaRepositorio.Adicionar(categ);
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Atualizar([FromBody] Categoria categ, int id)
        {
            Categoria categoria = await _categoriaRepositorio.Atualizar(categ, id);
            if (categoria == null)
            {
                return NotFound($"categoria com id {id} não encontrado.");
            }
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(int id)
        {
            bool apagado = await _categoriaRepositorio.Apagar(id);
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
