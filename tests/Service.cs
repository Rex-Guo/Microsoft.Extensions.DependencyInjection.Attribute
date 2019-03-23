using System;
using Microsoft.Extensions.DependencyInjection;

[Inject(ServiceLifetime.Transient,typeof(IService))]
public class Service : IService
{
    public string SayHi()
    {
       return "hello";
    }
}