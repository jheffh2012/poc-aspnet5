using AutoMapper;
using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.MVC.Models;
using System.Web.Mvc;

namespace poc.AspNet5.MVC.Controllers
{
    [Authorize]
    public class EventoConfirmacaoController : BaseCrudController<EventoConfirmacao, EventoConfirmacaoViewModel>
    {
        public EventoConfirmacaoController(IEventoConfirmacaoService serviceCrud, IMapper mapper) : base(serviceCrud, mapper)
        {
        }
    }
}