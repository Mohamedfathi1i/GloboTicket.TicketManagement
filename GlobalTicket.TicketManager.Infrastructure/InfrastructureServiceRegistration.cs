﻿using GlobalTicket.TicketManager.Infrastructure.Mail;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManager.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration) 
        {
        
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            
            return services;
        
        }
    }
}
