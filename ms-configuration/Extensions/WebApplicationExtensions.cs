using Microsoft.EntityFrameworkCore;
using ms_configuration.Data;

namespace ms_configuration.Extensions;

public static class WebApplicationExtensions
{
    public static void ApplyDatabaseMigrations(this WebApplication webApplication)
    {
        using var serviceScope = webApplication.Services.GetService<IServiceScopeFactory>()?.CreateScope();

        serviceScope?.ServiceProvider.GetRequiredService<ConfigurationDatabaseContext>().Database.Migrate();
    }
}