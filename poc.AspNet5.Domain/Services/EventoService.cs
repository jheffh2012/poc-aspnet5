﻿using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.Ioc.Repository;
using System.Collections.Generic;
using System.Linq;

namespace poc.AspNet5.Domain.Services
{
    public class EventoService : ServiceCrud<Evento>, IEventoService
    {
        protected readonly ICalendarioService _serviceCalendario;
        protected readonly IEquipeService _serviceEquipe;

        public EventoService(
            IEventoRepository repository,
            ICalendarioService serviceCalendario,
            IEquipeService serviceEquipe
        ) : base(repository)
        {
            _serviceCalendario = serviceCalendario;
            _serviceEquipe = serviceEquipe;
        }

        public IEnumerable<Evento> BuscarEventosDoUsuario(string email)
        {
            ICollection<Calendario> calendarios = _serviceCalendario.BuscarCalendariosDoUsuario(email) as ICollection<Calendario>;

            return _repository.GetAll(new string[] { }, e => calendarios.Where(i => i.Id == e.IdCalendario).Any());
        }

        public decimal BuscarPercentualConfirmacao(Evento evento)
        {
            var eventoAtual = _repository.GetById(evento, new string[] { "Confirmacoes" });

            var calendario = _serviceCalendario.GetById(evento.IdCalendario);

            var equipe = _serviceEquipe.GetById(calendario.IdEquipe, new string[] { "Usuarios" });

            return eventoAtual.Confirmacoes.Count() > 0 ? (eventoAtual.Confirmacoes.Count() / equipe.Usuarios.Count()) * 100 : 0;
        }
    }
}
