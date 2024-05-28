namespace DataAccess.Models.Extensions;

public static class RoleExtension
{
    public static IEnumerable<string> getRolesWithWebPortalAccess()
    {
        return new List<string>()
        {
            nameof(Role.SuperAdmin), 
            nameof(Role.ResortAdmin), 
            nameof(Role.ResortEmployee),
        };
    }
}