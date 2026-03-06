using Api.Extensions;
using Api.Services;
using LoggingLibrary;

namespace Api;

/// <summary>
/// Точка входа приложения
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Запуск приложения
    /// </summary>
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseInfraSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();

        var provider = host.Services;

        using (var scope1 = provider.CreateScope())
        {
            Console.WriteLine("===== SCOPE 1 =====");

            var sp = scope1.ServiceProvider;

            sp.TestService<ISingletonService1>();
            sp.TestService<ISingletonService2>();

            sp.TestService<IScopedService1>();
            sp.TestService<IScopedService2>();

            sp.TestService<ITransientService1>();
            sp.TestService<ITransientService2>();
        }

        using (var scope2 = provider.CreateScope())
        {
            Console.WriteLine("===== SCOPE 2 =====");

            var sp = scope2.ServiceProvider;

            sp.TestService<ISingletonService1>();
            sp.TestService<ISingletonService2>();

            sp.TestService<IScopedService1>();
            sp.TestService<IScopedService2>();

            sp.TestService<ITransientService1>();
            sp.TestService<ITransientService2>();
        }

        host.Run();
    }
}