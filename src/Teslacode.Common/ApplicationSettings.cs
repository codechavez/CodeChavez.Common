using Microsoft.Extensions.Configuration;

namespace CodeChavez.Common;

public static class ApplicationSettings
{
    public static IConfiguration GetBaseConfiguration()
    {
        IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        return _configuration;
    }

    public static IConfiguration? GetLocalConfiguration(string path)
    {
        if (string.IsNullOrEmpty(path))
            return null;

        if (!File.Exists(path))
            return null;

        string? setBase = Path.GetDirectoryName(path);
        string file = Path.GetFileName(path);

        IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(setBase)
            .AddJsonFile(file, optional: true, reloadOnChange: true)
            .Build();

        return _configuration;
    }
}
