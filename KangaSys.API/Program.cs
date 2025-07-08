// <copyright file="Program.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.API
{
    using KangaSys.API.Extensions;
    using KangaSys.API.Middleware;
    using KangaSys.Application.Interfaces;
    using KangaSys.Application.Queries;
    using KangaSys.Infrastructure.Data;
    using KangaSys.Infrastructure.Services;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        private Program()
        {
        }

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
                                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<CsvExportService>();
            builder.Services.AddScoped<PdfExportService>();
            builder.Services.AddScoped<JsonExportService>();
            builder.Services.AddScoped<IExportServiceFactory, ExportServiceFactory>();

            builder.Services.AddMediatR(typeof(ExportReportHandler).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}