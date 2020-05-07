using IMDB.Base.Repository.Abstraction;
using IMDB.DAL.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IMDB.DAL.Repository.BaseRepositoryEF
{
    public class EntityRepositoryEF<T, TContext> : IEntityRepository<T> where T : class where TContext : DbContext, new()
    {

        public async void Add(T item)
        {
            using (var db = new TContext())
            {
                var addedEntity = db.Entry(item);
                addedEntity.State = EntityState.Added;
                await db.SaveChangesAsync();
            }


        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            using (var db = new TContext())
            {
                return db.Set<T>().Any(exp);
            }
        }

        public async void Delete(T item)
        {
            using (var db = new TContext())
            {
                var deletedEntity = db.Entry(item);
                deletedEntity.State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
        }

        public T Get(Expression<Func<T, bool>> exp)
        {
            using (var db = new TContext())
            {
                return db.Set<T>().FirstOrDefault(exp);
            }
        }

        public  IList<T> GetList(Expression<Func<T, bool>> exp = null)
        {
            using (var db = new TContext())
            {
                return exp == null ? db.Set<T>().ToList() : db.Set<T>().Where(exp).ToList();
            }
        }

        public async void Update(T item)
        {
            using (var db = new TContext())
            {
                var updatedEntity = db.Entry(item);
                updatedEntity.State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

    }
}
