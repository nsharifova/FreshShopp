
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area(nameof(Admin))]
    public class DashboardController : Controller
    {
       


        public IActionResult Index()
        {
          return View();

            
        }
    }
}
