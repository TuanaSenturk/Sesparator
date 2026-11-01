using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Sesparator.Web.Controllers
{
    [Authorize(Roles = "Musteri")]

    public class SohbetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}