namespace Venly.Sample
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var isDevelopment = environment == Environments.Development;

                configApp.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                    .AddCommandLine(args)
                    .AddEnvironmentVariables();

                if (isDevelopment)
                {
                    configApp.AddUserSecrets<Startup>();
                }

                configApp.Build();
            })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options => options.AddServerHeader = false);
            webBuilder.UseUrls("http://*:5000", "https://*:5001").UseKestrel();
            webBuilder.UseStartup<Startup>();
        });
    }
}
