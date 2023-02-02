using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Udemy_Api.DataAccess;
using Udemy_Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecting Db Context into services collection
builder.Services.AddDbContext<ApiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
    
});

builder.Services.AddScoped<IRegionRepository, RegionRepository>();

builder.Services.AddScoped<IWalkRepository, WalkRepository>();

builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
