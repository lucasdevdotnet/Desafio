using Desafio.Dominio.DomainServices;
using Desafio.Dominio.Interfaces.ServicesInterface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Desafio.CrossCutting.Ioc.Infrastructure.Container
{
    public static class NativeInjectorBootStrapper
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ISenhaService, SenhaService>();
        }
    }
}
