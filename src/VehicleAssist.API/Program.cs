using VehicleAssist.Application;
using VehicleAssist.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add .env configs
builder.Configuration.AddEnvironmentVariables();

//App layer
builder.Services.AddApplication();

//Infra Layer
builder.Services.AddTemporaryInfrastructure(builder.Configuration);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Todo : Add Authentication
app.UseAuthorization();

app.MapControllers();

app.Run();
