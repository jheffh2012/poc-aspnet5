using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.Ioc.EntityFramework.Context;
using poc.AspNet5.Ioc.Repository;

namespace poc.AspNet5.Ioc.EntityFramework.Repository
{
    public class EventoConfirmacaoRepository : Repository<EventoConfirmacao>, IEventoConfirmacaoRepository
    {

        public EventoConfirmacaoRepository(SqlServerDBContext dbContext) : base(dbContext)
        {

        }
    }
}
