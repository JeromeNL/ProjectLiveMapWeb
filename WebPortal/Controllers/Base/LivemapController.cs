using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Controllers;

public class LivemapController : Controller
{
    protected int ResortId => HttpContext.Session.GetInt32("resortId") ?? 1;
}