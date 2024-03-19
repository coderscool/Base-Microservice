using Domain.Abstractions.EventStore;
using Infratructure.EventStore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.EventStore.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationStoreEvent(this IServiceCollection services)
        {
            services.AddTransient<IEventStoreRepository, EventStoreRepository>();
            var conn = "Data Source=MSI; Initial Catalog=BaseCode/Account; User id=sa; Password=vhp; TrustServercertificate=true";
            services.AddDbContext<EventStoreDbContext>(options =>
                options.UseSqlServer(conn, b => b.MigrationsAssembly("WorkerService1")));
            return services;
        }
    }
}
