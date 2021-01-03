using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Common;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared
{
    public static class DependencyInjection
    {
        public static void AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
