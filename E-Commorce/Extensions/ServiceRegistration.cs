
using System.Reflection.Metadata;
using E_Commorce.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace E_Commerce.Web.Extensions
{
    public static class ServiceRegistration
    {
        // 1 reference
        public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(name: "Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {

                    In = ParameterLocation.Header,    //"Header"
                    Name = "Authorization" ,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme= "Bearer",

                    Description = "Enter 'Bearer' followed by a space and then your JWT token.\n\nExample: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6..."
                }
                );
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id= "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            return Services;
        }

        // 0 references
        public static IServiceCollection AddWebApplicationServices(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>(configureOptions: (Options) =>
            {
                Options.InvalidModelStateResponseFactory = ApiResponseFactory.GenricApiValidationErrorsResponse;
            });

            return Services;
        }


        public static IServiceCollection AddJwtSetvice(this IServiceCollection Services ,IConfiguration configuration)
        {
            Services.AddAuthentication(Config =>
            {

                Config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Options =>
            {
                Options.TokenValidationParameters = new TokenValidationParameters()
                {



                    ValidateIssuer = true,
                    ValidIssuer = configuration["JwtOptions:issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JwtOptions:audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                  
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JwtOptions:secretKey"]))
                };

            });
            return Services;


        }


    }
}