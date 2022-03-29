using Microsoft.EntityFrameworkCore;
using Foodstack.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FoodstackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodstackContext")));

builder.Services.AddCors();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISpoonacularClient, SpoonacularClient>(x => new SpoonacularClient(builder.Configuration.GetValue<string>("SpoonacularApiKey")));
var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

app.UseAuthorization();

app.MapControllers();

app.Run();
