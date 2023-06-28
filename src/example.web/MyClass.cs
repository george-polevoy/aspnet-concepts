using Microsoft.Extensions.Caching.Distributed;

public class MyClass : IMyInterface
{
    // private readonly IDistributedCache _cache;
    //
    // public MyClass(IDistributedCache cache)
    // {
    //     _cache = cache;
    // }

    public string GetFoo()
    {
        return "Hello";
    }
}