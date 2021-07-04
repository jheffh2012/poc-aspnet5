using AutoMapper;
using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Domain.Services;
using poc.AspNet5.Ioc.EntityFramework.Context;
using poc.AspNet5.Ioc.EntityFramework.Repository;
using poc.AspNet5.Ioc.Repository;
using poc.AspNet5.MVC.AutoMapper;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace poc.AspNet5.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });

            container.RegisterInstance<IMapper>(config.CreateMapper());

            container.RegisterType<SqlServerDBContext>();
            container.RegisterType<IUsuarioRepository, UsuarioRepository>();
            container.RegisterType<IEventoRepository, EventoRepository>();
            container.RegisterType<ICalendarioRepository, CalendarioRepository>();
            container.RegisterType<IEquipeRepository, EquipeRepository>();
            container.RegisterType<IEventoConfirmacaoRepository, EventoConfirmacaoRepository>();

            container.RegisterType<IUsuarioService, UsuarioService>();
            container.RegisterType<IEventoService, EventoService>();
            container.RegisterType<ICalendarioService, CalendarioService>();
            container.RegisterType<IEquipeService, EquipeService>();
            container.RegisterType<IEventoConfirmacaoService, EventoConfirmacaoService>();
            container.RegisterType<IPrevisaoTempoService, PrevisaoTempoService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}