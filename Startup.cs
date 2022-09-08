[assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(Backroom.Functions.Startup))]

namespace Backroom.Functions;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Backroom.Functions.Objects.EntityFrameworkCore;

public class Startup : FunctionsStartup
{
    public IConfiguration? Configuration { get; set; }

    public Startup() { }
    public Startup(IConfiguration confguration) => this.Configuration = confguration;

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        builder.ConfigurationBuilder.AddEnvironmentVariables();
        // builder.ConfigurationBuilder.AddUserSecrets<Startup>();
        _ = builder.ConfigurationBuilder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
    }

#pragma warning disable IDE0022 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter
    public override void Configure(IFunctionsHostBuilder builder)
    {
        foreach (var key in builder.GetContext().Configuration.AsEnumerable())
        {
            Console.WriteLine($"{key.Key} = {key.Value}");
        }
        foreach (var key in builder.GetContext().Configuration.GetSection("ConnectionStrings").AsEnumerable())
        {
            Console.WriteLine($"{key.Key} = {key.Value}");
        }
        Console.WriteLine(builder.GetContext().Configuration);
        var connectionString = builder.GetContext().Configuration.GetConnectionString("BackroomBotsDbConnectionString") ?? string.Empty;
        Console.WriteLine("Connection string: " + connectionString);
        _ = (builder?.Services?.AddDbContext<ObjectsDbContext>(options =>
        {
            _ = (options?.UseSqlServer(connectionString));
        }));
    }
}