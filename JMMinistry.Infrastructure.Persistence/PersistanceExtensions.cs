using JMMinistry.Application.Services;
using JMMinistry.Common;
using JMMinistry.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
#if DEBUG
            services.AddDbContext<JmDbContext>(options =>
                options.UseInMemoryDatabase($"{nameof(JMMinistry)}Db")
            );
            
#else
            services.AddDbContext<JmDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(JmDbContext).Assembly.FullName)));
#endif

            services.AddIdentity<PersonalInfo, Role>()
                .AddEntityFrameworkStores<JmDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.";
            });

            services.Configure<DefaultUser>(configuration.GetSection(nameof(DefaultUser)));

            services.AddScoped<IJmDbContext, JmDbContext>();
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

                if (dbContext.Database.IsRelational())
                    dbContext.Database.Migrate();

                logger.LogInformation("DB migrated to latest state");

            
                //Seed Default Users
                logger.LogInformation("Seeding initial values...");
                var userManager = services.GetRequiredService<UserManager<PersonalInfo>>();
                var roleManager = services.GetRequiredService<RoleManager<Role>>();


                List<Role> ministries =
                    [
                        new Role { Name = Roles.Admin.ToString(), Description = "Admin of the system" },
                        new Role { Name = Roles.Attendance.ToString(), Description = "Manages the attendance to the meetings" },
                        new Role { Name = Roles.Cells.ToString(), Description = "Manages the cells in the ministry" },
                        new Role { Name = Roles.Conventions.ToString(), Description = "Manages the conventions and its attendees" },
                        new Role { Name = Roles.Evangelism.ToString(), Description = "Coordinates the activities to evangelize"},
                        new Role { Name = Roles.Gain.ToString(), Description = "Manages the new ones invited to the ministry and the church"},
                        new Role { Name = Roles.Leader.ToString(), Description = "Manages their own cells" },
                        new Role { Name = Roles.Regular.ToString(), Description = "Regular User" },
                        new Role { Name = Roles.SchoolDirector.ToString(), Description = "Manages the schools in the ministry"},
                        new Role { Name = Roles.Coordinator.ToString(), Description = "Coordinator of a given Ministry"},
                        new Role { Name = Roles.Assistant.ToString(), Description = "Assistant to the coordinator of a given ministry"},
                    ];

                // No need to populate already inserted.
                if (!roleManager.Roles.Any())
                {
                    foreach (var ministry in ministries)
                        await roleManager.CreateAsync(ministry);
                }

                var defaultUser = services.GetRequiredService<IOptions<DefaultUser>>().Value;

                if (defaultUser != null &&  !await userManager.Users.AnyAsync(user => user.Id == defaultUser.Document))
                {
                    var userIdentity = new PersonalInfo
                    {
                        Id = defaultUser.Document,
                        Name = defaultUser.Name,
                        LastName = defaultUser.LastName,
                        UserName = $"{defaultUser.Name.Split(' ')[0]}.{defaultUser.LastName.Split(' ')[0]}",
                    };

                    var createUserResult = await userManager.CreateAsync(userIdentity, defaultUser.Password);

                    if (!createUserResult.Succeeded)
                    {
                        logger.LogError("There was an error creating the default user, errors {errors}", string.Join("\n", createUserResult.Errors.Select(error => $"{error.Code} : {error.Description}")));
                        return;
                    }

                    var addRolesResult = await userManager.AddToRoleAsync(userIdentity, Roles.Admin.ToString());

                    if (!addRolesResult.Succeeded)
                    {
                        logger.LogError("There was an error creating the default user, errors {errors}", string.Join("\n", addRolesResult.Errors.Select(error => $"{error.Code} : {error.Description}")));
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the DB.");
            }

        }
    }
}
