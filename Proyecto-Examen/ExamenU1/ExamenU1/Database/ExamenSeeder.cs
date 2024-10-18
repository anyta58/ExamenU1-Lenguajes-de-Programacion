using ExamenU1.Constants;
using ExamenU1.Database.Entities;
using Microsoft.AspNetCore.Identity;

namespace ExamenU1.Database;

public static class ExamenSeeder
{
    public static async Task LoadDataAsync(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ILoggerFactory loggerFactory
        )
    {
        try
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(RolesConstant.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(RolesConstant.RRHH));
                await roleManager.CreateAsync(new IdentityRole(RolesConstant.EMPLOYEE));
            }

            if (!userManager.Users.Any())
            {
                var userAdmin = new IdentityUser
                {
                    Email = "jperez@me.com",
                    UserName = "Juan perez",
                    //EntryDate = DateTime.UtcNow,
                    //CreatedDate = DateTime.UtcNow,
                    //Gender = "Hombre"

                };

                await userManager.CreateAsync(userAdmin, "Temporal001*");
                await userManager.AddToRoleAsync(userAdmin, RolesConstant.ADMIN);

                var normalUser = new IdentityUser
                {
                    UserName = "maria mejia",
                    Email = "maria@me.com",
                    //EntryDate = DateTime.UtcNow,
                    //CreatedDate = DateTime.UtcNow,
                    //Gender = "Mujer"
                };

                await userManager.CreateAsync(normalUser, "Temporal001*");
                await userManager.AddToRoleAsync(normalUser, RolesConstant.EMPLOYEE);

                var rrhhUser = new IdentityUser
                {
                    UserName = "amelia lopez",
                    //EntryDate = DateTime.UtcNow,
                    // CreatedDate = DateTime.UtcNow,
                    //Gender = "Mujer"
                };

                await userManager.CreateAsync(rrhhUser, "Temporal001*");
                await userManager.AddToRoleAsync(rrhhUser, RolesConstant.RRHH);
            }
        }
        catch (Exception e)
        {

            var logger = loggerFactory.CreateLogger<ExamenContext>();
            logger.LogError(e.Message);
        }
    }
}
