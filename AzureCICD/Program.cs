var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

//privremeno zakomentirano zbogo ovog errora
//Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
//Failed to determine the https port for redirect.
//app.UseHttpsRedirection();

//dodano zbog UI
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
//dodano zbog UI
app.MapFallbackToFile("index.html");

app.Run();
