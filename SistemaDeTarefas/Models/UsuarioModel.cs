using System.ComponentModel.DataAnnotations;

namespace SistemaDeTarefas.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string email { get; set; }

       
    }
}
