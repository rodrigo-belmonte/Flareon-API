using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ADT.Flareon.Application.Intefaces.Services.Auth.Commands;
using ADT.Flareon.Application.Services.Auth.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
