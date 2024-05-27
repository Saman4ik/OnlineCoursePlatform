﻿using Microsoft.EntityFrameworkCore;
using OnlineCoursePlatform.Data;

namespace OnlineCoursePlatform.Repositorys;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
        =>await _dbSet.ToListAsync();

    public async Task<T> GetById(int id)
        => await _dbSet.FindAsync(id);

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
