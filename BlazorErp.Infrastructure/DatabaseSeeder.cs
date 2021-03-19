﻿using BlazorErp.Application.Helpers;
using BlazorErp.Application.Interfaces.Services;
using BlazorErp.Infrastructure.Contexts;
using BlazorErp.Shared.Constants.Permission;
using BlazorErp.Shared.Constants.Role;
using BlazorErp.Shared.Constants.User;
using BlazorErp.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlazorErp.Infrastructure
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly BlazorHeroContext _db;
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(UserManager<BlazorHeroUser> userManager, RoleManager<IdentityRole> roleManager, BlazorHeroContext db, ILogger<DatabaseSeeder> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _logger = logger;
        }

        public void Initialize()
        {
            try
            {
                _db.Database.Migrate();
            }
            catch
            {
            }            
            AddAdministrator();
            AddBasicUser();
            _db.SaveChanges();
        }

        private void AddAdministrator()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var adminRole = new IdentityRole(RoleConstant.AdministratorRole);
                var adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstant.AdministratorRole);
                if (adminRoleInDb == null)
                {
                    await _roleManager.CreateAsync(adminRole);
                    _logger.LogInformation("Seeded Administrator Role.");
                }
                //Check if User Exists
                var superUser = new BlazorHeroUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@erp.com",
                    UserName = "admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);
                if (superUserInDb == null)
                {
                    await _userManager.CreateAsync(superUser, UserConstant.DefaultPassword);
                    var result = await _userManager.AddToRoleAsync(superUser, RoleConstant.AdministratorRole);
                    if (result.Succeeded)
                    {
                        await _roleManager.GeneratePermissionClaimByModule(adminRole, PermissionModules.Users);
                        await _roleManager.GeneratePermissionClaimByModule(adminRole, PermissionModules.Roles);
                        await _roleManager.GeneratePermissionClaimByModule(adminRole, PermissionModules.Products);
                        await _roleManager.GeneratePermissionClaimByModule(adminRole, PermissionModules.Brands);
                    }
                    _logger.LogInformation("Seeded User with Administrator Role.");
                }
            }).GetAwaiter().GetResult();
        }

        private void AddBasicUser()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var basicRole = new IdentityRole(RoleConstant.BasicRole);
                var basicRoleInDb = await _roleManager.FindByNameAsync(RoleConstant.BasicRole);
                if (basicRoleInDb == null)
                {
                    await _roleManager.CreateAsync(basicRole);
                    _logger.LogInformation("Seeded Basic Role.");
                }
                //Check if User Exists
                var basicUser = new BlazorHeroUser
                {
                    FirstName = "Burak",
                    LastName = "Deneme",
                    Email = "burak@erp.com",
                    UserName = "Burak",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                var basicUserInDb = await _userManager.FindByEmailAsync(basicUser.Email);
                if (basicUserInDb == null)
                {
                    await _userManager.CreateAsync(basicUser, UserConstant.DefaultPassword);
                    await _userManager.AddToRoleAsync(basicUser, RoleConstant.BasicRole);
                    _logger.LogInformation("Seeded User with Basic Role.");
                }
            }).GetAwaiter().GetResult();
        }
    }
}