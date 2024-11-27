using Association.Application.Behaviors;
using Association.Application.Common;
using Association.Application.Services.DonationCategories;
using Association.Application.Services.DonationForms;
using Association.Application.Services.DonationGroups;
using Association.Application.Services.DonationOptions;
using Association.Application.Services.DonationShares;
using Association.Application.Services.Donors;
using Association.Application.Services.IntentionTypes;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Association.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<IDonationCategoryService, DonationCategoryManager>();
        services.AddScoped<IDonationFormService, DonationFormManager>();
        services.AddScoped<IDonationGroupService, DonationGroupManager>();
        services.AddScoped<IDonationOptionService, DonationOptionManager>();
        services.AddScoped<IDonationShareService, DonationShareManager>();
        services.AddScoped<IDonorService, DonorManager>();
        services.AddScoped<IIntentionTypeService, IntentionTypeManager>();

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
