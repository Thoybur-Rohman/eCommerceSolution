﻿using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Infrastructure.Data;

using eCommerceApp.Domain.Entities;
using eCommerceApp.Application.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace eCommerceApp.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext context) : IGeneric<TEntity> where TEntity : class
    {
        public async Task<int> AddAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync();

        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id) ?? throw new ItemNotFoundException($"Item with {id} is not found");
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
           var result = await context.Set<TEntity>().FindAsync(id);
            return result;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync();
        }
    }
}
