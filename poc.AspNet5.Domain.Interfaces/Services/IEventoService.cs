using poc.AspNet5.Ioc.Entities;
using System.Collections.Generic;

namespace poc.AspNet5.Domain.Interfaces.Services
{
    public interface IEventoService : IServiceCrud<Evento>
    {
        decimal BuscarPercentualConfirmacao(Evento evento);
        IEnumerable<Evento> BuscarEventosDoUsuario(string email);
    }
}
