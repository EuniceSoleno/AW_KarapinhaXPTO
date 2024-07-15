using System.ComponentModel.DataAnnotations;

namespace Karapinha.Model
{
    public class Profissional
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo ProfissionalNome é obrigatório.")]
        public string ProfissionalNome { get; set; }

        [Required(ErrorMessage = "O campo endereco é obrigatório.")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "O campo telemovel é obrigatório.")]
        [MaxLength(15, ErrorMessage = "O campo telemovel pode ter no máximo 15 caracteres.")]
        public string telemovel { get; set; }

        [Required(ErrorMessage = "O campo bi é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo bi pode ter no máximo 20 caracteres.")]
        public string bi { get; set; }

        [Required(ErrorMessage = "O campo password é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo password pode ter no máximo 100 caracteres.")]
        public string password { get; set; }

        public byte[] photo { get; set; }

        [Required(ErrorMessage = "O campo CategoriaId é obrigatório.")]
        public int CategoriaId { get; set; }

        public static implicit operator bool(Profissional v)
        {
            throw new NotImplementedException();
        }
    }
}
