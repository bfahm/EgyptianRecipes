using EgyptianRecipes.Models;
using EgyptianRecipes.Persistence.DbContexts;
using EgyptianRecipes.Persistence.Repositories.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptianRecipes.Persistence
{
    public static class DbSeeder
    {
        public static async Task SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                var branchRepository = scope.ServiceProvider.GetService<IBranchRepository>();

                await SeedAdmin(userManager);
                await SeedBranches(branchRepository);
            }
        }

        private static async Task SeedAdmin(UserManager<ApplicationUser> userManager)
        {
            const string ADMIN_EMAIL = "admin@egyptianrecipes.com";
            const string ADMIN_USERNAME = "admin";
            const string ADMIN_PWD = "Admin@123";

            var existingAdmin = await userManager.FindByEmailAsync(ADMIN_EMAIL);
            if (existingAdmin != null)
                return;

            var result = await userManager.CreateAsync(new ApplicationUser
            {
                Email = ADMIN_EMAIL,
                NormalizedEmail = ADMIN_EMAIL.ToUpper(),
                EmailConfirmed = true,
                UserName = ADMIN_USERNAME,
                NormalizedUserName = ADMIN_USERNAME.ToUpper(),
                FullName = "Admin"
            });

            if (!result.Succeeded)
            {
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error.Description + "\n";
                }
                throw new Exception($"An error occured while trying to seed admin user: {errors}");
            }

            var seededUser = await userManager.FindByEmailAsync(ADMIN_EMAIL);
            var pwdResult = await userManager.AddPasswordAsync(seededUser, ADMIN_PWD);
            if (!pwdResult.Succeeded)
            {
                string errors = "";
                foreach (var error in pwdResult.Errors)
                {
                    errors += error.Description + "\n";
                }
                throw new Exception($"An error occured while trying to seed admin user: {errors}");
            }
        }

        private static async Task SeedBranches(IBranchRepository branchRepo)
        {
            var existingBranches = await branchRepo.GetAllAsync();
            if (existingBranches != null && existingBranches.Count() > 0)
                return;

            var branch1 = new Branch
            {
                Title = "Branch One",
                ManagerName = "Brook Ward",
                OpeningHour = new TimeSpan(12, 30, 0),
                ClosingHour = new TimeSpan(22, 30, 0),
            };

            var branch2 = new Branch
            {
                Title = "Branch Two",
                ManagerName = "Glenn Boyce",
                OpeningHour = new TimeSpan(12, 30, 0),
                ClosingHour = new TimeSpan(22, 30, 0),
            };

            var branch3 = new Branch
            {
                Title = "Branch Three",
                ManagerName = "Sheree Ann",
                OpeningHour = new TimeSpan(12, 30, 0),
                ClosingHour = new TimeSpan(22, 30, 0),
            };

            var branch4 = new Branch
            {
                Title = "Branch Four",
                ManagerName = "Edison Rebecca",
                OpeningHour = new TimeSpan(12, 30, 0),
                ClosingHour = new TimeSpan(22, 30, 0),
            };


            await branchRepo.AddAsync(branch1);
            await branchRepo.AddAsync(branch2);
            await branchRepo.AddAsync(branch3);
            await branchRepo.AddAsync(branch4);
        }
    }
}