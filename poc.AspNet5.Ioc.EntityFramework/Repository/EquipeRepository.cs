using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.Ioc.EntityFramework.Context;
using poc.AspNet5.Ioc.Repository;

namespace poc.AspNet5.Ioc.EntityFramework.Repository
{
    public class EquipeRepository : Repository<Equipe>, IEquipeRepository
    {

        public EquipeRepository(SqlServerDBContext dbContext) : base(dbContext)
        {

        }
    }
}
