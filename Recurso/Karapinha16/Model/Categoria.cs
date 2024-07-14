
namespace Karapinha.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }

        public Categoria(string categoriaNome, string descricao)
        {
            CategoriaNome = categoriaNome;
            Descricao = descricao;
        }

        public static implicit operator bool(Categoria v)
        {
            throw new NotImplementedException();
        }
    }
}
