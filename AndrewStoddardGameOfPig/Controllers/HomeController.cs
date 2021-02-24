using Microsoft.AspNetCore.Mvc;

namespace AndrewStoddardGameOfPig.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
