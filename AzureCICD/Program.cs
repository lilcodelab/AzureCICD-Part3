using Core.Interfaces;
using Core.Services;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var _configuration = builder.Configuration;

// Add services to the container.

//zapisat da moram eksplicitno dodat referencu sa webapi na core, sa core na infrastructure kroz csproj
//inače nije mogao iz web apia prepoznat AzureCICDDbContext

//zapisat da moram entity framework design instalirat u web api inače migracije ne rade

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<AzureCICDDbContext>(
                options => options.UseSqlServer(
                    _configuration.GetConnectionString("LocalDBConnectionString"))
                );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//privremeno zakomentirano zbogo ovog errora
//Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
//Failed to determine the https port for redirect.
//app.UseHttpsRedirection();

//dodano zbog UI
app.UseStaticFiles();

app.UseRouting();

app.UseCors("CorsPolicy");

app.MapControllers();
//dodano zbog UI
app.MapFallbackToFile("index.html");

app.Run();
