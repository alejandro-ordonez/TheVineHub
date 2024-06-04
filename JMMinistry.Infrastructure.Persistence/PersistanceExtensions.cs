using JMMinistry.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Infrastructure.Persistence
{
    public static class PersistenceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JmDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(JmDbContext).Assembly.FullName)));
        }

        public static async void InitializeDb(this IHost app)
        {
            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<IHost>();

            try
            {
                // Run migrations
                logger.LogInformation("Preparing DB");
                using var dbContext = services.GetRequiredService<JmDbContext>();
                dbContext.Database.Migrate();
                logger.LogInformation("DB migrated to latest state");

            
                //Seed Default Users
                logger.LogInformation("Seeding initial values...");
                var userManager = services.GetRequiredService<UserManager<PersonalInfo>>();
                var roleManager = services.GetRequiredService<RoleManager<Ministry>>(new Ministry { Name = "Gain", Description = "Ministry that manages the new members",  });
                
                await roleManager.CreateAsync()

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the DB.");
            }

        }
    }
}
