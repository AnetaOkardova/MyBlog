using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult ErrorNotFound()
        {
            return View();
        }
        public IActionResult ActionNotSuccessful(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
