using Microsoft.AspNetCore.Mvc;
using MobileMapAPI.ApiModels;
using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using System;
using System.Threading.Tasks;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FacilityController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public FacilityController(LiveMapDbContext context)
    {
        _context = context;
    }
}
