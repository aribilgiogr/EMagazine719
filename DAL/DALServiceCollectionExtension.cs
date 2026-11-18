using DAL.Contexts;
using DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DALServiceCollectionExtension
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NewsContext>(options => options.UseSqlite(configuration.GetConnectionString("news")));

            services.AddScoped<IUnitOfWork, UnitOfWork<NewsContext>>();

            return services;
        }
    }
}
