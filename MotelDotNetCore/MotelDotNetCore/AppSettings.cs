namespace MotelDotNetCore;

public class AppSettings
{
    private static AppSettings? _appSettings;

    private string? AppSettingValue { get; set; }

    public static string? Get(string key)
    {
        _appSettings = GetCurrentSettings(key);
        return _appSettings.AppSettingValue;
    }

    public AppSettings(IConfiguration config, string key)
    {
        AppSettingValue = config.GetValue<string>(key);
    }

    private static AppSettings GetCurrentSettings(string key)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        var settings = new AppSettings(configuration, key);

        return settings;
    }
}