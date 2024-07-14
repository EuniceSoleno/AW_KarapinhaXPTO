using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            // Converter a imagem para Base64 em cada profissional
            /* foreach (var profissional in profissionais)
            {
                if (profissional.photo != null)
                {
                    profissional.PhotoBase64 = ConvertToBase64(profissional.photo);
                }
            }*/

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
           /* if (profissional.photo != null)
            {
                profissional.PhotoBase64 = ConvertToBase64(profissional.photo);
            }*/

            return Ok(profissional);
        }
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<Profissional>> BuscarPorNome(string nome)
        {
            Profissional profissional = await _profissionalRepositorio.BuscarPorNome(nome);
            if (profissional == null)
            {
                return NotFound($"Profissional nao encontrado");
            }
            return Ok(profissional);

        }

        [HttpPost]
        public async Task<ActionResult<Profissional>> Cadastrar([FromBody] Profissional profissional)
        {
          /*  if (profissional.PhotoBase64 != null)
            {
                profissional.photo = ConvertFromBase64(profissional.PhotoBase64);
            }*/

            Profissional novoProfissional = await _profissionalRepositorio.Adicionar(profissional);
            return Ok(novoProfissional);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Profissional>> Atualizar([FromBody] Profissional profissional, int id)
        {
            Profissional profissionalAtualizado = await _profissionalRepositorio.Atualizar(profissional, id);
            if (profissionalAtualizado == null)
            {
                return NotFound($"Profissional com id {id} não encontrado.");
            }
          /*  if (profissional.PhotoBase64 != null)
            {
                profissional.photo = ConvertFromBase64(profissional.PhotoBase64);
            }*/

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

        private string ConvertToBase64(byte[] imageBytes)
        {
            return Convert.ToBase64String(imageBytes);
        }

        private byte[] ConvertFromBase64(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

    }


}
