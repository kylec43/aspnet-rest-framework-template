using ChatApp.Profile.Inputs;
using FluentValidation;
using ChatApp.Framework.Util;
using ChatApp.Framework.DataAccess;
using ChatApp.Framework.Interfaces;

public static class DependencyConfiguration
{
    private static void AddServiceDependencies(IServiceCollection services)
    {
        var serviceTypes = ReflectionTool.GetTypesImplementingInterface(typeof(IService));
        foreach (var serviceType in serviceTypes)
        {
            services.AddScoped(serviceType);
        }
    }

    public static void Configure(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ProfileIdValidator>();
        services.AddScoped<ProviderFactory>();
        DependencyConfiguration.AddServiceDependencies(services);
    }
}