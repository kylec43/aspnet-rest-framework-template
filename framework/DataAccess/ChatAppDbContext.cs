namespace ChatApp.Framework.DataAccess;  

using Microsoft.EntityFrameworkCore;
using ChatApp.Framework.Util;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;

public class ChatAppDbContext : DbContext
{  
    public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)  
    {  
    }

    private bool GetFirstOrDefaultMethod(MethodInfo methodInfo)
    {
        return (
            methodInfo.Name.Equals("Entity", StringComparison.OrdinalIgnoreCase) &&
            methodInfo.IsGenericMethod
        );
            
    }

    protected override void OnModelCreating(ModelBuilder builder)  
    {  
        base.OnModelCreating(builder);

        var modelTypes = ReflectionTool.GetTypesFromNameSpace("ChatApp.Database.Models");
        foreach (var modelType in modelTypes)
        {
            var tableAttribute = modelType.GetCustomAttribute<TableAttribute>();
            string tableName = tableAttribute?.Name ?? modelType.Name.ToLower();
            builder.Entity(modelType).ToTable(tableName);
        }
    }  

    public override int SaveChanges()  
    {  
        ChangeTracker.DetectChanges();  
        return base.SaveChanges();  
    }  
}  

