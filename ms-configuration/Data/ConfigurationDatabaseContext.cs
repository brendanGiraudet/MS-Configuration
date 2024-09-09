using Microsoft.EntityFrameworkCore;
using ms_configuration.Models;

namespace ms_configuration.Data;

public class ConfigurationDatabaseContext : DbContext
{
    public ConfigurationDatabaseContext(DbContextOptions<ConfigurationDatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<RabbitMqConfigModel> RabbitMqConfigs { get; set; }
}
