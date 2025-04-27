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
                   "DefaultConnection",
                   b => b.MigrationsAssembly(typeof(JmDbContext).Assembly.FullName));

            return new JmDbContext(optionsBuilder.Options);
        }
    }
}
