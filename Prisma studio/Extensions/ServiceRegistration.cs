using Prisma_studio.Models.DbConfiguration;
using Prisma_studio.Services.Interfaces;
using Prisma_studio.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prisma_studio.Data;

namespace Prisma_studio.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddHotelServices(this IServiceCollection services)
        {
            services.AddDbContext<PrismContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
