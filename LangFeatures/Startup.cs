using System;
using Microsoft.Extensions.DependencyInjection;
namespace LangFeatures_Sample
{
    public static class Startup
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<StreamForEach>();
        }
    }
}
