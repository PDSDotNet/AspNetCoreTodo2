﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using AspNetCoreTodo.Models;


namespace AspNetCoreTodo
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager);
        }


        /// <summary>
        /// Cheque que el role de Administrador exista en la base de datos, 
        /// si existe retorna, si no existe lo crea (esto deberia pasar una sola vez).
        /// </summary>
        /// <param name="roleManager"></param>
        /// <returns></returns>
        private static async Task EnsureRolesAsync(RoleManager< IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync( Constants.AdministratorRole);

            if (alreadyExists)
                return;

            await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));

            /*
            if (!alreadyExists)
                await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole)); 
            */
        }

        /// <summary>
        /// Cheque que el usuadio admin@todo.local exista en la BD, 
        /// si existe retorna, si no existe lo crea.
        /// </summary>
        /// <param name="userManager"></param>
        /// <returns></returns>
        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users.Where
                (x => x.UserName == "admin@todo.local").SingleOrDefaultAsync();

            if (testAdmin != null)
                return;

            testAdmin = new ApplicationUser
                    {
                        UserName = "admin@todo.local",
                        Email = "admin@todo.local"
                    };

            await userManager.CreateAsync(testAdmin, "NotSecure123!!");

            await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);   
        }
    }
}
