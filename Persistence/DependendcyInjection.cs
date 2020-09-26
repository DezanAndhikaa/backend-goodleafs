using System;
using Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence {
    public static class DependendcyInjection {
        public static IServiceCollection AddPersistence (this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<AppDbContext> (options => {
                options.UseSqlServer (configuration.GetConnectionString ("DbConnection"), x => {
                    x.CommandTimeout (60);
                    x.EnableRetryOnFailure (maxRetryCount: 100,
                        maxRetryDelay: TimeSpan.FromSeconds (5), errorNumbersToAdd: null);
                });
            }, ServiceLifetime.Transient);

            services.AddTransient<IAppDbContext> (provider => provider.GetService<AppDbContext> ());

            return services;
        }
    }
}