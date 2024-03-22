using Microsoft.AspNetCore.Mvc;
using DataAccess;
using DataAccess.Models;
using System.Linq;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public UserController(LiveMapDbContext context)
    {
        _context = context;
    }

    [HttpGet("{name}")]
    public IActionResult GetUserByName(string name)
    {
        var user = _context.Users.FirstOrDefault(u => u.Name == name);

        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }
}