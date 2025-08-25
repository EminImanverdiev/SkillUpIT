﻿using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext
{
    protected readonly TContext _context;

    public EfEntityRepositoryBase(TContext context) 
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        return _context.Set<TEntity>().SingleOrDefault(filter);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        return filter == null
            ? _context.Set<TEntity>().ToList()
            : _context.Set<TEntity>().Where(filter).ToList();
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
    }
}
