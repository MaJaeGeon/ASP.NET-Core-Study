using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            using(var context = new MyAppContext(serviceProvider.GetRequiredService<DbContextOptions<MyAppContext>>()))
            {
                if (!context.Teacher.Any())
                {
                    context.Teacher.AddRange(
                    new Teacher() { Name = "A", Class = "1" },
                    new Teacher() { Name = "B", Class = "2" },
                    new Teacher() { Name = "C", Class = "3" },
                    new Teacher() { Name = "D", Class = "4" }
                    );

                    context.SaveChanges();
                }

                var adminAccount = await userManager.FindByNameAsync("admin@gmail.com");
                var adminRole = new IdentityRole("Admin");

                await roleManager.CreateAsync(adminRole);
                await userManager.AddToRoleAsync(adminAccount, adminRole.Name);
            }
        }
    }
}
