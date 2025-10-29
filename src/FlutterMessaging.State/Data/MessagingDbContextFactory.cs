using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlutterMessaging.State.Data
{
    public class MessagingDbContextFactory : IDesignTimeDbContextFactory<MessagingDbContext>
    {
        public MessagingDbContext CreateDbContext(string[] args)
        {
            string basePath = Directory.GetCurrentDirectory();
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            string conn = config.GetConnectionString("Local") ?? throw new ArgumentException("Local Db Connection string not found");

            DbContextOptions<MessagingDbContext> options = new DbContextOptionsBuilder<MessagingDbContext>()
                .UseNpgsql(conn)
                .UseSnakeCaseNamingConvention()
                .UseNpgsql(conn, b => b.MigrationsAssembly("FlutterMessaging.State"))
                .Options;

            return new MessagingDbContext(options);
        }
    }
}