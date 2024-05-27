namespace OnlineCoursePlatform.Logging;

public void ConfigureServices(IServiceCollection services)
{
    services.AddLogging(config =>
    {
        config.AddConsole();
        config.AddDebug();
    });
}