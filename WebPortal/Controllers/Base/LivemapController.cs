using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Controllers.Base;

public class LivemapController : Controller
{
    protected int ResortId
    {
        get
        {
            var resortId = HttpContext.Session.GetInt32("resortId") ?? 1;
            return resortId == 0 ? 1 : resortId;
        }
    }
}