using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Presentation.Server.Data.Repositories.Base;

public class GenericRepository<T> : IGenericRepository<T>
      where T : class
{
    private readonly CustomerDbContext _context;
    private readonly DbSet<T> dbSet;

    public GenericRepository(CustomerDbContext context)
    {
        _context = context;
        dbSet = context.Set<T>();
    }

    public virtual EntityState Add(T entity)
    {
        return dbSet.Add(entity).State;
    }

    public T Get<TKey>(TKey id)
    {
        return dbSet.Find(id);
    }

    public async Task<T> GetAsync<TKey>(TKey id)
    {
        return await dbSet.FindAsync(id);
    }

    public T Get(params object[] keyValues)
    {
        return dbSet.Find(keyValues);
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return dbSet.Where(predicate);
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include)
    {
        return FindBy(predicate).Include(include);
    }

    public IQueryable<T> GetAll()
    {
        return dbSet;
    }

    public IQueryable<T> GetAll(int page, int pageCount)
    {
        var pageSize = (page - 1) * pageCount;

        return dbSet.Skip(pageSize).Take(pageCount);
    }

    public IQueryable<T> GetAll(string include)
    {
        return dbSet.Include(include);
    }

    public IQueryable<T> GetAll(string include, string include2)
    {
        return dbSet.Include(include).Include(include2);
    }

    public bool Exists(Expression<Func<T, bool>> predicate)
    {
        return dbSet.Any(predicate);
    }

    public virtual EntityState SoftDelete(T entity)
    {
        entity.GetType().GetProperty("IsDeleted")?.SetValue(entity, false);
        return dbSet.Update(entity).State;
    }

    public virtual EntityState HardDelete(T entity)
    {
        return dbSet.Remove(entity).State;
    }
    public virtual EntityState Update(T entity)
    {
        return dbSet.Update(entity).State;
    }
}
