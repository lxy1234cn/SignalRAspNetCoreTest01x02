using Microsoft.OpenApi.Models;
namespace SignalRAspNetCoreTest01x02.Extensions
{
    public static class AllowAllCoreExtensions
    {
        public static IServiceCollection AddAllowAllCors(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    //builder.AllowAnyOrigin()
                    //       .AllowAnyMethod()
                    //       .AllowAnyHeader()
                    //       .AllowCredentials();
                    builder.SetIsOriginAllowed(_ => true) // 允许任何来源
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          //.WithOrigins("*")
                          //.WithOrigins("http://localhost:xxxx")
                          .AllowCredentials();
                });
            });
            return services;
        }
    }
}
