using Hat.Application.Registeration;
using Hat.Infrastructure.Registeration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register infrastructure repositories (choose the type: "Memory", "SqlServer", or "Http")
#region hat services
builder.Services.AddHatRepositories("Memory");
builder.Services.AddHatApplications("Hat.Application");
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
