using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services)
        {
            const string databaseName = "ChatDB";

            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseInMemoryDatabase(databaseName));


            services.AddTransient<IEventRepository, EventRepository>();

            return services;
        }
    }
}
