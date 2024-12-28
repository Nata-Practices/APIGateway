using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Properties/appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("Properties/appsettings.Development.json", optional: true, reloadOnChange: true)
            .AddJsonFile("Properties/ocelot.json", optional: false, reloadOnChange: true);
        
        builder.Services.AddControllers();
        builder.Services.AddOcelot();

        var app = builder.Build();

        app.MapControllers();
        app.UseOcelot().Wait();

        app.Run();
    }
}