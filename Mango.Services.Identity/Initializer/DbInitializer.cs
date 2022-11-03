using Mango.Services.Identity.DbContexts;
using Mango.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static Duende.IdentityServer.Models.IdentityResources;

namespace Mango.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(SD.Admin).Result != null)
            {
                return;
            }

            _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();

            var adminUser = new ApplicationUser
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111",
                FirstName = "Bob",
                LastName = "Admin"
            };

            _userManager.CreateAsync(adminUser, "Admin_123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]{
                new Claim(IdentityModel.JwtClaimTypes.Name,adminUser.FirstName + " " +adminUser.LastName),
                new Claim(IdentityModel.JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(IdentityModel.JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(IdentityModel.JwtClaimTypes.Role, SD.Admin)
            }).Result;

            var customerUser = new ApplicationUser
            {
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111",
                FirstName = "Bob",
                LastName = "Admin"
            };

            _userManager.CreateAsync(customerUser, "Customer_123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();



            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]{
                new Claim(IdentityModel.JwtClaimTypes.Name,customerUser.FirstName + " " + customerUser.LastName),
                new Claim(IdentityModel.JwtClaimTypes.GivenName, customerUser.FirstName),
                new Claim(IdentityModel.JwtClaimTypes.FamilyName, customerUser.LastName),
                new Claim(IdentityModel.JwtClaimTypes.Role, SD.Customer)
            }).Result;

        }
    }
}
