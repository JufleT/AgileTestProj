using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Agile.Repository.Abstract.IRepository
{
    public interface IRepository<T> where T: class 
    {
        void Create(T item);
        T FindById(int id);
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Remove(T item);
        void Update(T item);

    }
}
