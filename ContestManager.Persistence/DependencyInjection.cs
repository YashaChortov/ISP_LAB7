using ContestManager.Domain.Abstractions;
using ContestManager.Persistence.Data;
using ContestManager.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContestManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services,
            DbContextOptions options)
        {
            services.AddPersistence()
                .AddSingleton<AppDbContext>(new AppDbContext((DbContextOptions<AppDbContext>)options))
                .AddSingleton<IUnitOfWork, EfUnitOfWork>();
            return services;
        }
    }
}