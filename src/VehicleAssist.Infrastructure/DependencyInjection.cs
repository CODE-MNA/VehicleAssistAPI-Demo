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
using VehicleAssist.Infrastructure.Email;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using VehicleAssist.Infrastructure.CustomerServices;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Reminders;

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
            services.AddMailing(configuration);

            services.AddDatabasePersistence(configuration);

            //Other Services
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IVerificationEmail, VerificationEmail>();


            return services;

        }

        private static void AddDatabasePersistence(this IServiceCollection services, IConfiguration configuration)
        {
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
            services.AddScoped<IBaseRepository<Reminder>, EFRepository<Reminder>>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();


            //Generic
            services.AddScoped<IBaseRepository<Vehicle>,EFRepository<Vehicle>>();

        }


        public static IServiceCollection AddMailing(this IServiceCollection services,IConfiguration configuration)
        {
            MailSettings settings = new MailSettings();

            configuration.GetSection(settings.ConfigSectionName).Bind(settings);

            
         
            services.AddSingleton(Options.Create(settings));

            SmtpClient client = new SmtpClient(settings.SmtpServer)
            {
             
                Port = settings.SmtpPort,
                EnableSsl = true,
                Credentials = new NetworkCredential(settings.FromEmail,settings.FromPass)
                
            };
         


            services.AddFluentEmail(settings.FromEmail)
                .AddSmtpSender(client)
                .AddRazorRenderer();

            services.AddScoped<IMailService, MailService>();

            return services;
        }


        public static IServiceCollection AddAuth(this IServiceCollection services,IConfiguration configuration)
        {

            

            TokenConfiguration configObject = new TokenConfiguration();

            configuration.GetSection(configObject.ConfigSectionName).Bind(configObject);

            services.AddSingleton(Options.Create(configObject));

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwt => jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configObject.Issuer,
                    ValidAudience = configObject.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configObject.Secret))
                });


            return services;

        }


    }
}
