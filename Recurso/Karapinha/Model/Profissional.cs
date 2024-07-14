
namespace Karapinha.Model
{
    public class Profissional
    {
        public int id {  get; set; }
        public string ProfissionalNome { get; set; }
        public string endereco  { get; set; }
        public string telemovel { get; set; }
        public string bi {get; set; }
        public string password { get; set; }
        public byte [] photo { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }

        public static implicit operator bool(Profissional v)
        {
            throw new NotImplementedException();
        }
    }
}
