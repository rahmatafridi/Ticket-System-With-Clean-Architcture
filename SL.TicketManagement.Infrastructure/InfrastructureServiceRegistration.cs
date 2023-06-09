﻿using SL.TicketManagement.Application.Contracts.Infrastructure;
using SL.TicketManagement.Application.Models.Mail;
using SL.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SL.TicketManagement.Infrastructure.FileExport;

namespace SL.TicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter,CsvExporter>();

            return services;
        }
    }
}
