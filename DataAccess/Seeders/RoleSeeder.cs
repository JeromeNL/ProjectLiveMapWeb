using DataAccess.Models;
using DataAccess.Seeders.Abstract;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Seeders;

public class RoleSeeder : ISeeder<IdentityRole>
{
    public List<IdentityRole> Seed()
    {
        return Enum.GetValues<Role>().Select(role => new IdentityRole
            { Name = role.ToString(), NormalizedName = role.ToString().ToUpper() }).ToList();
    }
}