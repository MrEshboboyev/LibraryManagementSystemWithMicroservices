﻿using LibraryMS.Services.Loan.Application.Common.Interfaces;
using LibraryMS.Services.Loan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryMS.Services.Loan.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    // inject DI, internal DbSet<T>
    private readonly LoanDbContext _db;
    internal DbSet<T> dbSet;
    private static readonly char[] separator = [','];

    public Repository(LoanDbContext db)
    {
        _db = db;
        dbSet = _db.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
    {
        return await dbSet.AnyAsync(filter);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
    {
        IQueryable<T> query;
        if (tracked)
        {
            query = dbSet;
        }
        else
        {
            query = dbSet.AsNoTracking();
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            foreach (var property in includeProperties
                .Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property.Trim());
            }
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false)
    {
        IQueryable<T> query;
        if (tracked)
        {
            query = dbSet;
        }
        else
        {
            query = dbSet.AsNoTracking();
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            foreach (var property in includeProperties
                .Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property.Trim());
            }
        }

        return await query.ToListAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        dbSet.Remove(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        dbSet.Update(entity);
    }
}
