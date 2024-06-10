using DataAccess.Models;

namespace WebPortal.Models;

public class UsersViewModel
{
    public ApplicationUser User { get; set; }
    public string? Role { get; set; }
    public string? Resort { get; set; }
}