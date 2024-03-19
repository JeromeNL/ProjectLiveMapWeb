using Microsoft.AspNetCore.Mvc;
using DataAccess;
using DataAccess.Models;
using System.Linq;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public UserController(LiveMapDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpGet("{name}")]
    public IActionResult GetUserByName(string name)
    {
        var user = _context.Users.FirstOrDefault(u => u.Name == name);

        if (user != null)
        {
            return Ok(user);
        }

        return NotFound("User not found");
    }
}