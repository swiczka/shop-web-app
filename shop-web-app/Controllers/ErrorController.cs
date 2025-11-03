using Microsoft.AspNetCore.Mvc;

namespace shop_web_app.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(int code)
        {
            if (code == 401)
            {
                return View("Error401");
            }
            else if (code == 403)
            {
                return View("Error403");
            }
            else if (code == 400)
            {
                return View("Error400");
            }
            else if (code == 404)
            {
                return View("Error404");
            }
            return View("GeneralError");
        }
    }
}
