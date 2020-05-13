using GermanOutletStore.Data;
using GermanOutletStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace GermanOutletStore.Common
{
    public static class AppBuilderExtensions
    {
        private static readonly string AdminPassword = "admin123";
        private static readonly IdentityRole[] roles =
        {
            new IdentityRole("Admin"),
            new IdentityRole("Cashier")
        };
        public static readonly List<ProductType> availableTypes = new List<ProductType>()
        {
            new ProductType() { Name = "Shoes" },
            new ProductType() { Name = "Clothes" },
            new ProductType() { Name = "Pants" },
            new ProductType() { Name = "Accessories" },
            new ProductType() { Name = "Underwear" },
        };
        public static readonly List<Size> availableSizes = new List<Size>()
        {
            new Size() { Name = "XS" },
            new Size() { Name = "S" },
            new Size() { Name = "M" },
            new Size() { Name = "L" },
            new Size() { Name = "XL" },
            new Size() { Name = "XXL" },
            new Size() { Name = "37" },
            new Size() { Name = "38" },
            new Size() { Name = "39" },
            new Size() { Name = "40" },
            new Size() { Name = "41" },
            new Size() { Name = "42" },
            new Size() { Name = "43" },
            new Size() { Name = "44" },
            new Size() { Name = "45" },
        };

        public static async void SeedDatabase(this IApplicationBuilder builder)
        {
            IServiceScopeFactory serviceFactory = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            IServiceScope scope = serviceFactory.CreateScope();

            using (scope)
            {
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserManager<User> userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                StoreDbContext context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

                foreach (IdentityRole role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }
                
                User user = await userManager.FindByNameAsync("admin");
                if (user == null)
                {
                    user = new User()
                    {
                        UserName = "admin",
                        Email = "admin@abv.bg",                        
                    };

                    var result = await userManager.CreateAsync(user, AdminPassword);
                    result = await userManager.AddToRoleAsync(user, roles[0].Name);

                    context.Types.AddRange(availableTypes);
                    foreach (var size in availableSizes)
                    {
                        context.Sizes.Add(size);
                    }
                    context.Brands.Add(new Brand() { Name = "Other" });
                    context.SaveChanges();
                }                
            }
        }
    }
}
