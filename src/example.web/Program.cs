using System.Runtime.InteropServices.ComTypes;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddInMemoryCollection();
builder.Configuration.AddEtcd();

builder.Services.AddSingleton<IMyInterface, MyClass>();

var app = builder.Build();

app.MapGet("/", (IMyInterface my) =>
{
    return app.Configuration["X"];;
});

app.Run();

public class EtcdConfigSource : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new EtcdConfigurationProvider();
    }
}

public class EtcdConfigurationProvider : ConfigurationProvider
{
    public EtcdConfigurationProvider()
    {
        Data["X"] = "Data for X";

        async Task UpdateRegularly()
        {
            while (true)
            {
                await Task.Delay(100);
                Data["X"] = $"Data for X. Updated at: {DateTime.Now:O}";
            }
        }

        _ = UpdateRegularly();
    }
}

public static class EtcdConfigExtensions
{
    public static IConfigurationBuilder AddEtcd(this IConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Add(new EtcdConfigSource());
        return configurationBuilder;
    }
}