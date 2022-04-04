using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using testConsole;

class Program
{
   public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var executor = scope.ServiceProvider.GetRequiredService<ITest>();
            executor.TestMethod();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
           .ConfigureAppConfiguration((hostingContext, config) =>config.AddJsonFile("appsettings.json"))
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IConfiguration>(hostContext.Configuration);
                services.AddScoped<ITest, Test>();
            });

    
}
