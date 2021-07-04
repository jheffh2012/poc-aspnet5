using poc.AspNet5.Ioc.Entities;
using System.Collections.Generic;

namespace poc.AspNet5.Domain.Interfaces.Services
{
    public interface ICalendarioService : IServiceCrud<Calendario>
    {
        IEnumerable<Calendario> BuscarCalendariosDoUsuario(string email);
    }
}
