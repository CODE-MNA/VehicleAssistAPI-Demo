using VehicleAssist.Application;
using VehicleAssist.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


//App layer
builder.Services.AddApplication();

//Infra Layer
builder.Services.AddTemporaryInfrastructure();



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
