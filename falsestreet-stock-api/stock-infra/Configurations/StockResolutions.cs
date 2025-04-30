using Microsoft.Extensions.DependencyInjection;
using stock_infra.External;
using stock_infra.Implementations.External;

namespace stock_infra.Configurations
{
    public static class StockResolutions
    {
        public static IServiceCollection AddStockResolutions(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
            services.AddScoped<IFinnhubService, FinnhubService>();
            return services;
        }
    }
}
