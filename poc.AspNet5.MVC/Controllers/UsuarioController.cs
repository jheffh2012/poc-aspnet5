﻿using AutoMapper;
using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.MVC.Models;
using System.Collections.ObjectModel;
using System.Web.Mvc;

namespace poc.AspNet5.MVC.Controllers
{
    [Authorize]
    public class UsuarioController : BaseCrudController<Usuario, UsuarioViewModel>
    {
        public UsuarioController(IUsuarioService serviceCrud, IMapper mapper) : base(serviceCrud, mapper)
        {
        }

        private Usuario BuscarDadosUsuarioLogado()
        {
            IUsuarioService _serv = _serviceCrud as IUsuarioService;

            return _serv.BuscarDadosDoUsuario(User.Identity.Name);
        }

        // GET: Equipe
        public override ActionResult Index()
        {
            var usuario = _mapper.Map<Usuario, UsuarioViewModel>(BuscarDadosUsuarioLogado());

            return View("Index", new Collection<UsuarioViewModel> { usuario });
        }

        // GET: Equipe/Create
        public override ActionResult Create()
        {
            var usuario = BuscarDadosUsuarioLogado();

            ViewBag.Equipes = new Collection<EquipeViewModel> { _mapper.Map<Equipe, EquipeViewModel>(usuario.Equipe) };
            return View();
        }

        // GET: Equipe/Edit/5
        public override ActionResult Edit(int id)
        {
            var usuario = BuscarDadosUsuarioLogado();

            ViewBag.Equipes = new Collection<EquipeViewModel> { _mapper.Map<Equipe, EquipeViewModel>(usuario.Equipe) };

            return View(_mapper.Map<Usuario, UsuarioViewModel>(_serviceCrud.GetById(id)));
        }
    }
}