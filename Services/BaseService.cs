﻿using System.Linq.Expressions;
using Bits_Orchestra_Test_Task.Repositories;

namespace Bits_Orchestra_Test_Task.Services
{
    public abstract class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T>
        where T : class
    {
        public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool asNoTracking = false)
        {
            return await repository.GetAsync(filter, asNoTracking);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, bool asNoTracking = false)
        {
            return repository.GetAll(filter, asNoTracking);
        }

        public Task CreateAsync(T entity)
        {
            repository.CreateAsync(entity);

            return repository.SaveAsync();
        }

        public Task CreateAllAsync(IEnumerable<T> entities)
        {
            repository.CreateAllAsync(entities);

            return repository.SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            repository.Update(entity);

            await repository.SaveAsync();
        }

        public async Task UpdateAllAsync(T[] entities)
        {
            repository.UpdateAll(entities);

            await repository.SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            repository.Delete(entity);

            await repository.SaveAsync();
        }
    }
}
