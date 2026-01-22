using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhotoStudio.Services;
using Prisma_studio.Data;
using Prisma_studio.Models.DbConfiguration;
using Prisma_studio.Services;
using Prisma_studio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisma_studio.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddHotelServices(this IServiceCollection services)
        {
            services.AddDbContext<PrismContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShopService, ShopService>();

            return services;
        }
    }
}
