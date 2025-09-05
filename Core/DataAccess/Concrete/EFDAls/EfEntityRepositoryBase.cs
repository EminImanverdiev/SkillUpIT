using Core.DataAccess.Abstract;
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

    public List<TEntity> GetAllFilter(int page, int limit, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
    {
        if (page <= 0) page = 1;
        if (limit <= 0) limit = 10;

        IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return query
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToList();
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
    }
}
