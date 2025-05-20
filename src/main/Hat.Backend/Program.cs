using Hat.Application.Registeration;
using Hat.Infrastructure.Registeration;

var builder = WebApplication.CreateBuilder(args);

var policy = "ALLOW_ALL";
builder.Services.AddCors(options =>
{
    options.AddPolicy(policy, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
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
else
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

// Comment out or remove the HTTPS redirection middleware to allow HTTP access
// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(policy);
app.MapControllers();

app.Run();


