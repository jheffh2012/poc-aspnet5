using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.Ioc.Repository;
using System.Collections.Generic;

namespace poc.AspNet5.Domain.Services
{
    public class CalendarioService : ServiceCrud<Calendario>, ICalendarioService
    {
        protected readonly IUsuarioService _serviceUsuario;
        public CalendarioService(ICalendarioRepository repository, IUsuarioService serviceUsuario) : base(repository)
        {
            _serviceUsuario = serviceUsuario;
        }

        public IEnumerable<Calendario> BuscarCalendariosDoUsuario(string email)
        {
            var usuario = _serviceUsuario.BuscarDadosDoUsuario(email);

            return _repository.GetAll(new string[] { }, e => e.IdEquipe == usuario.IdEquipe);
        }
    }
}
