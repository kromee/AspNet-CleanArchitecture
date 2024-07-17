using AspNet_CleanArchitecture.Application;
using AspNet_CleanArchitecture.Application.Interfaces;
using AspNet_CleanArchitecture.Infraestructure.Reports;
using AspNet_CleanArchitecture.Infrastructure.Photos;
using AspNet_CleanArchitecture.Persistence;
using AspNet_CleanArchitecture.Persistence.Models;
using AspNet_CleanArchitecture.WebApi.Extensions;
using CleanArchitecture.WebApi.Extensions;
using CleanArchitecture.WebApi.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPoliciesServices();


builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(nameof(CloudinarySettings)));
builder.Services.AddScoped(typeof(IPhotoService), typeof(PhotoService));




builder.Services.AddScoped(typeof(IReportService<>), typeof(ReportService<>));
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllers();

builder.Services.AddSwaggerDocumentation();




var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.MapOpenApi();
}

app.useSwaggerDocumentation ();


app.UseAuthentication();
app.UseAuthorization();

await app.SeedDataAuthentication();


app.MapControllers();
app.Run();
