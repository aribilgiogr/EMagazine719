using BLL.Services;
using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BLLServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DAL'dan gelen
            services.AddUnitOfWork(configuration);

            // Servisler
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
