using GlobolTicket.TicketManagement.Infrastructure.FileExport;
using GlobolTicket.TicketManagement.Infrastructure.Mail;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobolTicket.TicketManagement.Infrastructure
{
    public static class InfrastuctureServiceCollection
    {
        public static IServiceCollection AddInfrastuctureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();
            return services;
        }
    }
}
