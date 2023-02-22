namespace ChatApp.Framework.DataAccess;  

using Microsoft.EntityFrameworkCore;
using ChatApp.Framework.Util;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Framework.Interfaces;

public class ChatAppDbContext : DbContext
{  
    private readonly IConfiguration _configuration;

    public ChatAppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
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

        var modelTypes = ReflectionTool.GetTypesImplementingInterface(typeof(IDatabaseModel));
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        string? server = _configuration.GetValue<string>("DatabaseConnection:Server");
        string? port = _configuration.GetValue<string>("DatabaseConnection:Port");
        string? userId = _configuration.GetValue<string>("DatabaseConnection:UserId");
        string? password = _configuration.GetValue<string>("DatabaseConnection:Password");
        string? database = _configuration.GetValue<string>("DatabaseConnection:Database");

        optionsBuilder.UseNpgsql($"Server={server};Port={port};Database={database};User Id={userId};Password={password}");
    }
}
}  

