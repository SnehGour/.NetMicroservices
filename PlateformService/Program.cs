using Microsoft.EntityFrameworkCore;
using PlateformService.Data;
using PlateformService.SyncDataService.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Add Repository to Container
builder.Services.AddScoped<IPlateformRepo,PlateformRepo>();

// Add AutoMapper to Container
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adding HTTP Client to Container
builder.Services.AddHttpClient<ICommandDataClient , HttpCommandDataClient>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Add DbContext to Container

    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
PrepDb.PrepDbPopulation(app);
Console.WriteLine($"--->>{builder.Configuration["CommandService"]}");
app.Run();
