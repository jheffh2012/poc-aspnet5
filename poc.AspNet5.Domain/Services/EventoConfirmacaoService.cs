﻿using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.Ioc.Repository;
using System.Linq;

namespace poc.AspNet5.Domain.Services
{
    public class EventoConfirmacaoService : ServiceCrud<EventoConfirmacao>, IEventoConfirmacaoService
    {
        protected readonly IUsuarioService _serviceUsuario;
        public EventoConfirmacaoService(
            IEventoConfirmacaoRepository repository,
            IUsuarioService serviceUsuario
        ) : base(repository)
        {
            _serviceUsuario = serviceUsuario;
        }

        public void UsuarioConfirmaPresenca(string email, int Id)
        {
            var usuario = _serviceUsuario.BuscarDadosDoUsuario(email);

            var registros = _repository.GetAll(new string[] { }, e => e.IdUsuario == usuario.Id && e.IdEvento == Id);

            if (registros.Count() > 0)
            {
                return;
            }

            Add(new EventoConfirmacao { IdEvento = Id, IdUsuario = usuario.Id });
        }
    }
}
