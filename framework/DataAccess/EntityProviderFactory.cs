namespace ChatApp.Framework.DataAccess;

using Microsoft.EntityFrameworkCore;

public class EntityProviderFactory
{
    private readonly ChatAppDbContext _context;

    public EntityProviderFactory()
    {
        string connectionString = "Server=localhost;Port=5432;Database=chatapplive;User Id=postgres;Password=admin;";
        var options = new DbContextOptionsBuilder<ChatAppDbContext>()
        .UseNpgsql(connectionString)
        .Options;

        _context = new ChatAppDbContext(options);
    }
    
    public EntityProvider<T> Build<T>() where T : class
    {
        return new EntityProvider<T>(_context);
    }
}
