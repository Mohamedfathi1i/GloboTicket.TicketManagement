using GlobalTicket.TicketManager.Persistence.Repositories;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManager.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("GloboTicketManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRespository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IEventRepository, EventRepository>();

            return services;
        }
    }
}
