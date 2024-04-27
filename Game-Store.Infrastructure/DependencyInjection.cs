using Game_Store.Application.Abstractions;
using Game_Store.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAppDbContext, GameStoreDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
