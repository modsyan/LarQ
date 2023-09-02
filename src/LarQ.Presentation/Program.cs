using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LarQ.Data;
using LarQ.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ServiceInitializer(builder.Configuration);

var app = builder.Build();

app.ConfigureMiddleware();

app.Run();