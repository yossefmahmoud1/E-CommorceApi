
using System.Text.Json;
using AutoMapper;
using Domain_Layer.Contracts;
using E_Commerce.Web.Extensions;
using E_Commorce.CustomMiddleWares;
using E_Commorce.Extensions;
using E_Commorce.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositeryies;
using Presention.Data;
using Service;
using Service.MappingProfiels;
using ServiceAbstraction;
using Shared.ErrorModels;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace E_Commorce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Services

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()   
                          .AllowAnyMethod()  
                          .AllowAnyHeader(); 
                });
            });


            builder.Services.AddApplicationServices();
            builder.Services.AddWebApplicationServices();
            builder.Services.AddJwtSetvice(builder.Configuration);

            builder.Services.AddSwaggerServices();

            #endregion

            var app = builder.Build();
            await app.SeedDataBaseAsync();
            app.UseCustomExceptionMiddleWare();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => {

                options.ConfigObject = new ConfigObject() {

                    DisplayRequestDuration = true,
                    Filter = "false"

                };

                    options.DocumentTitle = "E-Commerce API";

                    options.JsonSerializerOptions = new JsonSerializerOptions()
                    {

PropertyNamingPolicy = JsonNamingPolicy.CamelCase

                    };

                    //options.DocExpansion(DocExpansion.None);
                    //options.EnableFilter();
                    options.EnablePersistAuthorization();
                });
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
