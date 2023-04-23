using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sat.Recruitment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SatRecruitment");

            services.AddDbContext<ApplicationDbContext>(option => 
                option.UseSqlServer(connectionString));

            return services;
        }
    }
}
