using poc.AspNet5.Ioc.Entities;
using System.Collections.Generic;

namespace poc.AspNet5.Domain.Interfaces.Services
{
    public interface IServiceCrud<TEntity> where TEntity : BaseModel
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id, string[] includes = null);
        void Add(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
    }
}
