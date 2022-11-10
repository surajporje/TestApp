using CommunityToolkit.Maui.Markup;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Datadog.Logs;

namespace TestApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).
             UseMauiApp<App>().UseMauiCommunityToolkitMarkup()

             .Logging.AddSerilog(SetupSerilog(), dispose: true);

        //  builder.UseSerilog((context, lc) => lc.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

        return builder.Build();


    }

    private static ILogger SetupSerilog()
    {

        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .WriteTo.DatadogLogs("", configuration: new DatadogConfiguration() { Url = "https://http-intake.logs.datadoghq.com" })
        .CreateLogger();

        return Log.Logger;
    }
}
