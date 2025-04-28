using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JMMinistry.Infrastructure.Persistence
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<JmDbContext>
    {
        public JmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JmDbContext>();
            optionsBuilder.UseNpgsql(
                   "Host=192.168.2.13:5432;Database=jm-db;Username=jm-db;Password=jm-ministry-2024",
                   b => b.MigrationsAssembly(typeof(JmDbContext).Assembly.FullName));

            return new JmDbContext(optionsBuilder.Options);
        }
    }
}
