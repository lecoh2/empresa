using Microsoft.OpenApi.Models;

namespace CompanyApp.Api.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options => options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title= "CompanyApp - API para empresa",
                    Description= "API REST .NET com EntityFramework e Xunit",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Alex Sandro Costa dos Santos",
                        Email = "lecoh@hotmail.com",
                        Url = new Uri("http://www.google.com")
                    }

                }));
        }
    }
}
