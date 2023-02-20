using ChatApp.Framework.Util;
using ChatApp.Framework.Input;

public static class DependencyConfiguration
{
    public static void Configure(IServiceCollection services)
    {
        services.AddScoped<IValidationMediator, ValidationMediator>();
    }
}