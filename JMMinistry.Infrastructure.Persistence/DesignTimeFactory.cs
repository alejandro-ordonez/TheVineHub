using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
