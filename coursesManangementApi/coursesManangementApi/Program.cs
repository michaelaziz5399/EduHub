using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using coursesManangementApi.Data;
using coursesManangementApi.Services;
using coursesManangementApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(
    option => { option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MappingProfile>();
});


builder.Services.AddScoped<ICourseRepo, CourseRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
