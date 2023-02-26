using CleanCQRS.API.Extensions;
using CleanCQRS.Application.Extensions;
using CleanCQRS.Infrastructure.Data;
using CleanCQRS.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApi(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
var app = builder.Build();

// // Ensure the database is created.
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();
context.SeedData();


// Configure the HTTP request pipeline.
app.UseApi();

app.Run();