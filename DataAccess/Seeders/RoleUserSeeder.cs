using DataAccess.Models;
using DataAccess.Seeders.Abstract;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Seeders;

public class RoleUserSeeder(List<IdentityRole> roles, List<ApplicationUser> users) : ISeeder<IdentityUserRole<string>>
{
    public List<IdentityUserRole<string>> Seed()
    {
        var userRoles = new List<IdentityUserRole<string>>();

        foreach (var role in roles)
        {
            userRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = users.First(user => user.UserName == role.Name).Id
            });
        }

        // Add the superadmin role to users which do NOT have a name that matches the role name
        foreach (var user in users.Where(user => roles.All(role => role.Name != user.UserName)))
        {
            userRoles.Add(new IdentityUserRole<string>
            {
                RoleId = roles.First(role => role.Name == nameof(Role.SuperAdmin)).Id,
                UserId = user.Id
            });
        }

        return userRoles;
    }
}