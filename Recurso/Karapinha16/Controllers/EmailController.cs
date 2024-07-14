using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Karapinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmail _emailRepositorio;

        public EmailController(IEmail emailRepositorio)
        {
            _emailRepositorio = emailRepositorio;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] Email emailRequest)
        {
            _emailRepositorio.Send(emailRequest);
            return Ok("Email enviado com sucesso.");
        }
    }
}