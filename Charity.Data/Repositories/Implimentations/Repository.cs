using System;
using System.Linq.Expressions;
using Charity.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Charity.Data.Repositories.Impimentations
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var item in includes)
            {
                query = query.Include(item);

            }

            return query.Any(predicate);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var item in includes)
            {
                query = query.Include(item);

            }

            return query.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var item in includes)
            {
                query = query.Include(item);

            }

            return query.Where(predicate);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}

