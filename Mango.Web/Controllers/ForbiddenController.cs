using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class ForbiddenController : Controller
    {
 
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
