using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Infrastructure.Temporary;

namespace VehicleAssist.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTemporaryInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, FakeMemberRepository>();

            services.AddScoped<ITokenGenerator, MockTokenGenerator>();


            return services;
        }
    }
}
