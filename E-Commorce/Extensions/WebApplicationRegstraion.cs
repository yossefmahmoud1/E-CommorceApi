using Domain_Layer.Contracts;
using E_Commorce.CustomMiddleWares;

namespace E_Commorce.Extensions
{
    public static class WebApplicationRegstraion
    {

        public static async  Task SeedDataBaseAsync(this WebApplication app) {

            using var scope = app.Services.CreateScope();



            var objectofdataseeding = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await objectofdataseeding.DataSeedasync();
            await objectofdataseeding.IdentityDataSeeding();
        }

        public static IApplicationBuilder UseCustomExceptionMiddleWare(this IApplicationBuilder app) {


            app.UseMiddleware<CustomExecptionHandlerMiddleWare>();
return app; 

        }
    }
}
