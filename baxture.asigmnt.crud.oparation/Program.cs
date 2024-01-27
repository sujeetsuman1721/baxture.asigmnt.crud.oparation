using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Autofac.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        LoggingLevelSwitch loggingLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Information);
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(loggingLevelSwitch)
            .MinimumLevel.Override("Microsoft",loggingLevelSwitch)
            .Enrich.FromLogContext()
            .WriteTo.Async(a =>a.Console(new CompactJsonFormatter()))
            .CreateLogger();

        try
        {
            Log.Information("Starting web host");
            loggingLevelSwitch.MinimumLevel = GetLogLevel();
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminal ended unexpected");
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).UseSerilog()
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });

  

    private static LogEventLevel GetLogLevel()
    {
        LogEventLevel level = LogEventLevel.Information;
        string? logLLevel = Environment.GetEnvironmentVariable("baxture_logLevel")?.ToLower();
        if(!string.IsNullOrEmpty(logLLevel))
        {
           if(logLLevel == LogEventLevel.Debug.ToString().ToLower())
            {
                level = LogEventLevel.Debug;
            }

            if (logLLevel == LogEventLevel.Error.ToString().ToLower())
            {
                level = LogEventLevel.Error;
            }

            if (logLLevel == LogEventLevel.Warning.ToString().ToLower())
            {
                level = LogEventLevel.Warning;
            }
            if (logLLevel == LogEventLevel.Fatal.ToString().ToLower())
            {
                level = LogEventLevel.Fatal;
            }
        }
  

        return level;
    }
}
