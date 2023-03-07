using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Infrastructure.Temporary;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using VehicleAssist.Infrastructure.Authentication;
using VehicleAssist.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace VehicleAssist.Infrastructure
{
    public static class DependencyInjection
    {

#region Testing / Temp Infrastructure 
        public static IServiceCollection AddTemporaryInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuth(configuration);

            services.AddScoped<IMemberRepository, FakeMemberRepository>();
            services.AddScoped<IUnitOfWork,TempUoW>();





            //Temp
            services.AddScoped<IPasswordHasher, MockPasswordHasher>();


            return services;
        }

        #endregion  



        public static IServiceCollection AddInfrastructure (this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuth(configuration);


            string CONN_STRING_NAME = "VehicleAssistDBContext";


            services.AddDbContext<VehicleAssistDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(CONN_STRING_NAME), (sqlServerOptions) =>
                {
                    sqlServerOptions.EnableRetryOnFailure();
                    sqlServerOptions.CommandTimeout(20);
                });
            });

            services.AddScoped<IUnitOfWork>(provider => provider.GetService<VehicleAssistDBContext>());

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IPasswordHasher,PasswordHasher>();


            return services;
            
        }


        public static IServiceCollection AddAuth(this IServiceCollection services,IConfiguration configuration)
        {

            

            TokenConfiguration configObject = new TokenConfiguration();

            configuration.GetSection(configObject.ConfigSectionName).Bind(configObject);

            services.AddSingleton(Options.Create(configObject));

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            


            return services;

        }


    }
}
