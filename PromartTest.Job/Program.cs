using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromartTest.Data.Context;
using PromartTest.Job.Extensions;
using PromartTest.Job.Jobs.Services;
using PromartTest.Job.Options;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
    .AddDbContext<ApplicationDbContext>(options => options
        .UseSqlServer(connectionString));

builder.Services.Configure<FilterOptions>
     (builder.Configuration.GetSection(nameof(FilterOptions)));

builder.Services.Configure<SmtpOptions>
     (builder.Configuration.GetSection(nameof(SmtpOptions)));

builder.Services.AddCronJob<ReportService>(options =>
{
    // Corre cada minuto
    options.CronExpression = "* * * * *";
    options.TimeZone = TimeZoneInfo.Local;
});

var app = builder.Build();

app.Run();
