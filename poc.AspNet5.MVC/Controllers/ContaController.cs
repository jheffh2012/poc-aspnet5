using AutoMapper;
using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace poc.AspNet5.MVC.Controllers
{
    public class ContaController : Controller
    {
        protected readonly IUsuarioService _service;
        protected readonly IEquipeService _serviceEquipe;
        protected readonly IPrevisaoTempoService _servicePrevisaoTempo;
        protected readonly IMapper _mapper;

        public ContaController(
            IUsuarioService service,
            IEquipeService serviceEquipe,
            IPrevisaoTempoService servicePrevisaoTempo,
            IMapper mapper
        )
        {
            _service = service;
            _serviceEquipe = serviceEquipe;
            _mapper = mapper;
            _servicePrevisaoTempo = servicePrevisaoTempo;
        }
        // Return Home page.
        public ActionResult Index()
        {
            if (User.Identity.Name != "")
            {
                ViewBag.DadosUsuario = _service.BuscarDadosDoUsuario(User.Identity.Name);
                ViewBag.PrevisaoTempo = _mapper.Map<PrevisaoTempoCidade, PrevisaoTempoCidadeViewModel>(_servicePrevisaoTempo.GetPrevisaoPorIp(Request.UserHostAddress));
                return View("Logado");
            }


            return View();
        }

        // Return Home page.
        public ActionResult Logado()
        {
            if (User.Identity.Name != "")
            {
                ViewBag.DadosUsuario = _service.BuscarDadosDoUsuario(User.Identity.Name);
                ViewBag.PrevisaoTempo = _mapper.Map<PrevisaoTempoCidade, PrevisaoTempoCidadeViewModel>(_servicePrevisaoTempo.GetPrevisaoPorIp(Request.UserHostAddress));
                return View();
            }


            return View();
        }

        //Return Register view
        public ActionResult Register()
        {
            ViewBag.Equipes = _mapper.Map<IEnumerable<Equipe>, IEnumerable<EquipeViewModel>>(_serviceEquipe.GetAll());
            return View();
        }

        //The form's data in Register view is posted to this method. 
        //We have binded the Register View with Register ViewModel, so we can accept object of Register class as parameter.
        //This object contains all the values entered in the form by the user.
        [HttpPost]
        public ActionResult Register(UsuarioViewModel usuario)
        {
            //We check if the model state is valid or not. We have used DataAnnotation attributes.
            //If any form value fails the DataAnnotation validation the model state becomes invalid.
            if (ModelState.IsValid)
            {
                //create database context using Entity framework 
                _service.Registrar(_mapper.Map<UsuarioViewModel, Usuario>(usuario));

                ViewBag.Message = "Usuário registrado com sucesso";
                return View();
            }
            else
            {

                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        //The login form is posted to this method.
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //Checking the state of model passed as parameter.
            if (ModelState.IsValid)
            {

                //Validating the user, whether the user is valid or not.
                var isValidUser = IsValidUser(model);

                //If user is valid & present in database, we are redirecting it to Welcome page.
                if (isValidUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    //If the username and password combination is not present in DB then error message is shown.
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                //If model state is not valid, the model with error message is returned to the View.
                return View(model);
            }
        }

        //function to check if User is valid or not
        public UsuarioViewModel IsValidUser(LoginViewModel model)
        {
            return _mapper.Map<Usuario, UsuarioViewModel>(_service.LoginValido(model.Email, model.Password));
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index");
        }
    }
}