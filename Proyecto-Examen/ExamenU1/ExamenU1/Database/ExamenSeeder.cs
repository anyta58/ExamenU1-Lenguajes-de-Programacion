using ExamenU1.Constants;
using ExamenU1.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExamenU1.Database;

public class ExamenSeeder
{

    public static async Task LoadDataAsync(
            ExamenContext context,
            ILoggerFactory loggerFactory,
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager
        )
    {
        try
        {
            await LoadRolesAndUsersAsync(userManager, roleManager, loggerFactory);
        }
        catch ( Exception e )
        {
            var logger = loggerFactory.CreateLogger<ExamenSeeder>();
            logger.LogError(e, "Error inicializando la data del API");
        }
    }

    public static async Task LoadRolesAndUsersAsync(
            UserManager<UserEntity> userManager,
            RoleManager <IdentityRole> roleManager,
            ILoggerFactory loggerFactory
        )
    {
        try
        {
            // si no hay ningun rol que cree los siguientes
            if(!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(RolesConstant.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(RolesConstant.RRHH));
                await roleManager.CreateAsync(new IdentityRole(RolesConstant.EMPLOYEE));
            }

            if(!userManager.Users.Any())
            {
                var userAdmin = new UserEntity
                {
                    Email = "admin@examen.com",
                    UserName = "admin@examen.com",
                    Name = "Juan Perez",
                    EntryDate = new DateTime(2000, 10, 30),
                };

                var userRRHH = new UserEntity
                {
                    Email = "rrhh@examen.com",
                    UserName = "rrhh@examen.com",
                    Name = "Maria Mejia",
                    EntryDate = new DateTime(2010, 12, 5),
                };

                var userEmployee = new UserEntity
                {
                    Email = "employee@examen.com",
                    UserName = "employee@examen.com",
                    Name = "Julian Gutierrez",
                    EntryDate = new DateTime(2015, 5, 2),
                };

                await userManager.CreateAsync(userAdmin, "Temporal01");
                await userManager.CreateAsync(userRRHH, "Temporal01");
                await userManager.CreateAsync(userEmployee, "Temporal01");

                await userManager.AddToRoleAsync(userAdmin, RolesConstant.ADMIN);
                await userManager.AddToRoleAsync(userRRHH, RolesConstant.RRHH);
                await userManager.AddToRoleAsync(userEmployee, RolesConstant.EMPLOYEE);
            }
        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<ExamenSeeder>();
            logger.LogError(e.Message);
        }

    }

}
