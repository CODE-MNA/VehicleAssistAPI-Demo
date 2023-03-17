using Microsoft.OpenApi.Models;
using System.Security.Claims;
using VehicleAssist.API.Models;
using VehicleAssist.Application;
using VehicleAssist.Domain;
using VehicleAssist.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add .env configs
builder.Configuration.AddEnvironmentVariables();

//App layer
builder.Services.AddApplication();

builder.Services.AddHttpContextAccessor();


//Infra Layer
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Environment.ApplicationName,
        Version = "v1"
    });
    gen.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Description = "JWT Authorization header {token}",
        Name = "Authentication",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });
    gen.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                },
                BearerFormat = "JWT"
            },
            new string[] {}
        }
    });
});





var app = builder.Build();
app.Use(async (context, next) =>
{
    try
    {
        try
        {
            await next.Invoke();
        }
        catch (AbstractDomainException ex)
        {
            List<string> errors = new List<string>();

            errors.Add(ex.Message);
            ErrorModel errorModel = new ErrorModel()
            {
                StatusCode = ex.StatusCode,
                ErrorMessage = errors

            };


            await context.Response.WriteAsJsonAsync<ErrorModel>(errorModel);
        }
        catch (Exception ex)
        {
            List<string> errors = new List<string>();
            errors.Add("Unexpected Server Error");

            if (app.Environment.IsDevelopment())
            {
                errors.Add("Internal : " + ex.Message);
                errors.Add("Stack Trace : " + ex.StackTrace);
                errors.Add("Source : " + ex.Source);
                errors.Add("internal internal " + ex.InnerException?.Message);
                errors.Add("internal internal internal : " + ex.InnerException?.InnerException?.Message);
            }


            ErrorModel errorModel = new ErrorModel()
            {
                StatusCode = 500,
                ErrorMessage = errors,

            };
           var task =  context.Response.WriteAsJsonAsync<ErrorModel>(errorModel);
            await task;

        }
    }catch (Exception ex)
    {
    ;
    }
  

});


if (app.Environment.IsDevelopment())
{
    //dev
    

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x =>
    {
        x.AllowAnyOrigin();
        x.AllowAnyHeader();
        
    });

}
else
{
    //prod
    app.UseHttpsRedirection();


}



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
