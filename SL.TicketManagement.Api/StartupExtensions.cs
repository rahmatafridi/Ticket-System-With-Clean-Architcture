﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SL.TicketManagement.Api.Utility;
using SL.TicketManagement.Application;
using SL.TicketManagement.Infrastructure;
using SL.TicketManagement.Persistence;

namespace SL.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfiureServices(this WebApplicationBuilder bulider)
        {
            AddSwagger(bulider.Services);
            bulider.Services.AddApplicationServices();
            bulider.Services.AddInfrastructureServices(bulider.Configuration);
            bulider.Services.AddPersistenceServices(bulider.Configuration); 
            bulider.Services.AddControllers();
            bulider.Services.AddCors(option =>
            {
                option.AddPolicy("Open",bulider=> bulider.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            });
            return bulider.Build();
        }
        public static WebApplication ConfiurePipline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "System Links Ticket Management API");
                });
            }
            app.UseHttpsRedirection();
            app.UseRouting();   
            app.UseCors("Open");
            app.MapControllers();
            return app;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {


                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "System Links Ticket Management API",

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<SLTicketDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}
