using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace example.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var sc = new ServiceCollection();

        sc.AddSingleton<IMyInterface, MyClass>();

        sc.AddDistributedMemoryCache();

        var sp = sc.BuildServiceProvider();

        var s = sp.GetRequiredService<IMyInterface>();

        Assert.That(s.GetFoo(), Is.EqualTo("Hello"));
    }

    public void Test2()
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder
            .AddJsonFile("a")
            .AddEnvironmentVariables();

    }
}