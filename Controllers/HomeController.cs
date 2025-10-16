using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {

        return View();
    }
}