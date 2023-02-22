namespace ChatApp.Framework.DataAccess;

using Microsoft.EntityFrameworkCore;

public class ProviderFactory
{   
    private readonly IConfiguration _configuration;

    public ProviderFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public EntityProvider<T> Build<T>() where T : class
    {
        return new EntityProvider<T>(new ChatAppDbContext(_configuration));
    }
}
