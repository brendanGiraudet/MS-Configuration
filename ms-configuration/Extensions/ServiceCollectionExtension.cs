using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using ms_configuration.Data;
using ms_configuration.Models;
using System.Text.Json.Serialization;


namespace ms_configuration.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<ConfigurationDatabaseContext>(options =>
            options.UseSqlite(connectionString));
    }
    
    public static void AddODataContext(this IServiceCollection services)
    {
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<RabbitMqConfigModel>("RabbitMqConfigs");

        services.AddControllers()
            .AddOData(
                options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100).AddRouteComponents(
                    "odata",
                    modelBuilder.GetEdmModel())
            )
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
    }
}
