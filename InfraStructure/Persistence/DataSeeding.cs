using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain_Layer.Contracts;
using Domain_Layer.Models.Identity;
using Domain_Layer.Models.Order;
using Domain_Layer.Models.Producr;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Identity;
using Presention.Data;

namespace Persistence
{
    public class DataSeeding(StoreDbContext _storeDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, StoreIdentityDbContext identityDbContext) : IDataSeeding
    {


        public async Task DataSeedasync()
        {
            try
            {
                if ((await _storeDbContext.Database.GetAppliedMigrationsAsync()).Any())

                {
                    await _storeDbContext.Database.MigrateAsync();
                }
                if (!_storeDbContext.ProductBrands.Any())
                {
                    //.. 
                    var ProductBrandData = File.OpenRead("..\\InfraStructure\\Persistence\\Data\\DataSeedData\\brands.json");
                    //convert from string to c#
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (ProductBrands is not null && ProductBrands.Any())
                    {

                        await _storeDbContext.ProductBrands.AddRangeAsync(ProductBrands);


                    }
                }


                if (!_storeDbContext.ProductTypes.Any())
                {
                    var ProductTypesData = File.OpenRead("..\\InfraStructure\\Persistence\\Data\\DataSeedData\\types.json");
                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypesData);
                    if (ProductTypes is not null && ProductTypes.Any())
                    {
                        await _storeDbContext.ProductTypes.AddRangeAsync(ProductTypes); // ← التغيير هنا
                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var ProductsData = File.OpenRead("..\\InfraStructure\\Persistence\\Data\\DataSeedData\\products.json");
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductsData);
                    if (Products is not null && Products.Any())
                    {
                        await _storeDbContext.Products.AddRangeAsync(Products); // ← والتغيير هنا
                    }
                }

                if (!_storeDbContext.Set<DlievryMethod>().Any())
                {
                    // Read Data
                    using var DeliveryMethodDataStream = File.OpenRead(path: @"..\InfraStructure\Persistence\Data\DataSeedData\delivery.json");

                    var DeliveryMethods = await JsonSerializer.DeserializeAsync<List<DlievryMethod>>(utf8Json: DeliveryMethodDataStream);
                    // Save To Db
                    if (DeliveryMethods is not null && DeliveryMethods.Any())
                    {
                        await _storeDbContext.Set<DlievryMethod>().AddRangeAsync(entities: DeliveryMethods);
                    }
                }


                await _storeDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during data seeding: {ex.Message}");
                throw; // عشان ما تخفيش الأخطاء


            }
        }

        public async Task IdentityDataSeeding()
        {
            try
            {

                if (!roleManager.Roles.Any())
                {


                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

                }


                if (!userManager.Users.Any())
                {
                    var User01 = new ApplicationUser()
                    {

                        Email = "OmarYosef136@gmail.com",
                        DisplayName = "Youssef Mahmoud",
                        PhoneNumber = "01149175542",
                        UserName = "YoussefMahmoud"



                    };
                    var User02 = new ApplicationUser()
                    {

                        Email = "Youssefmahmoud51@gmail.com",
                        DisplayName = "Youssef Mahmoud51",
                        PhoneNumber = "01064423947",
                        UserName = "Youssefmahmoud51"



                    };

                    await userManager.CreateAsync(User01, "Youssef@123");
                    await userManager.CreateAsync(User02, "Youssef@123");


                    await userManager.AddToRoleAsync(User01, "Admin");
                    await userManager.AddToRoleAsync(User02, "SuperAdmin");

                    await identityDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during data seeding Users: {ex.Message}");
                throw; // عشان ما تخفيش الأخطاء

            }



        }
    }
}
