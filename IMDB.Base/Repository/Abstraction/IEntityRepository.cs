using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IMDB.Base.Repository.Abstraction
{
    public interface IEntityRepository<T>
    {
        bool Any(Expression<Func<T, bool>> exp);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T Get(Expression<Func<T, bool>> exp);
        IList<T> GetList(Expression<Func<T, bool>> exp = null);
      
    }
}
