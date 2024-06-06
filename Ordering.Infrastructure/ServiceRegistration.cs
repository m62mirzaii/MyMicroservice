using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories; 
using Ordering.Infrastructure.DataBaseContext;
using Ordering.Infrastructure.Interceptors;
using Ordering.Infrastructure.Repositories;
using Ordering.Infrastructure.Repositories.GenericRepositories;
using Ordering.Infrastructure.Repositories.UnitOfWorks;

namespace Ordering.Infrastructure;

public static class ServiceRegistration
{
    public static void ServiceConfig(this IServiceCollection services, IConfiguration configure)
    { 
        //services.AddHostedService<ProcessOutboxMessagesJob>();
        //services.AddDbContext<OrderContext>((sp, option) =>
        //{
        //    var interceptor = sp.GetService<ConvertDomainEventToOutboxMessageInterceptor>();
        //    option.UseSqlServer(configure.GetConnectionString("DataBaseConnection")).AddInterceptors(interceptor);
        //});

        services.AddDbContext<OrderContext>(option => option.UseSqlServer(configure.GetConnectionString("DataBaseConnection")));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddSingleton<ConvertDomainEventToOutboxMessageInterceptor>();
       
    }
}
