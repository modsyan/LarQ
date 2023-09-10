using ChustaSoft.Services.StaticData.Configuration;
using ChustaSoft.Services.StaticData.Services;
using LarQ.Startup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LarQ.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationServices(builder.Configuration);

var app = builder.Build();

app.ConfigureApplicationMiddleware();

app.UseHttpsRedirection();

app.Run();