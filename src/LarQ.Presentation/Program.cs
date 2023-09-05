using LarQ.Startup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LarQ.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

// var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ServiceInitializer(builder.Configuration);

var app = builder.Build();

app.ConfigureMiddleware();

app.Run();