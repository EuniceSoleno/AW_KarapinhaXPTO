using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Karapinha.Model
{
    public class Servico
    {
        public int Id { get; set; }
        public string ServicoNome { get; set; }
        public float Preco { get; set; }
        public int CategoriaId { get; set; }

        public Servico(int id, string servicoNome, float preco, int categoriaId)
        {
            Id = id;
            ServicoNome = servicoNome;
            Preco = preco;
            CategoriaId = categoriaId;
        }
        public static implicit operator bool(Servico v)
        {
            throw new NotImplementedException();
        }
    }
}
