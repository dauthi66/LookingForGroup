using Microsoft.AspNetCore.Identity;

namespace LookingForGroup.Models
{
#nullable disable
    /// <summary>
    /// Keeps track of different roles
    /// </summary>
    public static class IdentityHelper
    {
        public const string Admin = "Admin";
        public const string Member = "Member";

        /// <summary>
        /// Utilizes built in role manager
        /// </summary>
        /// <param name="provider">gives access to Iservice services</param>
        /// <param name="roles"></param>
        /// <returns>A task to create roles</returns>
        public static async Task CreateRoles(IServiceProvider provider, params string[] roles) // params allows you to specify strings at creation
        {
            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach(string role in roles)
            {
                //check if role exists, if not create with roleManager
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
