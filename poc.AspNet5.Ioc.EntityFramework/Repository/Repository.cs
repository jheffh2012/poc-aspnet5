﻿using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.Ioc.EntityFramework.Context;
using poc.AspNet5.Ioc.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace poc.AspNet5.Ioc.EntityFramework.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        public readonly SqlServerDBContext _dbContext;

        public Repository(SqlServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll(string[] includes, Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public TEntity GetById(BaseModel Id, string[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();
            query.Where(e => e.Id == Id.Id);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.FirstOrDefault();
        }


        public void Add(TEntity model)
        {
            _dbContext.Set<TEntity>().Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void Delete(TEntity model)
        {
            _dbContext.Entry(model).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
