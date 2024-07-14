using Karapinha.Model;

namespace Karapinha.Repositorios.Interface
{
    public interface IEmail
    {
        void Send(Email request);
    }
}
