
namespace Karapinha.Model
{
    public class Servico
    {
        public int Id { get; set; }
        public string ServicoNome { get; set; }
        public float Preco { get; set; }
        public int CategoriaId { get; set; }

        public static implicit operator bool(Servico v)
        {
            throw new NotImplementedException();
        }
    }
}
