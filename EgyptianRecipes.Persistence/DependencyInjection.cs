using EgyptianRecipes.Models;
using EgyptianRecipes.Persistence.DbContexts;
using EgyptianRecipes.Persistence.Repositories;
using EgyptianRecipes.Persistence.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EgyptianRecipes.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(appSettings.SQLServerConnectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            return services;
        }
    }
}
