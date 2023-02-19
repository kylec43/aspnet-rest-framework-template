namespace ChatApp.Framework.DataAccess;

using Microsoft.EntityFrameworkCore;

public class EntityProvider<T>: IEntityProvider<T> where T : class
{
    private readonly ChatAppDbContext _context;

    public EntityProvider(ChatAppDbContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? Get(Func<T, bool> condition)
    {
        return  _context.Set<T>().SingleOrDefault(condition);
    }

    public DbSet<T>? Get()
    {
        return _context.Set<T>();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }
}
