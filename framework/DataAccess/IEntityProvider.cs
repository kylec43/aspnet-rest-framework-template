namespace ChatApp.Framework.DataAccess;

using Microsoft.EntityFrameworkCore;

public interface IEntityProvider<T> where T : class
{
    public DbSet<T>? Get();
    public T? Get(Func<T, bool> condition);
    public List<T> GetAll();
    public void Add(T entity);
}