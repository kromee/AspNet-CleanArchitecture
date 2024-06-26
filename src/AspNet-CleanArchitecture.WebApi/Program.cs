using AspNet_CleanArchitecture.Application;
using AspNet_CleanArchitecture.Persistence;
using AspNet_CleanArchitecture.Persistence.Models;
using CleanArchitecture.WebApi.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddIdentityCore<AppUser>(opt => {
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = true;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await app.SeedDataAuthentication();


app.MapControllers();
app.Run();
