
namespace Karapinha.Model
{
    public class Utilizador
    {
        public int id { get; set; }
        public string nomeCompleto { get; set; }
        public string endereco { get; set; }
        public string telemovel { get; set; }
        public string bi { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public byte[] photo { get; set; }

        public static implicit operator bool(Utilizador v)
        {
            throw new NotImplementedException();
        }
    }
}
