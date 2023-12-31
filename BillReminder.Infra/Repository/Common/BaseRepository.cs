﻿using BillReminder.Domain.Entities.Common;
using BillReminder.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BillReminder.Infra.Repository.Common;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
{
    protected readonly BillReminderContext _context;

    public BaseRepository(BillReminderContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);

        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);

        return await Task.FromResult(entity);
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<bool> ExistAsync(Guid id)
    {
        return await _context.Set<TEntity>().AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
