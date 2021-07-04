using poc.AspNet5.Ioc.Entities;

namespace poc.AspNet5.Domain.Interfaces.Services
{
    public interface IEventoConfirmacaoService : IServiceCrud<EventoConfirmacao>
    {

        void UsuarioConfirmaPresenca(string email, int Id);
    }

}
