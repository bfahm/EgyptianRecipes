using EgyptianRecipes.Core.Mappers;
using EgyptianRecipes.Core.Services;
using EgyptianRecipes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EgyptianRecipes.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAutomapper(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new BranchesProfile());
                cfg.AddProfile(new BookingsProfile());
                cfg.ConstructServicesUsing(type => ActivatorUtilities.CreateInstance(serviceProvider, type));
            });

            return services;
        }

        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddAutomapper();

            services.AddScoped<UserService>();
            services.AddScoped<BranchService>();
            services.AddScoped<BookingService>();

            return services;
        }
    }
}
