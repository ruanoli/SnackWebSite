using Microsoft.AspNetCore.Mvc;

namespace SnackWebSite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
