﻿using Bits_Orchestra_Test_Task.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bits_Orchestra_Test_Task.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<T> DbSet;

        protected BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, bool asNoTracking = false)
        {
            IQueryable<T> query = DbSet;

            if(filter is not null) 
                query = query.Where(filter);

            return asNoTracking ? query.AsNoTracking() : query;
        }
        
        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool asNoTracking = false)
        {
            IQueryable<T> query = DbSet;

            if(filter is not null) 
                query = query.Where(filter);

            return asNoTracking ? await query.AsNoTracking().FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }

        public virtual async Task CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task CreateAllAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void UpdateAll(T[] entities)
        {
            DbSet.UpdateRange(entities);
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
