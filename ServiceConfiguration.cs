using FluentValidation.AspNetCore;

public static class ServiceConfiguration
{
    public static void Configure(IServiceCollection services)
    {
        services.AddControllers();

        // Configure Auto Validation
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}