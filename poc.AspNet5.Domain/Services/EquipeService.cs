using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.Ioc.Repository;

namespace poc.AspNet5.Domain.Services
{
    public class EquipeService : ServiceCrud<Equipe>, IEquipeService
    {
        public EquipeService(IEquipeRepository repository) : base(repository)
        {
        }
    }
}
