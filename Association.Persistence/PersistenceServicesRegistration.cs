using Association.Application.Repositories;
using Association.Persistence.Context;
using Association.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Association.Persistence;
public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AssociationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetSection("MsSqlConfiguration:ConnectionString").Value);
            //options.UseInMemoryDatabase("DonationTestDb");
        });

        services.AddScoped<IDonorRepository, DonorRepository>();
        services.AddScoped<IDonationGroupRepository, DonationGroupRepository>();
        services.AddScoped<IDonationCategoryRepository, DonationCategoryRepository>();
        services.AddScoped<IDonationOptionRepository, DonationOptionRepository>();
        services.AddScoped<IDonationFormRepository, DonationFormRepository>();
        services.AddScoped<IDonationShareRepository, DonationShareRepository>();
        services.AddScoped<IIntentionTypeRepository, IntentionTypeRepository>();

        return services;
    }
}
