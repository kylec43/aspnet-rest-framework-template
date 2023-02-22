using FluentValidation.AspNetCore;
using ChatApp.Framework.DataAccess;

public static class ServiceConfiguration
{
    public static void Configure(IServiceCollection services)
    {
        services.AddControllers();

        // Configure Auto Validation
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ChatAppDbContext>();
    }
}