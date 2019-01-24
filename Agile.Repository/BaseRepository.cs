using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Agile.Repository.Abstract;
using Agile.Repository.Abstract.IRepository;
using Microsoft.EntityFrameworkCore;


namespace Agile.Repository
{
    public class BaseRepository<T> : IRepository<T> where T :class
    {
        private readonly AgileContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AgileContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public  IQueryable<T> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }
        public void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _dbContext.SaveChanges();
        }

    }
}
