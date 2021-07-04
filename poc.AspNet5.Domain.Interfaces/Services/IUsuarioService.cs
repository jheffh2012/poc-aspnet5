using poc.AspNet5.Ioc.Entities;

namespace poc.AspNet5.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceCrud<Usuario>
    {
        Usuario Registrar(Usuario model);
        Usuario LoginValido(string email, string senha);

        Usuario BuscarDadosDoUsuario(string email);
    }
}
