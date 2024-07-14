
namespace Karapinha.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }

        public static implicit operator bool(Categoria v)
        {
            throw new NotImplementedException();
        }
    }
}
